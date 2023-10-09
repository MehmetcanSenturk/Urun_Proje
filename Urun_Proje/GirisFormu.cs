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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            Kategori fr = new Kategori();   
            fr.Show();
            
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            Urunler fr = new Urunler(); 
            fr.Show();
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            istatistik fr = new istatistik();
            fr.Show();
        }
    }
}
