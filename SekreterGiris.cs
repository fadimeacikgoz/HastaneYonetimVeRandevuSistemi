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
    public partial class SekreterGiris : Form
    {
        public SekreterGiris()
        {
            InitializeComponent();
        }
        sqlBaglantısı sb = new sqlBaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Sekreter where SekreterTc='" + mskTc.Text + "' and SekreterSifre='"+txtSifre.Text+"'", sb.baglanti());

            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                SekreterDetay sd = new SekreterDetay();
                sd.tcno = mskTc.Text;
                sd.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Kullanıcı adı veya Sifre hatalı");
            }
        }
    }
}
