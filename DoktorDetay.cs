using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HastaneYönetimVeRandevuSistemi
{
    public partial class DoktorDetay : Form
    {
        public DoktorDetay()
        {
            InitializeComponent();
        }
        sqlBaglantısı sb = new sqlBaglantısı();

        public string Tnumara;

        private void DoktorDetay_Load(object sender, EventArgs e)
        {

            // Tc Numarası Cekme
            lblTc.Text = Tnumara;


            //AD soyad Cekme
            SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar", sb.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblAdSoyad.Text = oku[1].ToString() + " " + oku[2].ToString();


            }


            //Datayi aktar
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuDoktor= '" + lblAdSoyad.Text + "'", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            DoktorBiligDüzenle dbd = new DoktorBiligDüzenle();
            dbd.tcno = lblTc.Text;
            dbd.Show();
            this.Hide();
        }

        private void btnDuyuru_Click(object sender, EventArgs e)
        {
            Duyurular d = new Duyurular();
            d.Show();

        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
