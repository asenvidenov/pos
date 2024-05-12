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
    public partial class FormTouchObjReport : Form
    {
        public FormTouchObjReport()
        {
            InitializeComponent();
        }

        private void FormTouchObjReport_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("МАГАЗИН 1", "2", "0", "2", "0", "27.00", "13.50", "13.50");
            dataGridView1.Rows.Add("", "", "", "", "", "", "", "");
            dataGridView1.Rows.Add("ОПЕРАТОР 1", "2", "0", "2", "0", "27.00", "13.50", "13.50");
        }
    }
}
