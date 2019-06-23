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
    public partial class DoktorGiris : Form
    {
        public DoktorGiris()
        {
            InitializeComponent();
        }
        sqlBaglantısı sb = new sqlBaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select * from Tbl_Doktorlar where DoktorTc=@p1 and  DoktorSifre= @p2", sb.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader oku = komut.ExecuteReader();

            if (oku.Read())
            {
                DoktorDetay dd = new DoktorDetay();
                dd.Tnumara = mskTc.Text;
                dd.Show();
              
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Sifre hatalı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            sb.baglanti().Close();
        }
    }
}
