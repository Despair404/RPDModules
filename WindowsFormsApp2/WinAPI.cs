using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace RPDModule
{
    public static class WinAPI
    {

        [DllImport("user32.dll", SetLastError = true)]

        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll", SetLastError = true)]

        public static extern IntPtr GetWindow(IntPtr HWnd, GetWindow_Cmd cmd);


        //[DllImport("user32.dll", CharSet = CharSet.Auto)]

        //public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, [Out] StringBuilder lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, char wParam, int lParam);

        [DllImport("user32")]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, int childAfter, string className, string windowTitle);

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        private const int WM_SETTEXT = 0xC;
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hwnd, EnumWindowProc callback, IntPtr lParam);


        public enum GetWindow_Cmd : uint

        {

            GW_HWNDFIRST = 0,

            GW_HWNDLAST = 1,

            GW_HWNDNEXT = 2,

            GW_HWNDPREV = 3,

            GW_OWNER = 4,

            GW_CHILD = 5,

            GW_ENABLEDPOPUP = 6,

            WM_GETTEXT = 0x000D,

            WM_SETTEXT = 0xC,
            WM_GETTEXTLENGTH = 0x000E


        }
        public static string GetControlText(IntPtr hWnd)
        {

            // Get the size of the string required to hold the window title (including trailing null.) 
            Int32 titleSize = SendMessage((int)hWnd, Convert.ToInt32(GetWindow_Cmd.WM_GETTEXTLENGTH), 0, 0).ToInt32();

            // If titleSize is 0, there is no title so return an empty string (or null)
            if (titleSize == 0)
                return String.Empty;

            StringBuilder title = new StringBuilder(titleSize + 1);

            SendMessage(hWnd, (int)GetWindow_Cmd.WM_GETTEXT, title.Capacity, title);

            return title.ToString();
        }
        public static string GetWindowText(IntPtr hWnd)
        {
            int len = WinAPI.GetWindowTextLength(hWnd) + 1;
            StringBuilder sb = new StringBuilder(len);
            len = WinAPI.GetWindowText(hWnd, sb, len);
            return sb.ToString(0, len);
        }
        public static IEnumerable<IntPtr> FindWindows(EnumWindowsProc filter)
        {
            IntPtr found = IntPtr.Zero;
            List<IntPtr> windows = new List<IntPtr>();

            EnumWindows(delegate (IntPtr wnd, IntPtr param)
            {
                if (filter(wnd, param))
                {
                    // only add the windows that pass the filter
                    windows.Add(wnd);
                }

                // but return true here so that we iterate all windows
                return true;
            }, IntPtr.Zero);

            return windows;
        }

        /// <summary> Find all windows that contain the given title text </summary>
        /// <param name="titleText"> The text that the window title must contain. </param>
        public static IEnumerable<IntPtr> FindWindowsWithText(string titleText)
        {
            return FindWindows((wnd, param) => GetWindowText(wnd).Contains(titleText));
        }
    }
}
