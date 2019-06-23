using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HastaneYönetimVeRandevuSistemi
{
    class sqlBaglantısı
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-LQ9NQVA;Initial Catalog=HastaneProje;Integrated Security=True");
            baglan.Open();
            return baglan;


        }
        }
}
