using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pos
{
    public partial class FormTouchOps : Form
    {
        public FormTouchOps()
        {
            InitializeComponent();
            InitOps();
        }
        private void InitOps()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT OpID, OpName,OpFName,OpApp FROM posOps WHERE RoleEnd>=GETDATE() or RoleEnd is Null";
            SqlDataReader rst = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            if (rst.HasRows)
            {
                while (rst.Read())
                {
                    dataGridView1.Rows.Add(rst.GetInt32(0).ToString(), rst.GetString(1), rst.GetString(2), rst.GetString(3));
                }
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(btnEdit);
                btnEdit.HeaderText = "РЕДАКЦИЯ";
                btnEdit.Text = "РЕДАКЦИЯ";
                btnEdit.Name = "btnEdit";
                btnEdit.UseColumnTextForButtonValue = true;
                DataGridViewButtonColumn btnReport = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(btnReport);
                btnReport.HeaderText = "СПРАВКИ";
                btnReport.Text = "СПРАВКА";
                btnReport.Name = "btnReport";
                btnReport.UseColumnTextForButtonValue = true;
            }
            rst.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if(e.ColumnIndex==4)
                {
                    new FormTouchOpEdit().ShowDialog();
                }
                if (e.ColumnIndex == 5)
                {
                    new FormTouchReport().ShowDialog();
                }
            }

        }
    }


}
