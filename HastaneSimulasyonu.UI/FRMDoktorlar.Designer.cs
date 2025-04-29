namespace HastaneSimulasyonu.UI
{
    partial class FRMDoktorlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvDoktorlar = new DataGridView();
            txtAdSoyad = new TextBox();
            label1 = new Label();
            btnEkle = new Button();
            cmbBolumler = new ComboBox();
            txtTelefon = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnSil = new Button();
            btnGuncelle = new Button();
            btnGec = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDoktorlar).BeginInit();
            SuspendLayout();
            // 
            // dgvDoktorlar
            // 
            dgvDoktorlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDoktorlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoktorlar.Location = new Point(12, 337);
            dgvDoktorlar.Name = "dgvDoktorlar";
            dgvDoktorlar.RowHeadersWidth = 51;
            dgvDoktorlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoktorlar.Size = new Size(658, 304);
            dgvDoktorlar.TabIndex = 0;
            dgvDoktorlar.CellClick += dgvDoktorlar_CellClick;
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(173, 50);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(343, 27);
            txtAdSoyad.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 53);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 2;
            label1.Text = "Ad Soyad:";
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(186, 213);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 29);
            btnEkle.TabIndex = 3;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // cmbBolumler
            // 
            cmbBolumler.FormattingEnabled = true;
            cmbBolumler.Location = new Point(173, 144);
            cmbBolumler.Name = "cmbBolumler";
            cmbBolumler.Size = new Size(343, 28);
            cmbBolumler.TabIndex = 4;
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new Point(173, 96);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(343, 27);
            txtTelefon.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 96);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 2;
            label2.Text = "Telefon:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 147);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 2;
            label3.Text = "Bölüm:";
            // 
            // btnSil
            // 
            btnSil.Location = new Point(296, 213);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(94, 29);
            btnSil.TabIndex = 3;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Location = new Point(410, 213);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(94, 29);
            btnGuncelle.TabIndex = 3;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnGec
            // 
            btnGec.Location = new Point(549, 275);
            btnGec.Name = "btnGec";
            btnGec.Size = new Size(94, 29);
            btnGec.TabIndex = 3;
            btnGec.Text = ">>>>";
            btnGec.UseVisualStyleBackColor = true;
            btnGec.Click += btnGec_Click;
            // 
            // FRMDoktorlar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 653);
            Controls.Add(cmbBolumler);
            Controls.Add(btnGec);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(btnEkle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtTelefon);
            Controls.Add(label1);
            Controls.Add(txtAdSoyad);
            Controls.Add(dgvDoktorlar);
            Name = "FRMDoktorlar";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FRMDoktorlar";
            ((System.ComponentModel.ISupportInitialize)dgvDoktorlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDoktorlar;
        private TextBox txtAdSoyad;
        private Label label1;
        private Button btnEkle;
        private ComboBox cmbBolumler;
        private TextBox txtTelefon;
        private Label label2;
        private Label label3;
        private Button btnSil;
        private Button btnGuncelle;
        private Button btnGec;
    }
}