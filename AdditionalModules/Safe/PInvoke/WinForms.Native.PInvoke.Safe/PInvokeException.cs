using System.Runtime.CompilerServices;

namespace WinForms.Native.PInvoke.Safe;

public class PInvokeException : Exception
{
    public PInvokeException(string functionName, HResult hresult, string? msg = null, Exception? inner = null) : base(msg, inner)
    {
        FunctionName = functionName;
        HResult = hresult;
    }
    public string FunctionName { get; }
    public new HResult HResult
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (HResult)base.HResult;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => base.HResult = (int)value;
    }
}