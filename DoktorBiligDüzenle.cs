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
    public partial class DoktorBiligDüzenle : Form
    {
        public DoktorBiligDüzenle()
        {
            InitializeComponent();
        }

        sqlBaglantısı sb = new sqlBaglantısı();
        public string tcno;
        private void DoktorBiligDüzenle_Load(object sender, EventArgs e)
        {
            mskTc.Text = tcno;
            SqlCommand komut = new SqlCommand("select * from Tbl_Doktorlar where DoktorTc= @p1", sb.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtAd.Text = oku[1].ToString();
                txtSoyad.Text = oku[2].ToString();
                cmbBrans.Text = oku[3].ToString();
                mskTc.Text = oku[4].ToString();
                txtSifre.Text = oku[5].ToString();

            }
            sb.baglanti().Close();


        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1 , DoktorSoyad=@p2, DoktorBrans=@p3 ,DoktorSifre=@p4 where DoktorTc= @p5", sb.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut.Parameters.AddWithValue("@p5", mskTc.Text);
            komut.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Bilgiler Güüncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
           
          SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTc='"+mskTc.Text+"' ", sb.baglanti());
          SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbBrans.Items.Add( oku[1].ToString());
            }
            sb.baglanti().Close();
            
        }
    }
}
