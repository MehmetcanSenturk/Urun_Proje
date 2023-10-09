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
    public partial class istatistik : Form
    {
        public istatistik()
        {
            InitializeComponent();
        }
        db_UrunEntities db = new db_UrunEntities(); 
        private void istatistik_Load(object sender, EventArgs e)
        {
            lblKategori.Text = db.Tbl_Kategori.Count().ToString();
            lblUrun.Text = db.Tbl_Urun.Count().ToString();
            lblaktifmusteri.Text = db.Tbl_Musteri.Count
                (i=>i.Durum==true).ToString();
            lblpasifmusteri.Text = db.Tbl_Musteri.Count
                (i=>i.Durum==false).ToString();
            lblstok.Text = db.Tbl_Urun.Sum
                (i=>i.UrunStok).ToString();
            lblkasa.Text = db.Tbl_Satis.Sum
                (i => i.Fiyat).ToString() +" "+ "TL";
            lblenfiyat.Text = (from i in db.Tbl_Urun
                               orderby i.UrunFiyat
                               descending select i.UrunAd)
                               .FirstOrDefault();
            lblendusukfiyat.Text = (from i in db.Tbl_Urun
                               orderby i.UrunFiyat
                               ascending
                               select i.UrunAd)
                               .FirstOrDefault();
            lblbeyazesya.Text= db.Tbl_Urun.Count
                (i=>i.UrunKategori==1).ToString();
            lblBuzdolabi.Text = db.Tbl_Urun.Count(i=>i.UrunAd=="Buzdolabı").ToString(); 
            lblsehirler.Text= (from i in db.Tbl_Musteri
                               select i.Sehir)
                               .Distinct().Count().ToString();
            lblmarka.Text = db.UrunMarka().FirstOrDefault();

        }
    }
}
