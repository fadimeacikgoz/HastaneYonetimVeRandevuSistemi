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
    public partial class HastaGiris : Form
    {
        public HastaGiris()
        {
            InitializeComponent();
        }
        sqlBaglantısı sb = new sqlBaglantısı();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayıt hk = new HastaKayıt();
            hk.Show();
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTc='" + mskTc.Text.ToString() + "' and HastaSifre='" + txtSifre.Text.ToString() + "'",sb.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                HastaDetay hd = new HastaDetay();
                hd.tc = mskTc.Text; //Burdaki Tc HASTATC ye atadım
                hd.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı tc veya Sifre");
            }
            sb.baglanti().Close();
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
