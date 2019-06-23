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
    public partial class HastaKayıt : Form
    {
        public HastaKayıt()
        {
            InitializeComponent();
            
        }

        sqlBaglantısı sb = new sqlBaglantısı();
       
        private void button1_Click(object sender, EventArgs e)
        {
           SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar(HastaAd,HastaSoyad,HastaTc,HastaTelefon,HastaSifre,HastaCinsiyet) values ('"+txtAd.Text.ToString()+ "','" + txtSoyad.Text.ToString() + "','" + mskTc.Text.ToString() + "','" + mskTel.Text.ToString() + "','" + txtSifre.Text.ToString() + "','" + cmbCinsiyet.Text.ToString() + "') ",sb.baglanti());
            komut.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Kaydınız Başarıyla oluşturuldu.Şifreniz :" + txtSifre.Text,"Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
            

        }
    }
}
