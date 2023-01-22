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

        private void button3_Click(object sender, EventArgs e)
        {
            FormHastaIslemleri frm = new FormHastaIslemleri();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormRandevuIslemleri form = new FormRandevuIslemleri();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormLogin frm = new FormLogin();
            frm.ShowDialog();
            FormAnasayfa frm1 = new FormAnasayfa();
            frm1.Dispose();
        }
    }
}
