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
        
	
        IntPtr hControl;
        IntPtr target;

        void GetFocusedControl()
	{
	    IntPtr hFocus;
	    IntPtr hFore;
	    uint id = 0;
	    //узнаем в каком окне находится фокус ввода
	    hFore = WinAPI.GetForegroundWindow();
            //подключаемся к процессу
            WinAPI.AttachThreadInput(WinAPI.GetWindowThreadProcessId(hFore, out id), WinAPI.GetCurrentThreadId(), true);
	    //получаем хэндл фокуса
	    hFocus = WinAPI.GetFocus();
            //отключаемся от процесса
            WinAPI.AttachThreadInput(WinAPI.GetWindowThreadProcessId(hFore, out id), WinAPI.GetCurrentThreadId(), false);
	    hControl = hFocus;
	}
        void pasteText(string text)
	{
	    try
	    {
                //активизируем окно, которое имело фокус
                WinAPI.SetForegroundWindow(hControl);
	        int WM_CHAR = 0x0102;
	        //передаем ему текст посимвольно
	        foreach (char ch in text)
	        {
                    WinAPI.PostMessage(hControl, WM_CHAR, ch, 1);
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
   

        private void button3_Click(object sender, EventArgs e)
        {

            WinAPI.EnumWindows((hWnd, lParam) =>
            {
                if (WinAPI.IsWindowVisible(hWnd) && WinAPI.GetWindowTextLength(hWnd) != 0)
                {
                    string title = WinAPI.GetWindowText(hWnd);
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
                child[1] = WinAPI.FindWindowEx(target, 0, null, "");
                child[2] = WinAPI.FindWindowEx(child[1], 0, null, null);
                child[3] = WinAPI.FindWindowEx(child[2], 0, null, null);
                child[4] = WinAPI.FindWindowEx(child[3], 0, null, "МУ");
                child[5] = WinAPI.FindWindowEx(child[4], 0, null, null);
                child[6] = WinAPI.FindWindowEx(child[5], 0, null, null);
                child[7] = WinAPI.FindWindowEx(child[6], 0, null, null);
                string a =WinAPI.GetControlText(child[7]);
                WinAPI.SendMessage(child[7], Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_SETTEXT), 0, a + textBox1.Text);
                WinAPI.SetForegroundWindow(child[7]);

                StringBuilder title = new StringBuilder();

                //for (int i = 1; i <= 7; i++)

                //{

                //    child[i] = WinAPI.GetWindow(child[i - 1], WinAPI.GetWindow_Cmd.GW_HWNDNEXT);

                //    WinAPI.SendMessage(child[i - 1], Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_SETTEXT), 0, textBox1.Text);

                //    listBox1.Items.Add(title.ToString());

                //}

            }
        }

       
        
       
    }
}
