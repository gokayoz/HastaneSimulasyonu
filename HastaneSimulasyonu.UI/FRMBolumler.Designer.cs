namespace HastaneSimulasyonu.UI
{
    partial class FRMBolumler
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBolumAdi = new TextBox();
            label1 = new Label();
            dgvBolumler = new DataGridView();
            btnGec = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            btnEkle = new Button();
            txtAciklama = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvBolumler).BeginInit();
            SuspendLayout();
            // 
            // txtBolumAdi
            // 
            txtBolumAdi.Location = new Point(149, 52);
            txtBolumAdi.Name = "txtBolumAdi";
            txtBolumAdi.Size = new Size(346, 27);
            txtBolumAdi.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 55);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 1;
            label1.Text = "Bölüm Adı:";
            // 
            // dgvBolumler
            // 
            dgvBolumler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBolumler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBolumler.Location = new Point(12, 337);
            dgvBolumler.Name = "dgvBolumler";
            dgvBolumler.RowHeadersWidth = 51;
            dgvBolumler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBolumler.Size = new Size(658, 304);
            dgvBolumler.TabIndex = 2;
            // 
            // btnGec
            // 
            btnGec.Location = new Point(549, 278);
            btnGec.Name = "btnGec";
            btnGec.Size = new Size(94, 29);
            btnGec.TabIndex = 3;
            btnGec.Text = ">>>>";
            btnGec.UseVisualStyleBackColor = true;
            btnGec.Click += btnGec_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(386, 242);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(94, 29);
            btnGuncelle.TabIndex = 3;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(272, 242);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(94, 29);
            btnSil.TabIndex = 3;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(161, 242);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 29);
            btnEkle.TabIndex = 3;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // txtAciklama
            // 
            txtAciklama.Location = new Point(149, 108);
            txtAciklama.Multiline = true;
            txtAciklama.Name = "txtAciklama";
            txtAciklama.Size = new Size(346, 102);
            txtAciklama.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 111);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 1;
            label2.Text = "Açıklama:";
            // 
            // FRMBolumler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 653);
            Controls.Add(btnEkle);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnGec);
            Controls.Add(dgvBolumler);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAciklama);
            Controls.Add(txtBolumAdi);
            Name = "FRMBolumler";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FRMBolumler";
            ((System.ComponentModel.ISupportInitialize)dgvBolumler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBolumAdi;
        private Label label1;
        private DataGridView dgvBolumler;
        private Button btnGec;
        private Button btnGuncelle;
        private Button btnSil;
        private Button btnEkle;
        private TextBox txtAciklama;
        private Label label2;
    }
}
