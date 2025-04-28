using HastaneSimulasyonu.Core.Context;
using HastaneSimulasyonu.Core.Models;
using System;
using System.Windows.Forms;

namespace HastaneSimulasyonu.UI
{
    public partial class FRMBolumler : Form
    {
        private readonly HastaneSimulasyonuDbContext _context;
        private Bolum bolum;

        public FRMBolumler()
        {
            InitializeComponent();
            _context = new HastaneSimulasyonuDbContext();
            BolumleriYukle();
        }

        public bool GirdiKontrol()
        {
            if (string.IsNullOrWhiteSpace(txtBolumAdi.Text))
            {
                MessageBox.Show("B�l�m ad� bo� olamaz!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                MessageBox.Show("B�l�m a��klamas� bo� olamaz!");
                return false;
            }
            return true;
        }

        public void FormuTemizle()
        {
            txtAciklama.Text = txtBolumAdi.Text = string.Empty;
        }

        public void BolumleriYukle()
        {
            try
            {
                var bolumler = _context.Bolum.ToList();
                dgvBolumler.DataSource = bolumler;
                dgvBolumler.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B�l�mler y�klenirken hata olu�tu: {ex.Message}");
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!GirdiKontrol()) return;

            try
            {
                bolum = new Bolum()
                {
                    Ad = txtBolumAdi.Text.Trim(),
                    Aciklama = txtAciklama.Text.Trim(),
                };
                _context.Add(bolum);
                _context.SaveChanges();
                BolumleriYukle();
                FormuTemizle();
                MessageBox.Show("B�l�m ba�ar�yla olu�turuldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B�l�m eklenirken hata olu�tu: {ex.Message}");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvBolumler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silme i�lemi i�in b�l�m se�iniz!");
                return;
            }

            var seciliBolum = dgvBolumler.SelectedRows[0].DataBoundItem as Bolum;
            if (seciliBolum == null)
            {
                MessageBox.Show("Se�ilen sat�r ge�erli bir b�l�m de�il!");
                return;
            }

            DialogResult sonuc = MessageBox.Show($"{seciliBolum.Ad} b�l�m�n� silmek istedi�inize emin misiniz?",
                "Silme Onay�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                try
                {
                    _context.Remove(seciliBolum);
                    _context.SaveChanges();
                    BolumleriYukle();
                    FormuTemizle();
                    MessageBox.Show("Silme i�lemi ba�ar�yla ger�ekle�tirildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"B�l�m silinirken hata olu�tu: {ex.Message}");
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvBolumler.SelectedRows.Count == 0)
            {
                MessageBox.Show("G�ncelleme i�lemi i�in b�l�m se�iniz!");
                return;
            }

            if (!GirdiKontrol()) return;

            var seciliBolum = dgvBolumler.SelectedRows[0].DataBoundItem as Bolum;
            if (seciliBolum == null)
            {
                MessageBox.Show("Se�ilen sat�r ge�erli bir b�l�m de�il!");
                return;
            }

            try
            {
                seciliBolum.Ad = txtBolumAdi.Text.Trim();
                seciliBolum.Aciklama = txtAciklama.Text.Trim();
                _context.SaveChanges();
                BolumleriYukle();
                FormuTemizle();
                MessageBox.Show("G�ncelleme i�lemi ba�ar�yla ger�ekle�tirildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B�l�m g�ncellenirken hata olu�tu: {ex.Message}");
            }
        }
        private void dgvBolumler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBolumler.SelectedRows.Count > 0)
            {
                var seciliBolum = dgvBolumler.SelectedRows[0].DataBoundItem as Bolum;
                if (seciliBolum != null)
                {
                    txtBolumAdi.Text = seciliBolum.Ad;
                    txtAciklama.Text = seciliBolum.Aciklama;
                }
            }
        }
        private void btnGec_Click(object sender, EventArgs e)
        {
            FRMDoktorlar fRMDoktorlar = new();
            fRMDoktorlar.ShowDialog();
            this.Hide();
        }
    }
}