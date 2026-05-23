namespace WinForms.Native.PInvoke.Safe;

public class PInvokeException : Exception
{
    public PInvokeException(string functionName, int hresult, string? msg = null, Exception? inner = null) : base(msg, inner)
    {
        FunctionName = functionName;
        HResult = hresult;
    }
    public string FunctionName { get; }
}