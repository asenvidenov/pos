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
    public partial class FormFPCashIn : Form
    {
        public FormFPCashIn()
        {
            InitializeComponent();
        }

        private void btnCnt_Click(object sender, EventArgs e)
        {
                this.txtCnt.Text = this.txtCnt.Text + (sender as Button).Text;

        }

        private void btnEraseCnt_Click(object sender, EventArgs e)
        {
            if (txtCnt.Text.Length > 0)
            {
                txtCnt.Text = txtCnt.Text.Substring(0, txtCnt.Text.Length - 1);
            }
        }
        private void button53_Click(object sender, EventArgs e)
        {
            string ErrorCode="";
            try
            {
                double res = Convert.ToDouble(txtCnt.Text);
                if (FP.execute_070_receipt_CashIn_CashOut(FP.PosPrinter, txtCnt.Text, ref ErrorCode) == -1)
                {
                    MessageBox.Show("ГРЕШКА!");
                }
                else
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("НЕВАЛИДНА СУМА!");
            }
        }
    }
}
