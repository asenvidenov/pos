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
    public partial class FormTouchOperatorChange : Form
    {
        private Int32 ToOpID;
        private Int32 ToObjID;
        private Boolean ToOp=false;
        private Boolean ToObj=false;
        public FormTouchOperatorChange()
        {
            InitializeComponent();
            InitList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = Globals.PosCnn
            };
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Order_Transfer";
            cmd.Parameters.AddWithValue("OrderID", Globals.OrderID);
            if (!ToOp)
            {
                ToOpID = Globals.OpID;
            }
            cmd.Parameters.AddWithValue("ÖpID",ToOpID);
            if (ToObj)
            {
                cmd.Parameters.AddWithValue("ObjID", ToObjID);
            }

            try
            {
                cmd.ExecuteNonQuery();
                (System.Windows.Forms.Application.OpenForms["FormTouch"] as FormTouch).Close();
                this.Dispose();
                new CashLogin().ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CellBtnClick(Object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(), "", MessageBoxButtons.OK);
            if (MessageBox.Show("ИЗБРАН ОПЕРАТОР "+ dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(),"ИЗБОР ОПЕРАТОР", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                ToOp = true;
                ToOpID = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
            
        }

        private void CellBtnClickTbl(Object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("ИЗБРАН ОБЕКТ " + dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[1].Value.ToString(), "ИЗБОР ОБЕКТ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ToObj = true;
                ToObjID = Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void InitList()
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = Globals.PosCnn
            };
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT OpID, OpName FROM posOps";
            SqlDataReader rst;
            try
            {
                rst = cmd.ExecuteReader();
                if (rst.HasRows)
                {
                    dataGridView1.Rows.Clear();
                    while (rst.Read())
                    {
                        dataGridView1.Rows.Add(rst.GetInt32(0).ToString(), rst.GetString(1));
                    }
                }
                rst.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
            

            cmd.CommandText = "SELECT ObjectID, ObjName FROM posObjects WHERE PARENT="+Globals.ObjID;
            try
            {
                rst = cmd.ExecuteReader();
                if (rst.HasRows)
                {
                    dataGridView2.Rows.Clear();
                    while (rst.Read())
                    {
                        dataGridView2.Rows.Add(rst.GetInt32(0).ToString(), rst.GetString(1));
                    }
                }
                rst.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!ToOp)
            {
                MessageBox.Show("ТРЯБВА ДА ИЗБЕРЕТЕ ОПЕРАТОР!","РАЗДЕЛЯНЕ",MessageBoxButtons.OK);
                return;
            }
            if(!ToObj)
            {
                MessageBox.Show("ТРЯБВА ДА ИЗБЕРЕТЕ ОБЕКТ!", "РАЗДЕЛЯНЕ",MessageBoxButtons.OK);
                return;
            }
            SqlCommand cmd = new SqlCommand
            {
                Connection = Globals.PosCnn
            };
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPCreateNewOrder";
            cmd.Parameters.AddWithValue("OpID", ToOpID);
            cmd.Parameters.AddWithValue("ObjectID", ToObjID);
            var NewID = cmd.Parameters.Add("NewID", SqlDbType.BigInt);
            NewID.Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                if(Convert.ToInt32(NewID.Value.ToString())==0)
                {
                    MessageBox.Show("МАСАТА Е ЗАЕТА!","ГРЕШКА!",MessageBoxButtons.OK);
                }
                else
                {
                    this.Dispose();
                    new FormTouchSplit(Convert.ToInt32(NewID.Value.ToString())).ShowDialog();
                    this.Close();
                }
                
                //MessageBox.Show(NewID.Value.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

    }
    }
}
