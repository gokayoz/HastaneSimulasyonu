using System;
using System.Linq;
using System.Windows.Forms;
using HastaneSimulasyonu.Core.Context;
using HastaneSimulasyonu.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace HastaneSimulasyonu.UI
{
    public partial class FRMDoktorlar : Form
    {
        private readonly HastaneSimulasyonuDbContext _context;
        private Doktor seciliDoktor;

        public FRMDoktorlar()
        {
            InitializeComponent();
            _context = new HastaneSimulasyonuDbContext();
            BolumleriYukle();
            DoktorlariYukle();
        }
        private void BolumleriYukle()
        {
            var bolumler = _context.Bolum
                                .Select(b => new { b.Id, b.Ad })
                                .ToList();

            cmbBolumler.DisplayMember = "Ad";
            cmbBolumler.ValueMember = "Id";
            cmbBolumler.DataSource = bolumler;
            cmbBolumler.SelectedIndex = -1;
        }

        private void DoktorlariYukle()
        {
            var doktorlar = _context.Doktor
                                .Include(d => d.Bolum)
                                .Select(d => new
                                {
                                    d.Id,
                                    d.AdSoyad,
                                    d.Telefon,
                                    BolumAdi = d.Bolum.Ad
                                })
                                .ToList();
            dgvDoktorlar.DataSource = doktorlar;
        }

        private void FormuTemizle()
        {
            txtAdSoyad.Text = txtTelefon.Text = string.Empty;
            cmbBolumler.SelectedIndex = -1;
            seciliDoktor = null;
            dgvDoktorlar.ClearSelection();
        }

        private bool GirdiKontrol()
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text))
            {
                MessageBox.Show("Doktor adı boş olamaz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                MessageBox.Show("Lütfen geçerli bir telefon numarası giriniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbBolumler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen bir bölüm seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!GirdiKontrol()) return;

            var doktor = new Doktor()
            {
                AdSoyad = txtAdSoyad.Text.Trim(),
                Telefon = txtTelefon.Text.Trim(),
                BolumId = (int)cmbBolumler.SelectedValue
            };

            _context.Add(doktor);
            _context.SaveChanges();
            FormuTemizle();
            DoktorlariYukle();

            MessageBox.Show("Doktor başarıyla eklendi.", "Bilgi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (seciliDoktor == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz doktoru listeden seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"{seciliDoktor.AdSoyad} isimli doktoru silmek istediğinize emin misiniz?",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            var doktorDb = _context.Doktor.Find(seciliDoktor.Id);
            if (doktorDb != null)
            {
                _context.Remove(doktorDb);
                _context.SaveChanges();
                FormuTemizle();
                DoktorlariYukle();
                MessageBox.Show("Doktor başarıyla silindi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seçilen doktor bulunamadı!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliDoktor == null)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz doktoru listeden seçiniz!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!GirdiKontrol()) return;

            var doktorDb = _context.Doktor.Find(seciliDoktor.Id);
            if (doktorDb != null)
            {
                doktorDb.AdSoyad = txtAdSoyad.Text.Trim();
                doktorDb.Telefon = txtTelefon.Text.Trim();
                doktorDb.BolumId = (int)cmbBolumler.SelectedValue;

                _context.SaveChanges();
                FormuTemizle();
                DoktorlariYukle();
                MessageBox.Show("Doktor başarıyla güncellendi.", "Bilgi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seçilen doktor bulunamadı!", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDoktorlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var seciliSatir = dgvDoktorlar.Rows[e.RowIndex];
                if (seciliSatir.DataBoundItem != null)
                {
                    int doktorId = (int)seciliSatir.Cells["Id"].Value;
                    seciliDoktor = _context.Doktor.Find(doktorId);

                    if (seciliDoktor != null)
                    {
                        txtAdSoyad.Text = seciliDoktor.AdSoyad;
                        txtTelefon.Text = seciliDoktor.Telefon;
                        cmbBolumler.SelectedValue = seciliDoktor.BolumId;
                    }
                }
            }
        }

        private void btnGec_Click(object sender, EventArgs e)
        {
            FRMRandevular fRMRandevular = new FRMRandevular();
            this.Hide();
            fRMRandevular.Show();
            fRMRandevular.FormClosed += (s, args) => this.Show();
        }
    }
}