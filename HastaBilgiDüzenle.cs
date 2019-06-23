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
    public partial class HastaBilgiDüzenle : Form
    {
        public HastaBilgiDüzenle()
        {
            InitializeComponent();
        }
        public string tcn;
        sqlBaglantısı sb = new sqlBaglantısı();

        private void btnBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hastalar  set HastaAd=@p1, HastaSoyad=@p2, HastaTelefon=@p3, HastaSifre=@p4, HastaCinsiyet=@p5 where HastaTc=@p6", sb.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskTel.Text);
            komut2.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", mskTc.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("bilgileriniz güncellenmiştir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            sb.baglanti().Close();

           
        }


        private void HastaBilgiDüzenle_Load(object sender, EventArgs e)
        {
            //TCNO ÇEKTİK
            mskTc.Text = tcn;
            //diğerlerini çekme
            SqlCommand komut4 = new SqlCommand("select * from Tbl_Hastalar where HastaTc= '" + mskTc.Text + "'", sb.baglanti());
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                txtAd.Text = oku4[1].ToString();
                txtSoyad.Text = oku4[2].ToString();
                mskTel.Text = oku4[4].ToString();
                txtSifre.Text = oku4[5].ToString();
                cmbCinsiyet.Text = oku4[6].ToString();

            }
            sb.baglanti().Close();
           
        }
    }
}
