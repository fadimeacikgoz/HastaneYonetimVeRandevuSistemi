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
    public partial class DoktorPaneli : Form
    {
        public DoktorPaneli()
        {
            InitializeComponent();
        }
        sqlBaglantısı sb = new sqlBaglantısı();
        private void DoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;




            //Bransları aktarma 
            SqlCommand komut = new SqlCommand("Select * from Tbl_Branslar", sb.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbBrans.Items.Add(oku[1].ToString());
            }
            sb.baglanti().Close();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Doktorlar (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTc,DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)", sb.baglanti());
            komut.Parameters.AddWithValue("@d1", txtAd.Text);
            komut.Parameters.AddWithValue("@d2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@d3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@d4", mskTc.Text);
            komut.Parameters.AddWithValue("@d5", txtSifre.Text);
            komut.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("bilgiler eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Tbl_Doktorlar where DoktorTc =@p1", sb.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTc.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Bilgiler silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sb.baglanti().Close();

            txtAd.Clear();
            txtSifre.Clear();
            txtSoyad.Clear();
            mskTc.Clear();
            mskTc.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doktorlar set DoktorAd= @p1,DoktorSoyad= @p2,DoktorBrans= @p3,DoktorSifre= @p4   where DoktorTc=@p5  ", sb.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p4", txtSifre.Text);
            komut.Parameters.AddWithValue("@p5", mskTc.Text);

            komut.ExecuteNonQuery();
            sb.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Doktorlar", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
    }
}
