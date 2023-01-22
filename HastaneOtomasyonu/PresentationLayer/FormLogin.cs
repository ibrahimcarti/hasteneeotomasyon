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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sekretergiris = "sekretergiris";
            string sekretersifre = "sfr";
            string doktorgiris = "doktorgiris";
            string doktorsifre = "sfr";

            if(textBox1.Text==sekretergiris && textBox2.Text==sekretersifre)
            {
                FormAnasayfa frm = new FormAnasayfa();
                frm.ShowDialog();
                FormLogin frm1 = new FormLogin();
                frm1.Dispose();
            }
            else if(textBox1.Text == doktorgiris && textBox2.Text == doktorsifre)
            {
                FormDoktor frm = new FormDoktor();
                frm.ShowDialog();
            }
        }
    }
}
