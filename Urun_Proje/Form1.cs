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
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
        db_UrunEntities db = new db_UrunEntities();
       
        private void btnListele_Click(object sender, EventArgs e)
        {
            var Kategoriler = db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = Kategoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Kategori t = new Tbl_Kategori();
            t.KategoriAd = txtAd.Text;
             db.Tbl_Kategori.Add(t);
            db.SaveChanges();
            var Kategoriler = db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = Kategoriler;
            MessageBox.Show(txtAd.Text + " " + "Kategorisi Eklendi!");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(txtid.Text);
            var kat = db.Tbl_Kategori.Find(i);
            db.Tbl_Kategori.Remove(kat);
            db.SaveChanges();
            var Kategoriler = db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = Kategoriler;
            MessageBox.Show("Kategori Silindi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(txtid.Text);
            var kat = db.Tbl_Kategori.Find(i);
            kat.KategoriAd = txtAd.Text;
            db.SaveChanges();
            var Kategoriler = db.Tbl_Kategori.ToList();
            dataGridView1.DataSource = Kategoriler;
            MessageBox.Show("Güncelleme İşlemş Gerçekleştirildi!");
        }
    }
}
