using System;
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


        private void button2_Click(object sender, EventArgs e)
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


    }

    }


