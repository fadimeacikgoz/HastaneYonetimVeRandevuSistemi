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
    public partial class BranşPaneli : Form
    {
        public BranşPaneli()
        {
            InitializeComponent();
        }
        sqlBaglantısı sb = new sqlBaglantısı();
        private void BranşPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBrans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {    //EKLEME
            SqlCommand komut = new SqlCommand("insert into Tbl_Branslar  (BransAd) values(@p1)", sb.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBrans.Text);
            komut.ExecuteNonQuery();
            sb.baglanti().Close();



            //GÖRÜNTÜLEME
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            MessageBox.Show("Kayıt Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            //SİLME
           
            SqlCommand komut = new SqlCommand("Delete  from Tbl_Branslar  where  BransId=@p1",sb.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            sb.baglanti().Close();


            //GÖRÜNTÜLEME
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           

            MessageBox.Show("Kayıt Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            //GÜNCELLEME
            SqlCommand komut = new SqlCommand("Update Tbl_Branslar set  BransAd=@p1 where BransId=@p2", sb.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBrans.Text);
            komut.Parameters.AddWithValue("@p2", txtId.Text);
            komut.ExecuteNonQuery();
            sb.baglanti().Close();

            //GÖRÜNTÜLEME
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Branslar", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            MessageBox.Show("Kayıt Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
