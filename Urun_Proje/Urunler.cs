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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        db_UrunEntities db = new db_UrunEntities();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.UrunAd = txtAd.Text;
            t.UrunMarka = txtMarka.Text;
            t.UrunStok = short.Parse(txtStok.Text);
            t.UrunKategori = int.Parse(cmKategori.SelectedValue.ToString());
            t.UrunFiyat = decimal.Parse(txtFiyat.Text);
            t.UrunDurum = true;
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show(txtAd.Text + " " + "Kaydedildi");
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.UrunId,
                                            x.UrunAd,
                                            x.UrunMarka,
                                            x.UrunStok,
                                            x.UrunFiyat,
                                            x.Tbl_Kategori.KategoriAd,
                                            x.UrunKategori,
                                            x.UrunDurum,
                                        }).ToList();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.UrunId,
                                            x.UrunAd,
                                            x.UrunMarka,
                                            x.UrunStok,
                                            x.UrunFiyat,
                                            x.Tbl_Kategori.KategoriAd,
                                            x.UrunKategori,
                                            x.UrunDurum,
                                        }).ToList();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(txtNo.Text);
            var urun = db.Tbl_Urun.Find(i);
            db.Tbl_Urun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show(txtAd.Text + " " + "Silinmiştir");
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.UrunId,
                                            x.UrunAd,
                                            x.UrunMarka,
                                            x.UrunStok,
                                            x.UrunFiyat,
                                            x.Tbl_Kategori.KategoriAd,
                                            x.UrunKategori,
                                            x.UrunDurum,
                                        }).ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNo.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMarka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmKategori.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(txtNo.Text);
            var urun = db.Tbl_Urun.Find(i);
            urun.UrunAd = txtAd.Text;
            urun.UrunStok = short.Parse(txtStok.Text);
            urun.UrunMarka = txtMarka.Text;
            db.SaveChanges();
            MessageBox.Show(txtNo.Text + " " + "Numaralı ürün güncellenmiştir!");
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.UrunId,
                                            x.UrunAd,
                                            x.UrunMarka,
                                            x.UrunStok,
                                            x.UrunFiyat,
                                            x.Tbl_Kategori.KategoriAd,
                                            x.UrunKategori,
                                            x.UrunDurum,
                                        }).ToList();
        }

        private void Urunler_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_Kategori
                               select new
                               {
                                   x.KategoriId,
                                   x.KategoriAd
                               }
                              ).ToList();
            cmKategori.ValueMember = "KategoriId";
            cmKategori.DisplayMember = "KategoriAd";
            cmKategori.DataSource = kategoriler;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
          

        }
    }
}
