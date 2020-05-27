using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
	[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
	public static extern IntPtr GetFocus();
	 
	[DllImport("user32.dll")]
	public static extern IntPtr GetForegroundWindow();
	 
	[DllImport("user32.dll")]
	public static extern IntPtr SetForegroundWindow(IntPtr hWnd);
	 
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	static extern bool PostMessage(IntPtr hWnd, int Msg, char wParam, int lParam);
	 
	[DllImport("user32")]
	public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
	 
	[DllImport("user32")]
	public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
	 
	[DllImport("kernel32.dll", SetLastError = true)]
	static extern uint GetCurrentThreadId();
        IntPtr hControl;

        void GetFocusedControl()
	{
	    IntPtr hFocus;
	    IntPtr hFore;
	    uint id = 0;
	    //узнаем в каком окне находится фокус ввода
	    hFore = GetForegroundWindow();
	    //подключаемся к процессу
	    AttachThreadInput(GetWindowThreadProcessId(hFore, out id), GetCurrentThreadId(), true);
	    //получаем хэндл фокуса
	    hFocus = GetFocus();
	    //отключаемся от процесса
	    AttachThreadInput(GetWindowThreadProcessId(hFore, out id), GetCurrentThreadId(), false);
	    hControl = hFocus;
	}
        void pasteText(string text)
	{
	    try
	    {
	        //активизируем окно, которое имело фокус
	        SetForegroundWindow(hControl);
	        int WM_CHAR = 0x0102;
	        //передаем ему текст посимвольно
	        foreach (char ch in text)
	        {
	            PostMessage(hControl, WM_CHAR, ch, 1);
	        }
	    }
	    catch (Exception error)
	    {
	        MessageBox.Show(error.Message);
	    }
	}

        private void button1_Click(object sender, EventArgs e)
        {
            //IntPtr hWnd = FindWindow(null, "Безымянный — Блокнот");
            //IntPtr hWndEdit = FindWindowEx(hWnd, 0, "Edit", null);
            //SendMessage(hWndEdit, WM_CHAR, 0x30, null);
            //pasteText(this.textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //GetFocusedControl();
            //textBox1.Text = hControl.ToString();
        }
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        IntPtr ptr = FindWindow(null, "РПД : (local) - plany : (соединение установлено) : Администратор направления - [2020-2021_09_03_02_ИСиТ_2019_plx_Общий курс железных дорог]");

    [DllImport("user32.dll")]
    static extern IntPtr FindWindowEx(IntPtr parentHandle, int childAfter, string className, string windowTitle);
    [DllImport("user32.dll")]
    static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

    const int WM_CHAR = 0x0102;

        private void button3_Click(object sender, EventArgs e)
        {

            EnumWindows((hWnd, lParam) =>
            {
                if (IsWindowVisible(hWnd) && GetWindowTextLength(hWnd) != 0)
                {
                    string title = GetWindowText(hWnd);
                    if (title.Contains("РПД"))
                    {
                        //string newTitle = "Блокнот-1";
                        target = hWnd;
                        //IntPtr target_hwnd = hWnd;
                        //SetForegroundWindow(target_hwnd);
                        //SendMessage(target_hwnd, WM_SETTEXT, 0, newTitle);

                    }
                }
                return true;
            }, IntPtr.Zero);

            if (target.ToInt32() != 0)

            {

                IntPtr[] child = new IntPtr[15];

                child[0] = WinAPI.GetWindow(target, WinAPI.GetWindow_Cmd.GW_CHILD);
                child[1] = FindWindowEx(target, 0, null, "");
                child[2] = FindWindowEx(child[1], 0, null, null);
                child[3] = FindWindowEx(child[2], 0, null, null);
                child[4] = FindWindowEx(child[3], 0, null, "МУ");
                child[5] = FindWindowEx(child[4], 0, null, null);
                child[6] = FindWindowEx(child[5], 0, null, null);
                child[7] = FindWindowEx(child[6], 0, null, null);


                //MessageBox.Show(child[2].ToString());

                //MessageBox.Show(child[3].ToString() + "-" +GetWindowText(child[3]).ToString() + "-" + child[4].ToString() + "-" + GetWindowText(child[4]).ToString());
                WinAPI.SendMessage(child[7], Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_SETTEXT), 0, textBox1.Text);


                StringBuilder title = new StringBuilder();

                //for (int i = 1; i <= 7; i++)

                //{

                //    child[i] = WinAPI.GetWindow(child[i - 1], WinAPI.GetWindow_Cmd.GW_HWNDNEXT);

                //    WinAPI.SendMessage(child[i - 1], Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_SETTEXT), 0, textBox1.Text);

                //    listBox1.Items.Add(title.ToString());

                //}

            }
        }
        static string GetWindowText(IntPtr hWnd)
        {
            int len = GetWindowTextLength(hWnd) + 1;
            StringBuilder sb = new StringBuilder(len);
            len = GetWindowText(hWnd, sb, len);
            return sb.ToString(0, len);
        }
       
        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true)]
     
        static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, string lParam);
        private const int WM_SETTEXT = 0xC;
        IntPtr target;
        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
