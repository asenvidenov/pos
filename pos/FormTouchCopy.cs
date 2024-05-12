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
    public partial class FormTouchCopy : Form
    {
        public FormTouchCopy()
        {
            InitializeComponent();
            lblOpName.Text = Globals.OpName;
            lblOrderSum.Text = Globals.OrderSum.ToString();
        }

        private void btnPrintCopy_Click(object sender, EventArgs e)
        {

        }
    }
}
