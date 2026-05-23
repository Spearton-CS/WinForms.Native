param(
    [string]$Solution = "WinForms.Native.slnx",
    [string]$OutDir = "BuildGraph"
)

$ErrorActionPreference = "Stop"

New-Item -ItemType Directory -Force -Path $OutDir | Out-Null

$jsonPath = Join-Path $OutDir "graph.json"
$dgmlPath = Join-Path $OutDir "graph.dgml"

Write-Host "== Generating MSBuild graph =="

dotnet msbuild $Solution `
  /t:GenerateRestoreGraphFile `
  /p:RestoreGraphOutputPath=$jsonPath `
  /nologo | Out-Null

Write-Host "== Loading JSON =="

$data = Get-Content $jsonPath -Raw | ConvertFrom-Json

# ---------------- helpers ----------------

function ShortName($p) {
    [System.IO.Path]::GetFileNameWithoutExtension($p)
}

function Norm($p) {
    ($p -replace "\\","/").ToLowerInvariant()
}

# ---------------- noise filter ----------------

$ignore = @(
    "microsoft.netcore.app",
    "microsoft.windowsdesktop.app",
    "system.windows.forms",
    "system.windows",
    "wpf",
    "microsoft.aspnetcore.app"
)

function IsNoise($path) {
    if (-not $path) { return $true }

    if ($path -notlike "*.csproj") { return $true }

    $p = Norm $path

    foreach ($i in $ignore) {
        if ($p -like "*$i*") { return $true }
    }

    return $false
}

# ---------------- coloring rules ----------------

$rules = @(
    @{ Match = "additionalmodules/safe";    Color = "LightGreen" },
    @{ Match = "additionalmodules/pinvoke"; Color = "Orange" },
    @{ Match = "additionalmodules";        Color = "LightBlue" },

    @{ Match = "requiredmodules/pinvoke";  Color = "DeepSkyBlue" },
    @{ Match = "requiredmodules";          Color = "LightCoral" }
)

function GetGroup($path) {
    $p = Norm $path

    if ($p -like "*additionalmodules/safe*")    { return "AdditionalModules.Safe" }
    if ($p -like "*additionalmodules/pinvoke*") { return "AdditionalModules.PInvoke" }
    if ($p -like "*additionalmodules*")         { return "AdditionalModules" }

    if ($p -like "*requiredmodules/pinvoke*")   { return "RequiredModules.PInvoke" }
    if ($p -like "*requiredmodules*")           { return "RequiredModules" }

    return "Core"
}

# ---------------- edges ----------------

$edges = New-Object System.Collections.Generic.HashSet[string]

foreach ($projKey in $data.projects.PSObject.Properties.Name) {

    $proj = $data.projects.$projKey
    if (-not $proj.restore.frameworks) { continue }

    foreach ($fwKey in $proj.restore.frameworks.PSObject.Properties.Name) {

        $fw = $proj.restore.frameworks.$fwKey
        if (-not $fw.projectReferences) { continue }

        foreach ($refKey in $fw.projectReferences.PSObject.Properties.Name) {

            $toPath = $fw.projectReferences.$refKey.projectPath

            if (IsNoise $toPath) { continue }

            $from = ShortName $proj.restore.projectPath
            $to   = ShortName $toPath

            if ($from -eq $to) { continue }

            $edges.Add("$from|$to") | Out-Null
        }
    }
}

Write-Host "Edges: $($edges.Count)"

# ---------------- DGML ----------------

$sb = New-Object System.Text.StringBuilder

[void]$sb.AppendLine('<?xml version="1.0" encoding="utf-8"?>')
[void]$sb.AppendLine('<DirectedGraph xmlns="http://schemas.microsoft.com/vs/2009/dgml">')

# ---------- Styles ----------
[void]$sb.AppendLine('<Styles>')

foreach ($r in $rules) {
    [void]$sb.AppendLine("<Style TargetType='Node'>")
    [void]$sb.AppendLine("<Condition Expression=""HasCategory('$($r.Match)')"" />")
    [void]$sb.AppendLine("<Setter Property='Background' Value='$($r.Color)' />")
    [void]$sb.AppendLine("</Style>")
}

[void]$sb.AppendLine("<Style TargetType='Node'>")
[void]$sb.AppendLine("<Setter Property='Background' Value='LightGray' />")
[void]$sb.AppendLine("</Style>")

[void]$sb.AppendLine('</Styles>')

# ---------- Nodes ----------
[void]$sb.AppendLine('<Nodes>')

$nodeSet = New-Object System.Collections.Generic.HashSet[string]

foreach ($e in $edges) {
    $p = $e.Split("|")
    $nodeSet.Add($p[0]) | Out-Null
    $nodeSet.Add($p[1]) | Out-Null
}

foreach ($n in $nodeSet) {

    $full = ($data.projects.PSObject.Properties.Name | Where-Object {
        ShortName $data.projects.$_.restore.projectPath -eq $n
    } | Select-Object -First 1)

    $path = if ($full) { $data.projects.$full.restore.projectPath } else { $n }

    $cat = GetGroup $path

    [void]$sb.AppendLine("<Node Id='$n' Label='$n' Category='$cat' />")
}

[void]$sb.AppendLine('</Nodes>')

# ---------- Links ----------
[void]$sb.AppendLine('<Links>')

foreach ($e in $edges) {
    $p = $e.Split("|")
    [void]$sb.AppendLine("<Link Source='$($p[0])' Target='$($p[1])' />")
}

[void]$sb.AppendLine('</Links>')

[void]$sb.AppendLine('</DirectedGraph>')

# ---------------- write ----------------

$enc = New-Object System.Text.UTF8Encoding($false)
[System.IO.File]::WriteAllText($dgmlPath, $sb.ToString(), $enc)

Write-Host "== Done =="
Write-Host $dgmlPath

Start-Process $dgmlPath