using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

public class Program 
{
    [DllImport("user32.dll")]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);

    public static void Main()
    {
        //IntPtr wordHandle = FindWindow(null, "Word"); // Adjust title
        //if (wordHandle == IntPtr.Zero)
        //{
        //    Console.WriteLine("Word not found.");
        //    return;
        //}

        //SetForegroundWindow(wordHandle);
        //Thread.Sleep(500); // Let Word settle

        string text = "printThis";
        string moreText = "+^%(){}[]~";
        foreach (char c in text)
        {
            string key;
            if (c == '+')
                key = "{+}";
            else if (c == '^')
                key = "{^}";
            else if (c == '%')
                key = "{%}";
            else if (c == '(')
                key = "{(}";
            else if (c == ')')
                key = "{)}";
            else if (c == '{')
                key = "{{}";
            else if (c == '}')
                key = "{}}";
            else if (c == '[')
                key = "{[}";
            else if (c == ']')
                key = "{]}";
            else if (c == '~')
                key = "{~}";
            else
                key = c.ToString();

            SendKeys.SendWait(key); // Send character
            Thread.Sleep(50);
        }
    }
}