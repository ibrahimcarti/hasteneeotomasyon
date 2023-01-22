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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sekreterAd = textBox1.Text;
            string sekreterSoyad = textBox2.Text;
            string sekretertel =maskedTextBox1.Text;

            Sekreter sekreter = new Sekreter()
            {
                sekreter_adi = sekreterAd,
                sekreter_soyadi = sekreterSoyad,
                sekreter_tel = sekretertel,
            };

            SekreterManager sekreterManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            sekreterManager.Add(sekreter);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sekreterid = Convert.ToInt32(textBox3.Text);
            string sekreterAd = textBox4.Text;
            string sekreterSoyad = textBox5.Text;
            string sekretertel = maskedTextBox2.Text;

            Sekreter sekreter = new Sekreter()
            {
                sekreter_id = sekreterid,
                sekreter_adi = sekreterAd,
                sekreter_soyadi = sekreterSoyad,
                sekreter_tel = sekretertel,
            };

            SekreterManager sekreterManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            sekreterManager.Update(sekreter);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sekreterid = Convert.ToInt32(textBox3.Text);
            Sekreter sekreter = new Sekreter()
            {
                sekreter_id = sekreterid
            };

            SekreterManager sekreterManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            sekreterManager.Delete(sekreterid);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SekreterManager sekreterManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            List<Sekreter> sekreterlistesi = sekreterManager.GetAllSekreter();
            listView1.Items.Clear();
            foreach (Sekreter sekreter in sekreterlistesi)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sekreter.sekreter_id.ToString();
                item.SubItems.Add(sekreter.sekreter_adi);
                item.SubItems.Add(sekreter.sekreter_soyadi);
                item.SubItems.Add(sekreter.sekreter_tel);
                listView1.Items.Add(item);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormAnasayfa frm = new FormAnasayfa();
            frm.ShowDialog();
            Form1 frm1 = new Form1();
            frm1.Dispose();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            SekreterManager sekreterManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            List<Sekreter> sekreterlistesi = sekreterManager.GetAllSekreter();
            listView1.Items.Clear();
            foreach (Sekreter sekreter in sekreterlistesi)
            {
                ListViewItem item = new ListViewItem();
                item.Text = sekreter.sekreter_id.ToString();
                item.SubItems.Add(sekreter.sekreter_adi);
                item.SubItems.Add(sekreter.sekreter_soyadi);
                item.SubItems.Add(sekreter.sekreter_tel);
                listView1.Items.Add(item);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
