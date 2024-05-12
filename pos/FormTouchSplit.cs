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
    public partial class FormTouchSplit : Form
    {
        private SqlConnection cnn;
        private Int64 NewOrderID;
        private Int32 IDToAdd;
        private Int32 IDToRemove;

        public FormTouchSplit(Int64 newOrderID)
        {
            NewOrderID = newOrderID;
            InitializeComponent();
            cnn = Globals.PosCnn;
            InitDB();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDToAdd= Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDToRemove= Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[0].Value.ToString());
        }


        private void InitDB()
        {
            dataGridView1.Rows.Clear();
            dataGridView3.Rows.Clear();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPRetOrderDetailsChrono";
            cmd.Parameters.AddWithValue("OrderID", Globals.OrderID);
            SqlDataReader rst = cmd.ExecuteReader();
                if(rst.HasRows)
            {
                while(rst.Read())
                {
                    dataGridView1.Rows.Add(rst.GetInt64(0).ToString(), rst.GetString(1), rst.GetString(2), rst.GetInt32(3).ToString(), rst.GetSqlSingle(4).ToString());
                }
            }
            rst.Close();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("OrderID", NewOrderID);
            rst = cmd.ExecuteReader();
            if (rst.HasRows)
            {
                while (rst.Read())
                {
                    dataGridView3.Rows.Add(rst.GetInt64(0).ToString(), rst.GetString(1), rst.GetString(2), rst.GetInt32(3).ToString(), rst.GetSqlSingle(4).ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IDToAdd>0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Order_Split";
                cmd.Parameters.AddWithValue("ID", IDToAdd);
                cmd.Parameters.AddWithValue("OrderID", Globals.OrderID);
                cmd.Parameters.AddWithValue("NewOrderID", NewOrderID);
                cmd.ExecuteNonQuery();
                IDToAdd = 0;
                InitDB();
            }
            else
            {
                MessageBox.Show("ИЗБЕРЕТЕ РЕД ЗА ПРЕНОС!","ГРЕШКА!",MessageBoxButtons.OK);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (IDToRemove > 0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Order_Split";
                cmd.Parameters.AddWithValue("ID", IDToRemove);
                cmd.Parameters.AddWithValue("OrderID", NewOrderID);
                cmd.Parameters.AddWithValue("NewOrderID", Globals.OrderID);
                cmd.ExecuteNonQuery();
                IDToRemove = 0;
                InitDB();
            }
            else
            {
                MessageBox.Show("ИЗБЕРЕТЕ РЕД ЗА ПРЕНОС!", "ГРЕШКА!", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (System.Windows.Forms.Application.OpenForms["FormTouch"] as FormTouch).InitOrder();
            this.Close();
        }
    }
}
