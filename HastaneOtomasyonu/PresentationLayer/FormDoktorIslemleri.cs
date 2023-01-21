using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
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
    public partial class FormDoktorIslemleri : Form
    {
        public FormDoktorIslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string doktorAd = textBox1.Text;
            string doktorSoyad = textBox2.Text;
            string doktortel = maskedTextBox1.Text;
            string doktorbrans = comboBox1.Text;

            Doktor doktor = new Doktor()
            {
                doktor_adi = doktorAd,
                doktor_soyadi = doktorSoyad,
                doktor_tel = doktortel,
                doktor_brans = doktorbrans
            };

            DoktorManager doktorManager = new DoktorManager(new DoktorDal());
            doktorManager.Add(doktor);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DoktorManager doktorManager = new DoktorManager(new DoktorDal());
            List<Doktor> doktorlistesi = doktorManager.GetAllDoktor();
            listView1.Items.Clear();
            foreach (Doktor doktor in doktorlistesi)
            {
                ListViewItem item = new ListViewItem();
                item.Text = doktor.doktor_id.ToString();
                item.SubItems.Add(doktor.doktor_adi);
                item.SubItems.Add(doktor.doktor_soyadi);
                item.SubItems.Add(doktor.doktor_tel);
                item.SubItems.Add(doktor.doktor_brans);
                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int doktorid = Convert.ToInt32(textBox3.Text);
            string doktorAd = textBox4.Text;
            string doktorSoyad = textBox5.Text;
            string doktortel = maskedTextBox2.Text;
            string doktorbrans = comboBox2.Text;

            Doktor doktor = new Doktor()
            {
                doktor_id = doktorid,
                doktor_adi = doktorAd,
                doktor_soyadi = doktorSoyad,
                doktor_tel = doktortel,
                doktor_brans = doktorbrans
            };

            DoktorManager doktorManager = new DoktorManager(new DoktorDal());
            doktorManager.Update(doktor);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int doktorid = Convert.ToInt32(textBox3.Text);
            Doktor doktor = new Doktor()
            {
                doktor_id = doktorid
            };

            DoktorManager doktorManager = new DoktorManager(new DoktorDal());
            doktorManager.Delete(doktorid);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormAnasayfa frm = new FormAnasayfa();
            frm.ShowDialog();
            FormDoktorIslemleri frm1 = new FormDoktorIslemleri();
            frm1.Dispose();
        }
    }
}
