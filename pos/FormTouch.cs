using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pos
{
    public partial class FormTouch : Form
    {
        private SqlConnection cnn;
        private Boolean isStorno = false;
        private Single tmpOrderSum = 0;
        public FormTouch()
        {
            InitializeComponent();
            //InitCnn();
            InitPanel(0);
            InitOrder();
            splitContainer1.Panel1Collapsed = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CashLogin().Show();
            this.Close();
        }

        private void InitPanel(int GParent)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT GoodsID, CashName, isGroup FROM posGoods WHERE GParent = " + GParent;
            SqlDataReader rst;
            if (GParent == 0)
            {
                flowLayoutPanel2.Controls.Clear();
            }

            flowLayoutPanel1.Controls.Clear();
            try
            {
                rst = cmd.ExecuteReader();
                if (rst.HasRows)
                {
                    while (rst.Read())
                    {
                        if (GParent == 0)
                        {
                            Button btnMainID = new Button();
                            btnMainID.AutoSize = true;
                            btnMainID.AutoSizeMode = 0;
                            btnMainID.AutoEllipsis = false;
                            btnMainID.MinimumSize = new Size(50, 50);
                            btnMainID.MaximumSize = new Size(100, 100);
                            btnMainID.BackColor = Color.AliceBlue;
                            btnMainID.Text = rst.GetString(1);
                            btnMainID.Tag = rst.GetInt32(0);
                            btnMainID.Click += new EventHandler(Button_Click);
                            this.flowLayoutPanel2.Controls.Add(btnMainID);
                        }
                        else
                        {
                            Button btnGoodsID = new Button();
                            btnGoodsID.AutoSize = true;
                            btnGoodsID.AutoSizeMode = 0;
                            btnGoodsID.AutoEllipsis = false;
                            btnGoodsID.MinimumSize = new Size(50, 50);
                            btnGoodsID.MaximumSize = new Size(100, 100);
                            btnGoodsID.BackColor = Color.AliceBlue;
                            btnGoodsID.Text = rst.GetString(1);
                            btnGoodsID.Tag = rst.GetInt32(0);

                            if (!rst.GetBoolean(2))
                            {
                                btnGoodsID.Click += new EventHandler(Button_Add_Click);
                            }
                            else
                            {
                                btnGoodsID.Click += new EventHandler(Button_Click);
                            }

                            this.flowLayoutPanel1.Controls.Add(btnGoodsID);
                        }

                    }
                }

                rst.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Button_Click(object sender, object e)
        {
            
            var button = (Button)sender;
            var tag = (int)button.Tag;
            //MessageBox.Show(tag.ToString());
            InitPanel(tag);
        }
        private void Button_Add_Click(object sender, object e)
        {
            if (isStorno) { return; }
            button1.Enabled = false;
            var button = (Button)sender;
            var tag = (int)button.Tag;
            string cashname = "";
            //MessageBox.Show(tag.ToString());
            Globals.CurrGoodsID = tag;
            foreach (Control ctl in flowLayoutPanel1.Controls)
            {
                if (ctl is Button && (int)ctl.Tag == tag)
                {
                    cashname = ctl.Text;
                }
            }
            new FormTouchAddGood(tag, cashname).ShowDialog();
        }

        public void InitOrder()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPRetOrderDetails";
            cmd.Parameters.AddWithValue("OrderID", Globals.OrderID);
            SqlDataReader rst = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.BackgroundColor=Color.White;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            tmpOrderSum = 0;
            if (rst.HasRows)
            {

                while (rst.Read())
                {
                    dataGridView1.Rows.Add(rst.GetInt32(0), rst.GetString(1), rst.GetString(2), rst.GetInt32(3).ToString(), rst.GetSqlSingle(4).ToString());
                    tmpOrderSum = tmpOrderSum + (rst.GetInt32(3) * (Single)rst.GetSqlSingle(4));
                }
                try
                {
                    dataGridView1.Columns.RemoveAt(5);
                }
                catch { }
                finally
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    dataGridView1.Columns.Add(btn);
                    btn.HeaderText = "ОПЦИИ";
                    btn.Text = "ДОБАВИ";
                    btn.Name = "btn";
                    btn.UseColumnTextForButtonValue = true;
                }
            }
            rst.Close();
            lblOrderSum.Text = String.Format( "{0:C2}",Math.Round(tmpOrderSum, 2));
        }
        private Boolean InitCnn()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = Globals.PosCnnString;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (cnn.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void InitStorno()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPRetOrderDetailsChrono";
            cmd.Parameters.AddWithValue("OrderID", Globals.OrderID);
            SqlDataReader rst = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.RemoveAt(5);
            dataGridView1.BackgroundColor = Color.Red;
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.Red;
            lblOrderSum.Text = "";
            if (rst.HasRows)
            {

                while (rst.Read())
                {
                    dataGridView1.Rows.Add(rst.GetInt64(0), rst.GetString(1), rst.GetString(2), rst.GetInt32(3).ToString(), rst.GetSqlSingle(4).ToString());
                }
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView1.Columns.Add(btn);
                btn.HeaderText = "ОПЦИИ";
                btn.Text = "СТОРНО";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
            }
            rst.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (!isStorno)
            {
                isStorno = true;
                button5.BackgroundImage = Properties.Resources.btnRed;
                InitStorno();
            }
            else
            {
                isStorno = false;
                button5.BackgroundImage = Properties.Resources._298px_HILLBLU_button_background_svg;
                InitOrder();
            }
        }
        
        private void HeaderDblClick(Object sender, DataGridViewCellMouseEventArgs e)
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new CashLogin().Show();
            this.Close();
        }

        private void CellDblClick(Object sender, DataGridViewCellEventArgs e)
        {
            if (isStorno)
            {
                if (MessageBox.Show("СТОРНО НА ЦЯЛОТО КОЛИЧЕСТВО?", "СТОРНО!!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Storno_Details";
                    cmd.Parameters.AddWithValue("ID", dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    cmd.Parameters.AddWithValue("OpID", Globals.OpID);
                    cmd.Parameters.AddWithValue("Cnt", 1);
                    cmd.Parameters.AddWithValue("Full", 1);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    InitStorno();
                }
            }
            
            //MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
        }

        private void CellBtnClick(Object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if(!isStorno)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Add_Details";
                    cmd.Parameters.AddWithValue("OrderID", Globals.OrderID);
                    cmd.Parameters.AddWithValue("ObjectID", Globals.ObjID);
                    cmd.Parameters.AddWithValue("OpID", Globals.OpID);
                    cmd.Parameters.AddWithValue("GoodsID", dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    cmd.Parameters.AddWithValue("Cnt",1);
                    cmd.Parameters.AddWithValue("Modif", null);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex) { MessageBox.Show(ex.Message); }
                    InitOrder();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_Storno_Details";
                    cmd.Parameters.AddWithValue("ID", dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                    cmd.Parameters.AddWithValue("OpID", Globals.OpID);
                    cmd.Parameters.AddWithValue("Cnt", 1);
                    cmd.Parameters.AddWithValue("Full", 0);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    InitStorno();
                }
                //MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Confirm_Order";
            cmd.Parameters.AddWithValue("OrderID", Globals.OrderID);
            cmd.Parameters.AddWithValue("CurrSum", tmpOrderSum);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            new CashLogin().Show();
            this.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Finalize_Order_Prepare";
            cmd.Parameters.AddWithValue("OrderID", Globals.OrderID);
            cmd.Parameters.AddWithValue("OpID", Globals.OpID);
            cmd.Parameters.AddWithValue("CurrSum",tmpOrderSum);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            new FormTouchEnd(tmpOrderSum).Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new FormTouchAdmin(1).ShowDialog();
        }
    }
}
