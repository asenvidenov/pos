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
    public partial class FormTouchSellReverse : Form
    {
        private Int64 ReOrderID;
        private Int64 IDToAdd;
        private Int64 IDToRemove;
        //private SqlDataAdapter OrderAdapter = new SqlDataAdapter();
        //private SqlDataAdapter ReOrderAdapter = new SqlDataAdapter();
        //private DataTable OrderTable = new DataTable();
        //private DataTable ReOrderTable = new DataTable();

        public FormTouchSellReverse(Int64 newOrderID)
        {
            ReOrderID = newOrderID;
            InitializeComponent();
            InitDB();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDToAdd= Convert.ToInt64(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IDToRemove= Convert.ToInt64(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[0].Value.ToString());
        }


        private void InitDB()
        {
            dataGridView1.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView1.RowTemplate.Height = 40;
            dataGridView3.RowTemplate.Height = 40;

            SqlCommand cmd = new SqlCommand
            {
                Connection = Globals.PosCnn
            };
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPRetOrderDetailsChrono";
            cmd.Parameters.AddWithValue("@OrderID", Globals.OrderID);
            //OrderAdapter.SelectCommand = cmd;
            //dataGridView1.DataSource = "";
            //try
            //{
            //    OrderAdapter.Fill(OrderTable);
            //    dataGridView1.DataSource = OrderTable;
            //    dataGridView1.Columns[0].Visible = false;
            //    dataGridView1.Columns[1].HeaderText = "АРТИКУЛ";
            //    dataGridView1.Columns[2].HeaderText = "МОД";
            //    dataGridView1.Columns[3].HeaderText = "БРОЙ";
            //    dataGridView1.Columns[3].Width = 40;
            //    dataGridView1.Columns[4].HeaderText = "ЦЕНА";
            //    dataGridView1.Columns[4].Width = 80;
            //    dataGridView1.RowTemplate.Height = 40;
            //    dataGridView1.Refresh();
            //}
            //catch
            //{
            //    MessageBox.Show("ГРЕШКА!");
            //}
            SqlDataReader rst = cmd.ExecuteReader();
                if(rst.HasRows)
            {
            while(rst.Read())
            {
                dataGridView1.Rows.Add(rst.GetInt64(0).ToString(), rst.GetString(1), rst.GetString(2), rst.GetInt32(3).ToString(), rst.GetSqlSingle(4).ToString(), rst.GetInt32(5).ToString());
            }

            }

            rst.Close();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@OrderID", ReOrderID);
            //ReOrderAdapter.SelectCommand = cmd;
            //dataGridView3.DataSource = "";
            //try
            //{
            //    ReOrderAdapter.Fill(ReOrderTable);
            //    dataGridView3.DataSource = ReOrderTable;
            //    dataGridView1.Columns[0].Visible = false;
            //    dataGridView1.Columns[1].HeaderText = "АРТИКУЛ";
            //    dataGridView1.Columns[2].HeaderText = "МОД";
            //    dataGridView1.Columns[3].HeaderText = "БРОЙ";
            //    dataGridView1.Columns[3].Width = 40;
            //    dataGridView1.Columns[4].HeaderText = "ЦЕНА";
            //    dataGridView1.Columns[4].Width = 80;
            //    dataGridView1.RowTemplate.Height = 40;
            //    dataGridView1.Refresh();
            //}
            //catch
            //{

            //}
            rst = cmd.ExecuteReader();
            if (rst.HasRows)
            {
                while (rst.Read())
                {
                    dataGridView3.Rows.Add(rst.GetInt64(0).ToString(), rst.GetString(1), rst.GetString(2), rst.GetInt32(3).ToString(), rst.GetSqlSingle(4).ToString(), rst.GetInt32(5).ToString());
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IDToAdd>0)
            {
                int DBCnt = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());
                if (DBCnt > 0)
                {
                    dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value = DBCnt - 1;
                    int rows3 = 0;
                    foreach (DataGridViewRow r in dataGridView3.Rows)
                    {
                        if (r.Cells[0].Value.ToString() == IDToAdd.ToString())
                        {
                            rows3 += 1;
                            r.Cells[3].Value = int.Parse(r.Cells[3].Value.ToString()) + 1;
                        }
                    }
                    if (rows3 == 0)
                    {
                        dataGridView3.Rows.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString(),
                            1, dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString());
                    }
                    
                }
                //SqlCommand cmd = new SqlCommand
                //{
                //    Connection = Globals.PosCnn
                //};
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "SP_Order_Split";
                //cmd.Parameters.AddWithValue("@ID", IDToAdd);
                //cmd.Parameters.AddWithValue("@OrderID", Globals.OrderID);
                //cmd.Parameters.AddWithValue("@NewOrderID", ReOrderID);
                //cmd.ExecuteNonQuery();
                IDToAdd = 0;
                //InitDB();
                //var query = OrderTable.AsEnumerable().Where(myRow => myRow.Field<Int64>(0) == IDToAdd).FirstOrDefault();
                //if (query.Field<int>(3) > 0)
                //{
                //    OrderTable.
                //    query.Field<int>(3)= query.Field<int>(3)-1;
                //    ReOrderTable.ImportRow(query);
                //
                //    dataGridView3.DataSource = ReOrderTable;
                //    dataGridView1.Columns[0].Visible = false;
                //    dataGridView1.Columns[1].HeaderText = "АРТИКУЛ";
                //    dataGridView1.Columns[2].HeaderText = "МОД";
                //    dataGridView1.Columns[3].HeaderText = "БРОЙ";
                //    dataGridView1.Columns[3].Width = 40;
                //    dataGridView1.Columns[4].HeaderText = "ЦЕНА";
                //    dataGridView1.Columns[4].Width = 80;
                //    dataGridView1.RowTemplate.Height = 40;
                //    dataGridView1.Refresh();
                //}
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
                int DBCnt = int.Parse(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[3].Value.ToString());
                DataGridViewRow r3 = dataGridView3.Rows[dataGridView3.CurrentRow.Index];

                    dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[3].Value = DBCnt - 1;
                    int rows1 = 0;
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        rows1 += 1;
                        if (r.Cells[0].Value.ToString() == IDToRemove.ToString())
                        {
                            r.Cells[3].Value = int.Parse(r.Cells[3].Value.ToString()) + 1;
                        }
                    }
                if (DBCnt == 1)
                {
                    dataGridView3.Rows.Remove(r3);
                }
                //SqlCommand cmd = new SqlCommand
                //{
                //    Connection = Globals.PosCnn
                //};
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "SP_Order_Split";
                //cmd.Parameters.AddWithValue("@D", IDToRemove);
                //cmd.Parameters.AddWithValue("@OrderID", ReOrderID);
                //cmd.Parameters.AddWithValue("@NewOrderID", Globals.OrderID);
                //cmd.ExecuteNonQuery();

                IDToRemove = 0;
                //InitDB();
            }
            else
            {
                MessageBox.Show("ИЗБЕРЕТЕ РЕД ЗА ПРЕНОС!", "ГРЕШКА!", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = Globals.PosCnn
            };
            cmd.CommandType = CommandType.Text;
            foreach(DataGridViewRow r in dataGridView3.Rows)
            {
                if(r.Index>=0)
                {
                    cmd.CommandText = "INSERT INTO posOrderDetails (OrderID, OpID, GoodsID, Modif, Cnt, Annul, CashPrice) VALUES(" + ReOrderID.ToString()+", "+Globals.OpID.ToString()+", "+r.Cells[5].Value.ToString()+", '"+ r.Cells[2].Value.ToString() + "', 0, " + r.Cells[3].Value.ToString()+", "+ r.Cells[4].Value.ToString()+")";
                    cmd.ExecuteNonQuery();
                }
            }
            if(dataGridView3.Rows.Count>0)
            {
                cmd.Dispose();
                cmd.Connection = Globals.PosCnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Finalize_ReOrder";
                cmd.Parameters.AddWithValue("@REOrderID", ReOrderID);
                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                if ((int)returnParameter.Value==2)
                {
                    MessageBox.Show("ГРЕШКА!");
                    return;
                }
                //Отпечатване на СТОРНО БЕЛЕЖКА
                //FP.execute_
            }
            this.Close();
        }

        private void UpdateGrids()
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int DBCnt = int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString());
            int rows3 = 0;
            foreach (DataGridViewRow r in dataGridView3.Rows)
            {
                if (r.Cells[0].Value.ToString() == IDToAdd.ToString())
                {
                    rows3 += 1;
                    r.Cells[3].Value = int.Parse(r.Cells[3].Value.ToString()) + DBCnt;
                }
            }
            if (rows3 == 0)
            {
                dataGridView3.Rows.Add(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString(),
                    DBCnt, dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString());
            }
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value = 0;
            IDToAdd = 0;
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int DBCnt = int.Parse(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[3].Value.ToString());
            DataGridViewRow r3 = dataGridView3.Rows[dataGridView3.CurrentRow.Index];

            int rows1 = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                rows1 += 1;
                if (r.Cells[0].Value.ToString() == IDToRemove.ToString())
                {
                    r.Cells[3].Value = int.Parse(r.Cells[3].Value.ToString()) + DBCnt;
                }
            }
            dataGridView3.Rows.Remove(r3);
            IDToRemove = 0;
        }
    }
}
