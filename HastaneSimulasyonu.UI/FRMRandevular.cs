using HastaneSimulasyonu.Core.Context;
using HastaneSimulasyonu.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaneSimulasyonu.UI
{
    public partial class FRMRandevular : Form
    {
        private readonly HastaneSimulasyonuDbContext _context;
        private Randevu seciliRandevu;

        public FRMRandevular()
        {
            InitializeComponent();
            _context = new HastaneSimulasyonuDbContext();
            DoktorlariYukle();
            RandevulariYukle();
        }

        private void RandevulariYukle()
        {
            var randevular = _context.Randevu
                .Include(r => r.Hasta)
                .Include(r => r.Doktor)
                .ThenInclude(r => r.Bolum)
                .Select(
                    r => new
                    {
                        r.Id,
                        HastaAdSoyad = r.Hasta.AdSoyad,
                        RandevuTarihi = r.Tarih,
                        DoktorAdSoyad = r.Doktor.AdSoyad,
                        BolumAdi = r.Doktor.Bolum.Ad
                    }
                ).ToList();

            dgvRandevular.DataSource = randevular;
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            dgvRandevular.Columns["HastaAdSoyad"].HeaderText = "Hasta Adı Soyadı";
            dgvRandevular.Columns["RandevuTarihi"].HeaderText = "Randevu Tarihi";
            dgvRandevular.Columns["DoktorAdSoyad"].HeaderText = "Doktor Adı Soyadı";
            dgvRandevular.Columns["BolumAdi"].HeaderText = "Bölüm Adı";
            dgvRandevular.Columns["Id"].Visible = false; // Randevu ID'sini gizleyelim
        }

        private void DoktorlariYukle()
        {
            var doktorlar = _context.Doktor
                .Select(d => new { d.Id, d.AdSoyad })
                .ToList();

            cmbDoktorlar.DisplayMember = "AdSoyad";
            cmbDoktorlar.ValueMember = "Id";
            cmbDoktorlar.DataSource = doktorlar;
            cmbDoktorlar.SelectedIndex = -1;
        }

        private void FormuTemizle()
        {
            txtAdSoyad.Text = txtSikayet.Text = string.Empty;
            cmbDoktorlar.SelectedIndex = -1;
            dtpRandevuTarih.Value = DateTime.Now;
            seciliRandevu = null;
            dgvRandevular.ClearSelection();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) || string.IsNullOrWhiteSpace(txtSikayet.Text) || cmbDoktorlar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen hasta adı soyadı, şikayet ve doktoru seçiniz!");
                return;
            }

            var hasta = new Hasta
            {
                AdSoyad = txtAdSoyad.Text.Trim(),
                Sikayet = txtSikayet.Text.Trim()
            };

            _context.Hasta.Add(hasta);
            _context.SaveChanges();

            var randevu = new Randevu
            {
                HastaId = hasta.Id,
                DoktorId = (int)cmbDoktorlar.SelectedValue,
                Tarih = dtpRandevuTarih.Value
            };

            _context.Randevu.Add(randevu);
            _context.SaveChanges();

            RandevulariYukle();
            FormuTemizle();
            MessageBox.Show("Randevu başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRandevuSil_Click(object sender, EventArgs e)
        {
            if (seciliRandevu == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz randevuyu listeden seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Seçili randevuyu silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var randevuSil = _context.Randevu.Find(seciliRandevu.Id);

                if (randevuSil != null)
                {
                    _context.Randevu.Remove(randevuSil);
                    _context.SaveChanges();
                    RandevulariYukle();
                    FormuTemizle();
                    MessageBox.Show("Randevu başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Silinecek randevu bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRandevuGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliRandevu == null)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz randevuyu listeden seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbDoktorlar.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir doktor seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var randevuGuncelle = _context.Randevu.Find(seciliRandevu.Id);

            if (randevuGuncelle != null)
            {
                randevuGuncelle.DoktorId = (int)cmbDoktorlar.SelectedValue;
                randevuGuncelle.Tarih = dtpRandevuTarih.Value;

                // Hasta bilgisini güncellemek mantıklı olmayabilir, hasta kaydı ayrı yönetilebilir.
                // İstenirse buraya hasta güncelleme kodu eklenebilir.

                _context.SaveChanges();
                RandevulariYukle();
                FormuTemizle();
                MessageBox.Show("Randevu başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncellenecek randevu bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRandevular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var seciliSatir = dgvRandevular.Rows[e.RowIndex];
                if (seciliSatir.DataBoundItem != null)
                {
                    int randevuId = (int)seciliSatir.Cells["Id"].Value;
                    seciliRandevu = _context.Randevu
                        .Include(r => r.Hasta)
                        .Include(r => r.Doktor)
                        .FirstOrDefault(r => r.Id == randevuId);

                    if (seciliRandevu != null)
                    {
                        txtAdSoyad.Text = seciliRandevu.Hasta.AdSoyad;
                        txtSikayet.Text = seciliRandevu.Hasta.Sikayet;
                        cmbDoktorlar.SelectedValue = seciliRandevu.DoktorId;
                        dtpRandevuTarih.Value = seciliRandevu.Tarih;
                    }
                }
            }
        }
    }
}