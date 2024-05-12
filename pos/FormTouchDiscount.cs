using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pos
{
    public partial class FormTouchDiscount : Form
    {
        private static byte DPercent=0;
        private static String DName = "";
        public FormTouchDiscount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTouchEnd.DName = DName;
            FormTouchEnd.DiscountPercent = DPercent;
            (Application.OpenForms["FormTouchEnd"] as FormTouchEnd).InitDiscount();
            this.Close();
        }

        private void txtCardNum_LostFocus(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Discount_Ret";
            cmd.Parameters.AddWithValue("CardNum", txtCardNum.Text);
            var NewDPercent = cmd.Parameters.Add("DPercent", SqlDbType.TinyInt);
            NewDPercent.Direction = ParameterDirection.Output;
            var NewDName = cmd.Parameters.Add("DName",SqlDbType.NVarChar);
            NewDName.Value = "";
            NewDName.Direction = ParameterDirection.Output;
            try
            {
                cmd.ExecuteNonQuery();
                DPercent = System.Convert.ToByte(NewDPercent.Value.ToString());
                DName = NewDName.Value.ToString();
                lblDName.Text = NewDName.Value.ToString();
                lblDPercent.Text = NewDPercent.Value.ToString() + "%";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
