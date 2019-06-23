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
    public partial class HastaDetay : Form
    {
        public HastaDetay()
        {
            InitializeComponent();
        }
        public string tc;

        sqlBaglantısı sb = new sqlBaglantısı();
       
        private void HastaDetay_Load(object sender, EventArgs e)
        {
           

            //öncelikle Bir önceki  HASTAGİRİŞ 'teki  "TC" HASTADETAY 'daki forma taşımam gerekiyor
            lblTc.Text = tc;


            //ADSOYAD ÇEKME
            SqlCommand komut = new SqlCommand("select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTc='" +lblTc.Text+"'",sb.baglanti());
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                lblAdSoyad.Text = oku[0] + " " + oku[1];
            }
            sb.baglanti().Close();


            //RANDEVU GEÇMİŞİ
            /*Veri tabanından  verileri çektik datagriedview e yerlestirdik*/

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where HastaTc='" + lblTc.Text+"' ", sb.baglanti());
            da.Fill(dt);//DataAdapter içini tablodan gelen degerle doldur
            dataGridView1.DataSource = dt;




            //BRANŞLARI ÇEKME
            cmbBrans.Items.Clear();
            SqlCommand komut2 = new SqlCommand("select * from Tbl_Branslar", sb.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                cmbBrans.Items.Add(oku2[1]);
            }
            sb.baglanti().Close();


           

        }

        private void lblTc_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            //DOKTORLARI ÇEKME
            SqlCommand komut3 = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans='"+cmbBrans.Text+"' ", sb.baglanti());
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                cmbDoktor.Items.Add(oku3[0] + "" + oku3[1]);

            }
        }


        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Randevular where RandevuBrans ='"+cmbBrans.Text+"'" , sb.baglanti());

            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }



        private void lnkBilgiDüzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaBilgiDüzenle hbd = new HastaBilgiDüzenle();
            hbd.tcn = lblTc.Text;
            hbd.Show();
           
           
        }

        private void lblAdSoyad_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Randevular  set RandevuDurum=1,HastaTc=@p1,HastaSikayet=@p2 where RandevuId=@p3", sb.baglanti());
            komut.Parameters.AddWithValue("@p1", lblTc.Text);
            komut.Parameters.AddWithValue("@p2", rctSikayet.Text);
            komut.Parameters.AddWithValue("@p3", txtId.Text);
            komut.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Randevu Alındı", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where HastaTc='" + lblTc.Text + "' ", sb.baglanti());
            da.Fill(dt);//DataAdapter içini tablodan gelen degerle doldur
            dataGridView1.DataSource = dt;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
