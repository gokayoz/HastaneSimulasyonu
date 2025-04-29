namespace HastaneSimulasyonu.UI
{
    partial class FRMRandevular
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
            label1 = new Label();
            txtAdSoyad = new TextBox();
            btnRandevuAl = new Button();
            dtpRandevuTarih = new DateTimePicker();
            dgvRandevular = new DataGridView();
            cmbDoktorlar = new ComboBox();
            label2 = new Label();
            txtSikayet = new TextBox();
            label3 = new Label();
            label4 = new Label();
            btnRandevuSil = new Button();
            btnRandevuGuncelle = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 44);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "Ad Soyad:";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(179, 44);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(266, 27);
            txtAdSoyad.TabIndex = 1;
            // 
            // btnRandevuAl
            // 
            btnRandevuAl.Location = new Point(107, 285);
            btnRandevuAl.Name = "btnRandevuAl";
            btnRandevuAl.Size = new Size(138, 29);
            btnRandevuAl.TabIndex = 2;
            btnRandevuAl.Text = "Randevu Al";
            btnRandevuAl.UseVisualStyleBackColor = true;
            btnRandevuAl.Click += btnRandevuAl_Click;
            // 
            // dtpRandevuTarih
            // 
            dtpRandevuTarih.Location = new Point(179, 204);
            dtpRandevuTarih.Name = "dtpRandevuTarih";
            dtpRandevuTarih.Size = new Size(266, 27);
            dtpRandevuTarih.TabIndex = 3;
            // 
            // dgvRandevular
            // 
            dgvRandevular.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRandevular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRandevular.Location = new Point(12, 337);
            dgvRandevular.Name = "dgvRandevular";
            dgvRandevular.RowHeadersWidth = 51;
            dgvRandevular.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRandevular.Size = new Size(658, 304);
            dgvRandevular.TabIndex = 4;
            dgvRandevular.CellClick += dgvRandevular_CellClick;
            // 
            // cmbDoktorlar
            // 
            cmbDoktorlar.FormattingEnabled = true;
            cmbDoktorlar.Location = new Point(179, 147);
            cmbDoktorlar.Name = "cmbDoktorlar";
            cmbDoktorlar.Size = new Size(266, 28);
            cmbDoktorlar.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 94);
            label2.Name = "label2";
            label2.Size = new Size(59, 20);
            label2.TabIndex = 0;
            label2.Text = "Şikayet:";
            // 
            // txtSikayet
            // 
            txtSikayet.Location = new Point(179, 94);
            txtSikayet.Name = "txtSikayet";
            txtSikayet.Size = new Size(266, 27);
            txtSikayet.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(88, 147);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 0;
            label3.Text = "Doktor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 204);
            label4.Name = "label4";
            label4.Size = new Size(108, 20);
            label4.TabIndex = 0;
            label4.Text = "Randevu Tarihi:";
            // 
            // btnRandevuSil
            // 
            btnRandevuSil.Location = new Point(278, 285);
            btnRandevuSil.Name = "btnRandevuSil";
            btnRandevuSil.Size = new Size(138, 29);
            btnRandevuSil.TabIndex = 2;
            btnRandevuSil.Text = "Randevu Sil";
            btnRandevuSil.UseVisualStyleBackColor = true;
            btnRandevuSil.Click += btnRandevuSil_Click;
            // 
            // btnRandevuGuncelle
            // 
            btnRandevuGuncelle.Location = new Point(453, 285);
            btnRandevuGuncelle.Name = "btnRandevuGuncelle";
            btnRandevuGuncelle.Size = new Size(138, 29);
            btnRandevuGuncelle.TabIndex = 2;
            btnRandevuGuncelle.Text = "Randevu Güncelle";
            btnRandevuGuncelle.UseVisualStyleBackColor = true;
            btnRandevuGuncelle.Click += btnRandevuGuncelle_Click;
            // 
            // FRMRandevular
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 653);
            Controls.Add(cmbDoktorlar);
            Controls.Add(dgvRandevular);
            Controls.Add(dtpRandevuTarih);
            Controls.Add(btnRandevuGuncelle);
            Controls.Add(btnRandevuSil);
            Controls.Add(btnRandevuAl);
            Controls.Add(txtSikayet);
            Controls.Add(txtAdSoyad);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FRMRandevular";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FRMRandevular";
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAdSoyad;
        private Button btnRandevuAl;
        private DateTimePicker dtpRandevuTarih;
        private DataGridView dgvRandevular;
        private ComboBox cmbDoktorlar;
        private Label label2;
        private TextBox txtSikayet;
        private Label label3;
        private Label label4;
        private Button btnRandevuSil;
        private Button btnRandevuGuncelle;
    }
}