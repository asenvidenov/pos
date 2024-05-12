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
    public partial class FormTouchLastReceipts : Form
    {
        //0 за дубликат
        //1 за сторно
        private int ActOption;
        public FormTouchLastReceipts(int Option)
        {
            ActOption = Option;
            InitializeComponent();
            LastReceipt();
        }

        private void LastReceipt()
        {
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand
            {
                Connection = Globals.PosCnn
            };
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_RET_LastReceipts";
            cmd.Parameters.AddWithValue("@FP", FP.FiscalMemoryNumber);
            cmd.Parameters.AddWithValue("@DateFrom", datefrom.Value.ToString("yyyy-MM-dd"));
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.SelectCommand = cmd;
            dataGridView1.DataSource = "";
            try
            {
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "ДАТА И ЧАС";
                dataGridView1.Columns[2].HeaderText = "ОПЕРАТОР";
                dataGridView1.Columns[3].HeaderText = "СУМА";
                dataGridView1.Columns[4].Visible = false;
            }
            catch
            {
                MessageBox.Show("ГРЕШКА!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LastReceipt();
        }

        private void dataGridView1_CellDblClick(object sender, DataGridViewCellEventArgs e)
        {
            if(ActOption==0)
            {
                Globals.OrderID = Convert.ToInt64(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString());
                new FormTouchCopy().ShowDialog();
            }
            else
            {
                Globals.OrderID = Convert.ToInt64(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString());
                Globals.OrderSum = Convert.ToSingle(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                //опция 3 - сторниране на вече приключена сметка
                new FormTouchAdmin(3).ShowDialog();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
