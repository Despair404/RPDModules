﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        IntPtr target;

        private void button2_Click(object sender, EventArgs e)
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
                string a = WinAPI.GetControlText(child[7]);
                WinAPI.SendMessage(child[7], Convert.ToInt32(WinAPI.GetWindow_Cmd.WM_SETTEXT), 0, a + textBox1.Text);
                WinAPI.SetForegroundWindow(child[7]);
                var win = WinAPI.FindWindowsWithText("MenuStrip");
                foreach(var i in win)
                {
                    listBox1.Items.Add(i);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        int rowIndexFromMouseDown;
        int rowIndexOfItemUnderMouseToDrop;
        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop =
                dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = (DataGridViewRow)e.Data.GetData(typeof(DataGridViewRow));
                // find the row to move in the datasource:
                DataRow oldrow = ((DataRowView)rowToMove.DataBoundItem).Row;
                // clone it:
                //    DataRow newrow = bsPeople.NewRow();
                //    newrow.ItemArray = oldrow.ItemArray;
                //    bsPeople.Rows.InsertAt(newrow, rowIndexOfItemUnderMouseToDrop);
                //    bsPeople.Rows.Remove(oldrow);
            }
        }
        List<IntPtr> ptrs = new List<IntPtr>();
        public bool EnumChildProc(IntPtr hwnd, IntPtr lParam)
        {
            ptrs.Add(hwnd);

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WinAPI.EnumWindows((hWnd, lParam) =>
            {
                if (WinAPI.IsWindowVisible(hWnd) && WinAPI.GetWindowTextLength(hWnd) != 0)
                {
                    string title = WinAPI.GetWindowText(hWnd);
                    if (title.Contains("РПД"))
                    {
                        target = hWnd;
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
                child[4] = WinAPI.FindWindowEx(child[3], 0, null, "Титул");
                child[5] = WinAPI.FindWindowEx(child[4], 0, null, null);
                child[6] = WinAPI.FindWindowEx(child[5], 0, null, null);

                
                string a = WinAPI.GetControlText(child[7]);
                WinAPI.SetForegroundWindow(child[7]);
                var lpEnumFunc = new WinAPI.EnumWindowProc(EnumChildProc);
                WinAPI.EnumChildWindows(child[6], lpEnumFunc, IntPtr.Zero);
                string connectionString = @"Data Source=.;Initial Catalog=plany;Integrated Security=True";

                // Создание подключения
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    // Открываем подключение
                    connection.Open();
                    string sql = "SELECT Код FROM Планы WHERE ИмяФайла='" + WinAPI.GetControlText(ptrs[11])+"'";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    object id = 0;
                    while (reader.Read()) 
                    {
                        id = reader.GetValue(0);
                    }
                    reader.Close();
                    sql = "SELECT * FROM ПланыСтроки WHERE Дисциплина='"+ WinAPI.GetControlText(ptrs[2])+"' AND КодПлана=" + id;
                    command = new SqlCommand(sql, connection);
                    reader = command.ExecuteReader();
                    object idD = 0;
                    while (reader.Read()) 
                    {
                        idD = reader.GetValue(0);
                        listBox1.Items.Add(reader.GetValue(0));
                    }



                    //sql = "SELECT * FROM СправочникВидыРабот WHERE КодТипРабот=7 AND Код= ANY(SELECT DISTINCT КодВидаРаботы FROM ПланыНовыеЧасы where КодОбъекта=" + idD+")";
                    sql = "SELECT * FROM СправочникВидыРабот WHERE КодТипРабот=7 AND Код= ANY(SELECT DISTINCT КодВидаРаботы FROM ПланыНовыеЧасы where КодОбъекта=" + idD+")";
                    reader.Close();
                    command = new SqlCommand(sql, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetValue(1));
                    }


                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // закрываем подключение
                    connection.Close();
                }

            }

        }
    }
}