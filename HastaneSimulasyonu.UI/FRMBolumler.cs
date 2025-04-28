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
                MessageBox.Show("Bölüm adý boþ olamaz!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                MessageBox.Show("Bölüm açýklamasý boþ olamaz!");
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
                MessageBox.Show($"Bölümler yüklenirken hata oluþtu: {ex.Message}");
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
                MessageBox.Show("Bölüm baþarýyla oluþturuldu.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bölüm eklenirken hata oluþtu: {ex.Message}");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvBolumler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silme iþlemi için bölüm seçiniz!");
                return;
            }

            var seciliBolum = dgvBolumler.SelectedRows[0].DataBoundItem as Bolum;
            if (seciliBolum == null)
            {
                MessageBox.Show("Seçilen satýr geçerli bir bölüm deðil!");
                return;
            }

            DialogResult sonuc = MessageBox.Show($"{seciliBolum.Ad} bölümünü silmek istediðinize emin misiniz?",
                "Silme Onayý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (sonuc == DialogResult.Yes)
            {
                try
                {
                    _context.Remove(seciliBolum);
                    _context.SaveChanges();
                    BolumleriYukle();
                    FormuTemizle();
                    MessageBox.Show("Silme iþlemi baþarýyla gerçekleþtirildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bölüm silinirken hata oluþtu: {ex.Message}");
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvBolumler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Güncelleme iþlemi için bölüm seçiniz!");
                return;
            }

            if (!GirdiKontrol()) return;

            var seciliBolum = dgvBolumler.SelectedRows[0].DataBoundItem as Bolum;
            if (seciliBolum == null)
            {
                MessageBox.Show("Seçilen satýr geçerli bir bölüm deðil!");
                return;
            }

            try
            {
                seciliBolum.Ad = txtBolumAdi.Text.Trim();
                seciliBolum.Aciklama = txtAciklama.Text.Trim();
                _context.SaveChanges();
                BolumleriYukle();
                FormuTemizle();
                MessageBox.Show("Güncelleme iþlemi baþarýyla gerçekleþtirildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bölüm güncellenirken hata oluþtu: {ex.Message}");
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