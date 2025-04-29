using HastaneSimulasyonu.Core.Context;
using HastaneSimulasyonu.Core.Models;
using System;
using System.Linq;
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
                MessageBox.Show("L�tfen b�l�m ad�n� giriniz.", "Giri� Hatas�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                MessageBox.Show("L�tfen b�l�m a��klamas�n� giriniz.", "Giri� Hatas�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            var bolumler = _context.Bolum.ToList();
            dgvBolumler.DataSource = bolumler;
            dgvBolumler.Refresh();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!GirdiKontrol()) return;

            bolum = new Bolum()
            {
                Ad = txtBolumAdi.Text.Trim(),
                Aciklama = txtAciklama.Text.Trim(),
            };
            _context.Add(bolum);
            _context.SaveChanges();
            BolumleriYukle();
            FormuTemizle();
            MessageBox.Show("B�l�m ba�ar�yla olu�turuldu.", "Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dgvBolumler.SelectedRows.Count == 0)
            {
                MessageBox.Show("L�tfen silmek i�in bir b�l�m se�iniz.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var seciliBolum = dgvBolumler.SelectedRows[0].DataBoundItem as Bolum;
            if (seciliBolum == null)
            {
                MessageBox.Show("Se�ilen sat�r ge�erli bir b�l�m de�il.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult sonuc = MessageBox.Show($"{seciliBolum.Ad} b�l�m�n� silmek istedi�inize emin misiniz?",
                "Silme Onay�", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (sonuc == DialogResult.Yes)
            {
                _context.Remove(seciliBolum);
                _context.SaveChanges();
                BolumleriYukle();
                FormuTemizle();
                MessageBox.Show("B�l�m ba�ar�yla silindi.", "Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dgvBolumler.SelectedRows.Count == 0)
            {
                MessageBox.Show("L�tfen g�ncellemek i�in bir b�l�m se�iniz.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!GirdiKontrol()) return;

            var seciliBolum = dgvBolumler.SelectedRows[0].DataBoundItem as Bolum;
            if (seciliBolum == null)
            {
                MessageBox.Show("Se�ilen sat�r ge�erli bir b�l�m de�il.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            seciliBolum.Ad = txtBolumAdi.Text.Trim();
            seciliBolum.Aciklama = txtAciklama.Text.Trim();
            _context.SaveChanges();
            BolumleriYukle();
            FormuTemizle();
            MessageBox.Show("B�l�m ba�ar�yla g�ncellendi.", "Ba�ar�l�", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvBolumler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var seciliBolum = dgvBolumler.Rows[e.RowIndex].DataBoundItem as Bolum;
                if (seciliBolum != null)
                {
                    txtBolumAdi.Text = seciliBolum.Ad;
                    txtAciklama.Text = seciliBolum.Aciklama;
                }
            }
        }

        private void btnGec_Click(object sender, EventArgs e)
        {
            FRMDoktorlar fRMDoktorlar = new FRMDoktorlar();
            this.Hide();
            fRMDoktorlar.Show();
            fRMDoktorlar.FormClosed += (s, args) => this.Show();
        }
    }
}