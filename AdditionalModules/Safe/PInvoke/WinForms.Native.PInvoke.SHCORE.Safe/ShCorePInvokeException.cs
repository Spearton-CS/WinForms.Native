namespace WinForms.Native.PInvoke.Safe;

public class ShCorePInvokeException(string functionName, HResult hresult, string? msg = null, Exception? inner = null) : PInvokeException(functionName, hresult, msg, inner);