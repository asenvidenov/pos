using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FP3530;

namespace pos
{
    public partial class FormTouchEnd : Form
    {
        private static Single _orderSum;
        private static int _discountPercent;
        public static String DName;
        public FormTouchEnd(Single OrderSum)
        {
            _orderSum = OrderSum;
            InitializeComponent();
            lblOrderSum.Text = String.Format("{0:C2}", OrderSum);
        }

        public static Single OrderSum
        {
            get
            {
                return _orderSum;
            }
            set
            {
                _orderSum = value;
            }
        }

        public static int DiscountPercent
        {
            get
            {
                return _discountPercent;
            }
            set
            {
                _discountPercent = value;
                _orderSum = (Single)Math.Round(_orderSum - (_orderSum * _discountPercent / 100), 2);
            }
        }
        public void InitDiscount()
        {
            btnDiscount.Text = DName;
            lblDPercent.Text = _discountPercent.ToString() + "%";
            lblFinalSum.Text = String.Format("{0:C2}", _orderSum);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FormTouchDiscount().ShowDialog();
        }

        private void DatecsPrint()
        {
            
        }

        private void FormTouchEnd_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
