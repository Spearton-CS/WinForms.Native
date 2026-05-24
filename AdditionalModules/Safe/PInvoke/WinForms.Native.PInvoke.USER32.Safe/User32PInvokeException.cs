namespace WinForms.Native.PInvoke.Safe;

public class User32PInvokeException(string functionName, HResult hresult, string? msg = null, Exception? inner = null) : PInvokeException(functionName, hresult, msg, inner);