using InputSimulatorStandard;
using InputSimulatorStandard.Native;

namespace Gaten.Net.Windows
{
    public class InputSimulator
    {
        public static int MouseActivityInterval = 0;
        public static int KeyboardActivityInterval = 0;
        private static readonly KeyboardSimulator keyboardSimulator = new();
        private static readonly MouseSimulator mouseSimulator = new();

        public static void MouseMove(int x, int y) => WinApi.SetCursorPos(x, y);
        public static void MouseClick() => mouseSimulator.LeftButtonClick();
        public static void MouseClick(int x, int y)
        {
            MouseMove(x, y);
            Thread.Sleep(MouseActivityInterval);
            mouseSimulator.LeftButtonClick();
        }
        public static void MouseDoubleClick() => mouseSimulator.LeftButtonDoubleClick();
        public static void MouseDoubleClick(int x, int y)
        {
            MouseMove(x, y);
            Thread.Sleep(MouseActivityInterval);
            mouseSimulator.LeftButtonDoubleClick();
        }
        public static void MouseRightClick() => mouseSimulator.RightButtonClick();
        public static void MouseRightClick(int x, int y)
        {
            MouseMove(x, y);
            Thread.Sleep(MouseActivityInterval);
            mouseSimulator.RightButtonClick();
        }
        public static void KeyPress(VirtualKeyCode keyCode) => keyboardSimulator.KeyPress(keyCode);
        public static void KeyPress(Modifiers modifiers, VirtualKeyCode keyCode) 
        {
            if (modifiers.HasFlag(Modifiers.Ctrl))
            {
                keyboardSimulator.KeyDown(VirtualKeyCode.CONTROL);
            }
            if (modifiers.HasFlag(Modifiers.Alt))
            {
                keyboardSimulator.KeyDown(VirtualKeyCode.MENU);
            }
            if (modifiers.HasFlag(Modifiers.Shift))
            {
                keyboardSimulator.KeyDown(VirtualKeyCode.SHIFT);
            }
            if (modifiers.HasFlag(Modifiers.Window))
            {
                keyboardSimulator.KeyDown(VirtualKeyCode.LWIN);
            }
            Thread.Sleep(KeyboardActivityInterval);
            keyboardSimulator.KeyPress(keyCode);
            Thread.Sleep(KeyboardActivityInterval);
            if (modifiers.HasFlag(Modifiers.Ctrl))
            {
                keyboardSimulator.KeyUp(VirtualKeyCode.CONTROL);
            }
            if (modifiers.HasFlag(Modifiers.Alt))
            {
                keyboardSimulator.KeyUp(VirtualKeyCode.MENU);
            }
            if (modifiers.HasFlag(Modifiers.Shift))
            {
                keyboardSimulator.KeyUp(VirtualKeyCode.SHIFT);
            }
            if (modifiers.HasFlag(Modifiers.Window))
            {
                keyboardSimulator.KeyUp(VirtualKeyCode.LWIN);
            }
        }
        public static void Sleep(int milliseconds) => Thread.Sleep(TimeSpan.FromMilliseconds(milliseconds));
    }

    [Flags]
    public enum Modifiers
    {
        None = 0x0,
        Ctrl = 0x1,
        Alt = 0x2,
        Shift = 0x4,
        Window = 0x8
    }
}
