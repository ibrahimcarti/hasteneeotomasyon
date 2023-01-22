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
    public partial class FormRandevuIslemleri : Form
    {
        public FormRandevuIslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Hasta selecteditem = (Hasta)comboBox1.SelectedItem;
            //string brans = selecteditem.hasta_gittigibolum;
            string brans =comboBox1.SelectedItem.ToString();
            SekreterManager sekreter = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            List<Doktor> doktorlar = sekreter.GetDoktorbyBrans(brans);
            //SekreterDal sekreterDal = new SekreterDal();
            //List<Doktor> doktorlar = sekreterDal.GetDoktorbyBrans(brans);
            listView1.Items.Clear();
            foreach (Doktor doktor1 in doktorlar)
            {
                ListViewItem item = new ListViewItem();
                item.Text = doktor1.doktor_id.ToString();
                item.SubItems.Add(doktor1.doktor_adi);
                item.SubItems.Add(doktor1.doktor_soyadi);
                item.SubItems.Add(doktor1.doktor_brans);
                listView1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                listView2.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int hastaid = Convert.ToInt32(textBox1.Text);
            string randevubrans = comboBox2.Text;
            int doktorid = Convert.ToInt32(textBox2.Text);
            DateTime randevutarih = dateTimePicker1.Value;


            Randevu randevu = new Randevu()
            {
                hasta_id = hastaid,
                randevu_tarih = randevutarih,
                randevu_brans = randevubrans,
                doktor_id= doktorid
            };

            SekreterManager randevuManager = new SekreterManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal());
            randevuManager.Add(randevu);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormAnasayfa frm = new FormAnasayfa();
            frm.ShowDialog();
        }
    }
}
