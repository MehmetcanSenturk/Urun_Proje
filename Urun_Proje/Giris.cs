using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Proje
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db_UrunEntities db = new db_UrunEntities();
            var q = from i in db.Tbl_Admin
                        where i.Kullanici == txtKullaniciAdi.Text && i.Sifre == txtSifre.Text
                        select i;
            if (q.Any())
            {
                AnaSayfa fr = new AnaSayfa();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }
        }
    }
}
