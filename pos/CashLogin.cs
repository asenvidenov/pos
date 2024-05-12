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
using Microsoft.Win32;

namespace pos
{

    
    public partial class CashLogin : Form
    {
        //private SqlConnection cnn;
        public CashLogin()
        {
            InitializeComponent();
            //InitCnn();
            //RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\POSTRADING");
            //if (key != null)
            //{
             //   Globals.ObjID=int.Parse(key.GetValue("OBJID").ToString());
              //  Globals.PortSpeed = int.Parse(key.GetValue("PORTSPEED").ToString());
              //  Globals.PosPrinter = key.GetValue("POSPRINTER").ToString();
              //  key.Close();
            //}
            //else
            //{
             //   key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\POSTRADING");
                Globals.ObjID = 1;
                FP.PortSpeed = 115200;
                //FP.PosPrinter = "DATECS";
               // key.SetValue("OBJID", Globals.ObjID);
                //key.SetValue("PORTSPEED", Globals.PortSpeed);
                //key.SetValue("POSPRINTER", Globals.PosPrinter);
                //key.Close();
            //}

        }

        private void CashLogin_Load(object sender, EventArgs e)
        {
            Globals.OrderID = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Int32 OpInit()
        {
            if (textBoxPassword.Text.Length == 0)
            {
                Globals.OpID = 0;
                return 0;
            }
            else
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Globals.PosCnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT OpID FROM posOps WHERE OpPass = '" + textBoxPassword.Text+"'";
                try
                {
                    Globals.OpID = (Int32)cmd.ExecuteScalar();
                    return Globals.OpID;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Globals.OpID = 0;
                    return 0;
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (OpInit() == 0)
            {
                MessageBox.Show("ГРЕШКА!");
            }
            else
            {
                if (checkTable())
                        {
                            new FormTouch().Show();
                            this.Close();
                        }
                else
                {
                    MessageBox.Show("НЕВАЛИДЕН НОМЕР МАСА, ИЛИ НА МАСАТА ИМА ОТВОРЕНА СМЕТКА ОТ ДРУГ ОПЕРАТОР!", "ГРЕШКА!", MessageBoxButtons.OK);
                }
                
            }
        }

        private void textBoxPassword_LostFocus(object sender, EventArgs e)
        {
            if (OpInit()!=0)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Globals.PosCnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT OrderID, (select ObjName from posObjects where ObjectID=po.ObjectID), DateOpen FROM posOrders po WHERE OpID=" + Globals.OpID + " AND DateClosed is NULL ORDER BY DateOpen";
                SqlDataReader rst = cmd.ExecuteReader();
                dataGridView1.Rows.Clear();
                if (rst.HasRows)
                    { 
                        while(rst.Read())
                        {
                        dataGridView1.Rows.Add(rst.GetInt64(0).ToString(),rst.GetString(1), rst.GetDateTime(2).ToString() );
                        }
                    }
                rst.Close();
            }
        }
        private void btnTable_Click(object sender, EventArgs e)
        {
            this.txtTable.Text = this.txtTable.Text + (sender as Button).Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.txtTable.Text = "";
        }


        private Boolean checkTable()
        {
            if (txtTable.TextLength==0)
            {
                txtTable.Text = "1";
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_Check_Order";
            cmd.Parameters.AddWithValue("OpID", Globals.OpID);
            cmd.Parameters.AddWithValue("ObjectID", Globals.ObjID);
            cmd.Parameters.AddWithValue("TblNum", txtTable.Text);

            try
            {
                var NewID = cmd.ExecuteScalar();
                if (NewID==DBNull.Value)
                {
                    return false;
                }
                else
                {
                    Globals.OrderID = (Int64)NewID;
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private void makeNewOrder()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Globals.PosCnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SPCreateNewOrder";
            cmd.Parameters.AddWithValue("@OpID", Globals.OpID);
            cmd.Parameters.AddWithValue("@ObjectID", Globals.CurrTblID);
            try
            {
                Globals.OrderID = (Int64)cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (OpInit() != 0)
            {
                new FormAdmin().Show();
                this.Close();
            }
        }
    }
}
