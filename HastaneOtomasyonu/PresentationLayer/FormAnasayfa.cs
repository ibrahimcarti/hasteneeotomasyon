using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FormAnasayfa : Form
    {
        public FormAnasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.ShowDialog();
            FormAnasayfa frm = new FormAnasayfa();
            frm.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDoktorIslemleri frm1 = new FormDoktorIslemleri();
            frm1.ShowDialog();
        }
    }
}
