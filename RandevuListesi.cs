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
    public partial class RandevuListesi : Form
    {
        public RandevuListesi()
        {
            InitializeComponent();
        }
        sqlBaglantısı sb = new sqlBaglantısı();
        private void RandevuListesi_Load(object sender, EventArgs e)
        {
            //GÖRÜNTÜLEME
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular", sb.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


          

        }


       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }
    }
}
