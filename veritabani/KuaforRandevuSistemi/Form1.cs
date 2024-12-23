using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace KuaforRandevuSistemi
{
    public partial class Form1 : Form
    {
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(@"
            INSERT INTO Randevu (TarihSaat, Durum, MusteriAd, CalisanAd, HizmetAd, MusteriID, CalisanID, SubeID, HizmetID)
            VALUES (@tarih, 'Beklemede', @musteriAd, @calisanAd, @hizmetAd, @musteriId, @calisanId, @subeId, @hizmetId)", conn);

                cmd.Parameters.AddWithValue("@tarih", dtpTarihSaat.Value);
                cmd.Parameters.AddWithValue("@musteriAd", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cmbMusteriAd.Text;
                cmd.Parameters.AddWithValue("@calisanAd", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cmbCalisanAd.Text;
                cmd.Parameters.AddWithValue("@hizmetAd", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cmbIslem.Text;
                cmd.Parameters.AddWithValue("@musteriId", NpgsqlTypes.NpgsqlDbType.Integer).Value = cmbMusteriAd.SelectedValue;
                cmd.Parameters.AddWithValue("@calisanId", NpgsqlTypes.NpgsqlDbType.Integer).Value = cmbCalisanAd.SelectedValue;
                cmd.Parameters.AddWithValue("@subeId", NpgsqlTypes.NpgsqlDbType.Integer).Value = cmbSubeAd.SelectedValue;
                cmd.Parameters.AddWithValue("@hizmetId", NpgsqlTypes.NpgsqlDbType.Integer).Value = cmbIslem.SelectedValue;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Randevu baþarýyla eklendi.");
                GuncelleDataGridView();
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("SELECT * FROM Randevu WHERE MusteriAd = @musteri", conn);
                cmd.Parameters.AddWithValue("@musteri", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cmbMusteriAd.Text;
                var adapter = new NpgsqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);

                dgvRandevular.DataSource = table;
                MessageBox.Show("Arama iþlemi tamamlandý.");
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            GuncelleDataGridView();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand("DELETE FROM Randevu WHERE MusteriAd = @musteri", conn);
                cmd.Parameters.AddWithValue("@musteri", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cmbMusteriAd.Text;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Seçilen randevu baþarýyla silindi.");
                GuncelleDataGridView();
            }
        }

        private void GuncelleDataGridView()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new NpgsqlCommand(@"
            SELECT R.TarihSaat, R.Durum, M.MusteriAd, C.CalisanAd, R.SubeID, H.HizmetAd
            FROM Randevu R
            JOIN Musteri M ON R.MusteriID = M.MusteriID
            JOIN Calisan C ON R.CalisanID = C.CalisanID
            JOIN Hizmet H ON R.HizmetID = H.HizmetID", conn);

                var adapter = new NpgsqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);

                dgvRandevular.DataSource = table;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // Müþteri ComboBox Doldurma
                var musteriCmd = new NpgsqlCommand("SELECT MusteriID, MusteriAd FROM Musteri", conn);
                var musteriReader = musteriCmd.ExecuteReader();
                var musteriTable = new DataTable();
                musteriTable.Load(musteriReader);
                cmbMusteriAd.DisplayMember = "MusteriAd";
                cmbMusteriAd.ValueMember = "MusteriID";
                cmbMusteriAd.DataSource = musteriTable;

                // Çalýþan ComboBox Doldurma
                var calisanCmd = new NpgsqlCommand("SELECT CalisanID, CalisanAd FROM Calisan", conn);
                var calisanReader = calisanCmd.ExecuteReader();
                var calisanTable = new DataTable();
                calisanTable.Load(calisanReader);
                cmbCalisanAd.DisplayMember = "CalisanAd";
                cmbCalisanAd.ValueMember = "CalisanID";
                cmbCalisanAd.DataSource = calisanTable;

                // Þube ComboBox Doldurma
                var subeCmd = new NpgsqlCommand("SELECT SubeID, SubeAd FROM Sube", conn);
                var subeReader = subeCmd.ExecuteReader();
                var subeTable = new DataTable();
                subeTable.Load(subeReader);
                cmbSubeAd.DisplayMember = "SubeAd";
                cmbSubeAd.ValueMember = "SubeID";
                cmbSubeAd.DataSource = subeTable;

                // Hizmet ComboBox Doldurma
                var hizmetCmd = new NpgsqlCommand("SELECT HizmetID, HizmetAd FROM Hizmet", conn);
                var hizmetReader = hizmetCmd.ExecuteReader();
                var hizmetTable = new DataTable();
                hizmetTable.Load(hizmetReader);
                cmbIslem.DisplayMember = "HizmetAd";
                cmbIslem.ValueMember = "HizmetID";
                cmbIslem.DataSource = hizmetTable;
            }
        }
    }
}
