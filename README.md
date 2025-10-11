# How do you run this?
## Preface: This only has been tested to run in Windows 11. It may work on Windows 10.
### To run this, Visual Studio has to be installed with the 4.8 .NET Framework (4.8.1 / 4.7.2 / others have not been tested), or you can run this C# code through JitBit Macro Recorder by copying the Program.cs code and uncommenting the ```IntPtr``` to ```Thread.Sleep(500)``` segment to work with a hardcoded window. If there is no hardcoded Window in JitBit Macro Recorder, it will likely do unexpected things such as trying to print a page in the Brave browser.
### Cloning this repository (```git clone https://github.com/bluelightspirit/keystrokes```), opening the project through the .sln file (```windows-macros.sln``` which may be in the windows-macros or keystrokes subdirectory after cloning), then running ```Program.cs``` has worked when bluelightspirit tested this on an external computer.

# What does this do?
### This converts a string to text to write on Windows. This is useful for places that don't accept writing a whole bunch of text instantly or copy and pasting.

# Note
### More features may be made in the future, such as not having to go in the code to edit the string you want to type out.
### The commented out code (IntPtr wordHandle and beyond, not the "// Send character" after) allows you to focus on a window before typing something. This has to be hardcoded to an actual process open in your system though. This is a very barebones version.
### Using the commented out appears to be required in Visual Studio 2017 in bluelightspirit's tests (else nothing will be written), but not required in Visual Studio 2022 (it can write to the C# code editor naturally here).
