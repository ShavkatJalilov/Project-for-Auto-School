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

namespace Oqituvchi_test.Buttonlar
{
    public partial class SKorishVaOchirish : Form
    {
        private string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files (x86)\JIZZAKH AUTO SCHOOL\Setup\Avtotest1.mdf;Integrated Security=True";
        private SqlConnection sql = null;
        private int selectrow;
        public SKorishVaOchirish()
        {
            InitializeComponent();
        }

        private void SKorishVaOchirish_Load(object sender, EventArgs e)
        {

            sql = new SqlConnection(connstring);
            sql.Open();
            var sqladapter = new SqlDataAdapter("select * from Savollar", sql);
            DataSet dt = new DataSet();
            sqladapter.Fill(dt);
            svdg.DataSource = dt.Tables[0];
            sql.Close();
        }

        public void ekranga()
        {
            sql.Open();
            var sqladapter = new SqlDataAdapter("select * from Savollar", sql);
            DataSet dt = new DataSet();
            sqladapter.Fill(dt);
            svdg.DataSource = dt.Tables[0];

            sql.Close();
           
        }


        private void svdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectrow = e.RowIndex;
            guna2TextBox1.Text = svdg.Rows[selectrow].Cells[0].Value.ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            sql.Open();
            var sqladapter = new SqlDataAdapter($"select * from Savollar where id={int.Parse(guna2TextBox1.Text)}", sql);
            DataSet dt = new DataSet();
            sqladapter.Fill(dt);
            svdg.DataSource = dt.Tables[0];

            sql.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ekranga();
        }
    }
}
