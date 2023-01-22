using Business.Concrete;
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
    public partial class FormHastaIslemleri : Form
    {
        public FormHastaIslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hastaad = textBox1.Text;
            string hastasoyad = textBox2.Text;
            string hastatel = maskedTextBox1.Text;
            string gittigibolum = comboBox1.Text;

            Hasta hasta = new Hasta()
            {
                hasta_adi = hastaad,
                hasta_soyadi = hastasoyad,
                hasta_tel = hastatel,
                hasta_gittigibolum = gittigibolum
            };

            SekreterManager hastaManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            hastaManager.Add(hasta);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int hastaid = Convert.ToInt32(textBox3.Text);
            string hastaAd = textBox4.Text;
            string hastaSoyad = textBox5.Text;
            string hastatel = maskedTextBox2.Text;
            string gittigibolum = comboBox2.Text;

            Hasta hasta = new Hasta()
            {
                hasta_id = hastaid,
                hasta_adi = hastaAd,
                hasta_soyadi = hastaSoyad,
                hasta_tel = hastatel,
                hasta_gittigibolum = gittigibolum
            };

            SekreterManager hastaManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            hastaManager.Update(hasta);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int hastaid = Convert.ToInt32(textBox3.Text);
            Hasta hasta = new Hasta()
            {
                hasta_id = hastaid
            };

            SekreterManager hastaManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            hastaManager.DeleteHasta(hastaid);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SekreterManager hastaManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            List<Hasta> hastalistesi = hastaManager.GetAllHasta();
            listView1.Items.Clear();
            foreach (Hasta hasta in hastalistesi)
            {
                ListViewItem item = new ListViewItem();
                item.Text = hasta.hasta_id.ToString();
                item.SubItems.Add(hasta.hasta_adi);
                item.SubItems.Add(hasta.hasta_soyadi);
                item.SubItems.Add(hasta.hasta_tel);
                item.SubItems.Add(hasta.hasta_gittigibolum);
                listView1.Items.Add(item);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormAnasayfa frm = new FormAnasayfa();
            frm.ShowDialog();
            FormHastaIslemleri frm1 = new FormHastaIslemleri();
            frm1.Dispose();
        }
    }
}
