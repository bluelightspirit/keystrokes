using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    [DllImport("libX11.so.6")]
    private static extern IntPtr XOpenDisplay(IntPtr display);

    [DllImport("libX11.so.6")]
    private static extern int XCloseDisplay(IntPtr display);

    [DllImport("libX11.so.6")]
    private static extern uint XKeysymToKeycode(IntPtr display, uint keysym);

    [DllImport("libXtst.so.6")]
    private static extern void XTestFakeKeyEvent(IntPtr display, uint keycode, bool is_press, ulong delay);

    [DllImport("libX11.so.6")]
    private static extern void XFlush(IntPtr display);

    // 👇 Private helper method INSIDE the class
    private static void SendChar(IntPtr display, char c)
    {
        bool needsShift = char.IsUpper(c) || "!@#$%^&*()_+{}:\"<>?|~".Contains(c);

        char baseChar = needsShift ? char.ToLower(c) : c;
        uint keysym = (uint)baseChar;
        uint keycode = XKeysymToKeycode(display, keysym);

        if (needsShift)
        {
            uint shiftKeycode = XKeysymToKeycode(display, 0xFFE1); // XK_Shift_L
            XTestFakeKeyEvent(display, shiftKeycode, true, 0);
        }

        XTestFakeKeyEvent(display, keycode, true, 0);
        XTestFakeKeyEvent(display, keycode, false, 0);

        if (needsShift)
        {
            uint shiftKeycode = XKeysymToKeycode(display, 0xFFE1);
            XTestFakeKeyEvent(display, shiftKeycode, false, 0);
        }

        XFlush(display);
    }

    static void Main(string[] args)
    {
        string text = "printThis";
        IntPtr display = XOpenDisplay(IntPtr.Zero);
        if (display == IntPtr.Zero)
        {
            Console.WriteLine("Cannot open X display");
            return;
        }

        foreach (char c in text)
        {
            SendChar(display, c);
            Thread.Sleep(50);
        }

        XCloseDisplay(display);
    }
}

