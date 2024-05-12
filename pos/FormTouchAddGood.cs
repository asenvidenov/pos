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
    public partial class FormTouchAddGood : Form
    {
        private SqlConnection cnn;
        private Int32 GoodsID;
        public FormTouchAddGood(Int32 GoodsID, string CashName)
        {
            InitializeComponent();
            InitCnn();
            InitForm(GoodsID, CashName);
        }

        private void InitForm(Int32 addGoodsID, string CashName)
        {
            GoodsID = addGoodsID;
            this.lblGoods.Text = CashName;
        }

        private void btnCnt_Click(object sender, EventArgs e)
        {
            if (this.txtCnt.Text.Length < 3)
            {
                this.txtCnt.Text = this.txtCnt.Text + (sender as Button).Text;
            }
        }

        private void btnEraseCnt_Click(object sender, EventArgs e)
        {
            if (txtCnt.Text.Length > 0)
            { 
            txtCnt.Text = txtCnt.Text.Substring(0,txtCnt.Text.Length-1);
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            this.txtMod.Text = this.txtMod.Text + (sender as Button).Text;
        }

        private void btnModSpace_Click(object sender, EventArgs e)
        {
            this.txtMod.Text = this.txtMod.Text + " ";
        }

        private void btnEraseMod_Click(object sender, EventArgs e)
        {
            if (txtMod.Text.Length>0)
            {
                txtMod.Text = this.txtMod.Text.Substring(0, txtMod.Text.Length - 1);
            }
           
        }

        private void button53_Click(object sender, EventArgs e)
        {
            if (txtCnt.Text.Length>0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Add_Details";
                cmd.Parameters.AddWithValue("OrderID", Globals.OrderID);
                cmd.Parameters.AddWithValue("ObjectID", Globals.ObjID);
                cmd.Parameters.AddWithValue("OpID", Globals.OpID);
                cmd.Parameters.AddWithValue("GoodsID",GoodsID);
                cmd.Parameters.AddWithValue("Cnt", Int32.Parse(txtCnt.Text));
                cmd.Parameters.AddWithValue("Modif", txtMod.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                if (System.Windows.Forms.Application.OpenForms["FormTouch"] != null)
                {
                    (System.Windows.Forms.Application.OpenForms["FormTouch"] as FormTouch).InitOrder();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("НЕВЪЗМОЖНА ОПЕРАЦИЯ!", "ПРАЗНО ПОЛЕ КОЛИЧЕСТВО!", MessageBoxButtons.OK);
            }
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
    }
}
