// MainForm.cs
using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace KuaforRandevuSistemi
{
    public partial class Form1 : Form
    {
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=2004;Database=randevuDB";

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            lblMusteriAd = new Label();
            lblCalisanAd = new Label();
            lblTarihSaat = new Label();
            dtpTarihSaat = new DateTimePicker();
            btnEkle = new Button();
            btnAra = new Button();
            btnGuncelle = new Button();
            btnSil = new Button();
            dgvRandevular = new DataGridView();
            cmbMusteriAd = new ComboBox();
            cmbCalisanAd = new ComboBox();
            cmbSubeAd = new ComboBox();
            lblSubeAd = new Label();
            lblIslem = new Label();
            cmbIslem = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).BeginInit();
            SuspendLayout();
            // 
            // lblMusteriAd
            // 
            lblMusteriAd.BackColor = Color.Purple;
            lblMusteriAd.Font = new Font("Calibri", 12F);
            lblMusteriAd.ForeColor = SystemColors.ControlLightLight;
            lblMusteriAd.Location = new Point(23, 53);
            lblMusteriAd.Name = "lblMusteriAd";
            lblMusteriAd.Size = new Size(100, 23);
            lblMusteriAd.TabIndex = 0;
            lblMusteriAd.Text = "Müşteri Adı:";
            // 
            // lblCalisanAd
            // 
            lblCalisanAd.BackColor = Color.Purple;
            lblCalisanAd.Font = new Font("Calibri", 12F);
            lblCalisanAd.ForeColor = SystemColors.ControlLightLight;
            lblCalisanAd.Location = new Point(23, 104);
            lblCalisanAd.Name = "lblCalisanAd";
            lblCalisanAd.Size = new Size(100, 23);
            lblCalisanAd.TabIndex = 2;
            lblCalisanAd.Text = "Çalışan Adı: ";
            // 
            // lblTarihSaat
            // 
            lblTarihSaat.BackColor = Color.Purple;
            lblTarihSaat.Font = new Font("Calibri", 12F);
            lblTarihSaat.ForeColor = SystemColors.ControlLightLight;
            lblTarihSaat.Location = new Point(23, 243);
            lblTarihSaat.Name = "lblTarihSaat";
            lblTarihSaat.Size = new Size(100, 23);
            lblTarihSaat.TabIndex = 6;
            lblTarihSaat.Text = "Tarih/Saat:";
            // 
            // dtpTarihSaat
            // 
            dtpTarihSaat.Location = new Point(140, 243);
            dtpTarihSaat.Name = "dtpTarihSaat";
            dtpTarihSaat.Size = new Size(203, 23);
            dtpTarihSaat.TabIndex = 7;
            // 
            // btnEkle
            // 
            btnEkle.BackColor = Color.DarkOrchid;
            btnEkle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEkle.ForeColor = Color.White;
            btnEkle.Location = new Point(56, 304);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(105, 42);
            btnEkle.TabIndex = 8;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = false;
            btnEkle.Click += BtnEkle_Click;
            // 
            // btnAra
            // 
            btnAra.BackColor = Color.DarkOrchid;
            btnAra.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAra.ForeColor = Color.White;
            btnAra.Location = new Point(56, 362);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(105, 42);
            btnAra.TabIndex = 9;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = false;
            btnAra.Click += BtnAra_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.DarkOrchid;
            btnGuncelle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuncelle.ForeColor = Color.White;
            btnGuncelle.Location = new Point(56, 427);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(105, 42);
            btnGuncelle.TabIndex = 10;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += BtnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.DarkOrchid;
            btnSil.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSil.ForeColor = Color.White;
            btnSil.Location = new Point(56, 492);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(105, 42);
            btnSil.TabIndex = 11;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += BtnSil_Click;
            // 
            // dgvRandevular
            // 
            dgvRandevular.Location = new Point(383, 12);
            dgvRandevular.Name = "dgvRandevular";
            dgvRandevular.Size = new Size(760, 300);
            dgvRandevular.TabIndex = 12;
            // 
            // cmbMusteriAd
            // 
            cmbMusteriAd.FormattingEnabled = true;
            cmbMusteriAd.Location = new Point(129, 55);
            cmbMusteriAd.Name = "cmbMusteriAd";
            cmbMusteriAd.Size = new Size(121, 23);
            cmbMusteriAd.TabIndex = 13;
            // 
            // cmbCalisanAd
            // 
            cmbCalisanAd.FormattingEnabled = true;
            cmbCalisanAd.Location = new Point(129, 104);
            cmbCalisanAd.Name = "cmbCalisanAd";
            cmbCalisanAd.Size = new Size(121, 23);
            cmbCalisanAd.TabIndex = 14;
            // 
            // cmbSubeAd
            // 
            cmbSubeAd.FormattingEnabled = true;
            cmbSubeAd.Location = new Point(129, 154);
            cmbSubeAd.Name = "cmbSubeAd";
            cmbSubeAd.Size = new Size(121, 23);
            cmbSubeAd.TabIndex = 16;
            // 
            // lblSubeAd
            // 
            lblSubeAd.BackColor = Color.Purple;
            lblSubeAd.Font = new Font("Calibri", 12F);
            lblSubeAd.ForeColor = SystemColors.ControlLightLight;
            lblSubeAd.Location = new Point(25, 154);
            lblSubeAd.Name = "lblSubeAd";
            lblSubeAd.Size = new Size(100, 23);
            lblSubeAd.TabIndex = 15;
            lblSubeAd.Text = "Şubelerimiz: ";
            // 
            // lblIslem
            // 
            lblIslem.BackColor = Color.Purple;
            lblIslem.Font = new Font("Calibri", 12F);
            lblIslem.ForeColor = SystemColors.ControlLightLight;
            lblIslem.Location = new Point(23, 203);
            lblIslem.Name = "lblIslem";
            lblIslem.Size = new Size(128, 26);
            lblIslem.TabIndex = 17;
            lblIslem.Text = "Yapılacak İşlem:";
            // 
            // cmbIslem
            // 
            cmbIslem.FormattingEnabled = true;
            cmbIslem.Location = new Point(157, 203);
            cmbIslem.Name = "cmbIslem";
            cmbIslem.Size = new Size(121, 23);
            cmbIslem.TabIndex = 18;
            // 
            // Form1
            // 
            BackColor = Color.GhostWhite;
            BackgroundImage = Properties.Resources.woman_6305120_1280;
            ClientSize = new Size(1160, 647);
            Controls.Add(cmbIslem);
            Controls.Add(lblIslem);
            Controls.Add(cmbSubeAd);
            Controls.Add(lblSubeAd);
            Controls.Add(cmbCalisanAd);
            Controls.Add(cmbMusteriAd);
            Controls.Add(lblMusteriAd);
            Controls.Add(lblCalisanAd);
            Controls.Add(lblTarihSaat);
            Controls.Add(dtpTarihSaat);
            Controls.Add(btnEkle);
            Controls.Add(btnAra);
            Controls.Add(btnGuncelle);
            Controls.Add(btnSil);
            Controls.Add(dgvRandevular);
            Name = "Form1";
            Text = "Kuaför Randevu Sistemi";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).EndInit();
            ResumeLayout(false);
        }

        private Label lblMusteriAd;
        private Label lblCalisanAd;
        private Label lblTarihSaat;
        private DateTimePicker dtpTarihSaat;
        private Button btnRandevuOlustur;
        private Label lblIsYukuTarih;
        private DateTimePicker dtpIsYuku;
        private Button btnCalisanIsYuku;
        private DataGridView dgvIsYuku;
        private Label lblMusteriPuanID;
        private TextBox txtMusteriPuanID;
        private Button btnSadakatPuani;
        private Label lblSadakatPuani;
        private Button btnEkle;
        private Button btnAra;
        private Button btnGuncelle;
        private Button btnSil;
        private DataGridView dgvRandevular;
        private ComboBox cmbMusteriAd;
        private ComboBox cmbCalisanAd;
        private ComboBox cmbSubeAd;
        private Label lblSubeAd;
        private Label lblIslem;
        private ComboBox cmbIslem;
    }
}