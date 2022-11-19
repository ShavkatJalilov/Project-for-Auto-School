using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oqituvchi_test.Talaba
{
    public partial class TalabaNatija : Form
    {
        SqlConnection sql = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC-SHOP\source\repos\Oqituvchi_test\Oqituvchi_test\Oqituvchi_test\Avtotest1.mdf;Integrated Security=True");

        public TalabaNatija()
        {
            InitializeComponent();
        }

        private void TalabaNatija_Load(object sender, EventArgs e)
        {
            string fish = null;
            sql.Open();
            var cmd1 = new SqlCommand("select TalabaIsmi from Login where TalabaActiv=1", sql);
            var reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                fish = reader1.GetString(0);
            }
            sql.Close();

            sql.Open();

            var cmd = new SqlCommand($"select * from TalabaNatija where FISH='{fish}'", sql);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                richTextBox1.Text = reader.GetString(1) + "\n" + reader.GetString(2)+"\n"+ reader.GetInt32(3) + "\n" + reader.GetInt32(4)+"\n";
            }
            sql.Close();
        }

        private void btnSaqlash_Click(object sender, EventArgs e)
        {

        }
    }
}
