namespace WinForms.Native.PInvoke;

public enum GdiRegionType : int
{
    ERROR = 0,         // Operation failed
    NULLREGION = 1,    // Region is empty
    SIMPLEREGION = 2,  // Region is a single rectangle
    COMPLEXREGION = 3  // Region is more than one rectangle
}