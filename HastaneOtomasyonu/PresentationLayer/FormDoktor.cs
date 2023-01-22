using Business.Concrete;
using Entities.Concrete;
using DataAccess.Concrete;
using DataAccess.Abstract;
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
    public partial class FormDoktor : Form
    {
        public FormDoktor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int doktor_id = Convert.ToInt32(textBox1.Text);
            DoktorManager doktorManager = new DoktorManager(new SekreterDal(), new HastaDal(), new DoktorDal(), new RandevuDal()) ;
            List<Hasta> hastalistesi = doktorManager.GetHastabyDoktor(doktor_id);
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
        }
    }
}
