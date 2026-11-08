using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ScrennTimeTracker;

public class TrackProcess
{
    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern UInt32 GetWindowThreadProcessId(IntPtr hwnd, ref Int32 pid);

    public static void CheckCurrentProcess()
    {
        IntPtr h = GetForegroundWindow();
        int pid = 0;
        GetWindowThreadProcessId(h, ref pid);
        Process p = Process.GetProcessById(pid);
        Console.Write("pid: {0}; window: {1}", pid, p.MainWindowTitle);
    }
}