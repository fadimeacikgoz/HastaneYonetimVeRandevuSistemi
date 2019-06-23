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
    public partial class SekreterDetay : Form
    {
        public SekreterDetay()
        {
            InitializeComponent();
        }
        public string tcno;
        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {
            DoktorPaneli dp = new DoktorPaneli();
            dp.Show();
           
        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {
            BranşPaneli bp = new BranşPaneli();
            bp.Show();
            
        }

        private void btnRandevuListe_Click(object sender, EventArgs e)
        {
            RandevuListesi rl = new RandevuListesi();
            rl.Show();

        }
        sqlBaglantısı sb = new sqlBaglantısı();
        private void SekreterDetay_Load(object sender, EventArgs e)
        {
            /********TCNO CEKME*****************/
            lblTc.Text = tcno;
            


            /********AD SOYAD CEKME************/
            SqlCommand komut = new SqlCommand("select * from Tbl_Sekreter where SekreterTc='" + lblTc.Text + "'", sb.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblAdSoyad.Text = oku[1].ToString();

            }

            /***********BRANŞLARI ÇEKME************/
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select  * from Tbl_Branslar ", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            /******DOKTORLARI ÇEKME********/

            DataTable dtt = new DataTable();
            SqlDataAdapter daa = new SqlDataAdapter("select(DoktorAd +''+ DoktorSoyad ) as 'Doktorlar', DoktorBrans from Tbl_Doktorlar", sb.baglanti());
            daa.Fill(dtt);
            dataGridView2.DataSource = dtt;


            /******BRANŞI COMBOBOX'A AKTARMA************/

            SqlCommand komut0 = new SqlCommand("select * from Tbl_Branslar", sb.baglanti());
            SqlDataReader oku0 = komut0.ExecuteReader();
            while (oku0.Read())
            {
                cmbBrans.Items.Add(oku0[1]);
            }
            sb.baglanti().Close();
           




        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values(@p1,@p2,@p3,@p4)",sb.baglanti());
            komutkaydet.Parameters.AddWithValue("@p1", mskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@p2", mskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komutkaydet.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            komutkaydet.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");

        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
           


        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();

            /************DOKTORU AKTARMA***************/
            SqlCommand komut1 = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans='" + cmbBrans.Text + "'", sb.baglanti());
            SqlDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                cmbDoktor.Items.Add(oku1[0] + " " + oku1[1]);
            }
            sb.baglanti().Close();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_randevular set ");
        }

        private void bntOlustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut4 = new SqlCommand("insert into Tbl_Duyurular  (Duyuru) values(@p1)", sb.baglanti());
            komut4.Parameters.AddWithValue("@p1", rchOlustur.Text);
            MessageBox.Show("Duyuru Oluşturuldu");
            komut4.ExecuteNonQuery();

        }

        private void bntDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular dyr = new Duyurular();
            dyr.Show();
            
        }
    }
}
