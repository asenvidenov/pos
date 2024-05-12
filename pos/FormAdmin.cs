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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FormTouchOps().ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            new FormTouchObjReport().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormFPCashIn().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FormFPCashOut().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FormTouchLastReceipts(0).ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FormTouchLastReceipts(1).ShowDialog();
        }
    }
}
