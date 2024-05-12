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
    public partial class FormTouchAdmin : Form
    {
        private int AdminType;
        public FormTouchAdmin(int Type)
        {
            InitializeComponent();
            AdminType = Type;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = Globals.PosCnn
            };
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT OpRole FROM posOps WHERE OpPass = '" + txtPass.Text+"'";
            Int16 AdminRole = 0;
            try
            {
                
                AdminRole = (Int16)cmd.ExecuteScalar();
            }
            catch
            { AdminRole=0; 
                this.Close();
            }
            switch(AdminType)
            {
                //Прехвърляне сметка роля >=100
                case 1:
                    if(AdminRole>=100)
                    {
                        this.Dispose();
                        new FormTouchOperatorChange().ShowDialog();
                        this.Close();
                    }
                    break;
                //разделяне сметка роля >=100
                case 2:
                    if (AdminRole >= 100)
                    {
                        this.Dispose();
                        new FormTouchOperatorChange().ShowDialog();
                        this.Close();
                    }
                    break;
                case 3:
                    if (AdminRole>=100)
                    {
                        this.Dispose();
                        new FormTouchSellReverse(ReOrderID()).ShowDialog(); 
                    }
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Int64 ReOrderID()
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = Globals.PosCnn
            };
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPCreateREOrder";
            cmd.Parameters.AddWithValue("@OrderID", Globals.OrderID);
            try
            {
                return (Int64)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
