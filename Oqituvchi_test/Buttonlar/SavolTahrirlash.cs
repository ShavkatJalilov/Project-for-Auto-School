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
using Guna.UI2.WinForms;
using System.Drawing.Imaging;
using System.IO;

namespace Oqituvchi_test.Buttonlar
{
    public partial class SavolTahrirlash : Form
    {
        private string connstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files (x86)\JIZZAKH AUTO SCHOOL\Setup\Avtotest1.mdf;Integrated Security=True";
        private SqlConnection sql = null;
        public SavolTahrirlash()
        {
            InitializeComponent();
        }
        private int rasm =0;

        public void clearAll()
        {
            txtSavol.Clear();
            txtTanlovA.Clear();
            txtTanlovB.Clear();
            txtTanlovC.Clear();
            txtTanlovD.Clear();
            txtjavob.Clear();
            guna2TextBox1.Clear();
            guna2PictureBox1.Image = null;

        }

        private void btnKeyingi_Click(object sender, EventArgs e)
        {

            //if (rasm == 0)
            //{
            //    Guna2TextBox[] textboxv = { txtTanlovA, txtTanlovB, txtTanlovC, txtTanlovD };
            //    sql.Open();
            //    var cmd = new SqlCommand($"update [Savollar] set savol=@savol, Avariant=@tanlovA,Bvariant=@tanlovB,Cvariant=@tanlovC,Dvariant=@tanlovD,javob=@javob,Izoh=@izoh,rasm=@rasm where id={int.Parse(guna2ComboBox1.SelectedItem.ToString())}", sql);
            //    cmd.Parameters.AddWithValue("@savol", txtSavol.Text);
            //    cmd.Parameters.AddWithValue("@tanlovA", txtTanlovA.Text);
            //    cmd.Parameters.AddWithValue("@tanlovB", txtTanlovB.Text);
            //    cmd.Parameters.AddWithValue("@tanlovC", txtTanlovC.Text);
            //    cmd.Parameters.AddWithValue("@tanlovD", txtTanlovD.Text);
            //    cmd.Parameters.AddWithValue("@javob", txtjavob.Text);
            //    cmd.Parameters.AddWithValue("@izoh", guna2TextBox1.Text);
            //    MemoryStream ms = new MemoryStream();
            //    guna2PictureBox2.Image.Save(ms, ImageFormat.Jpeg);
            //    Byte[] bytBloadData = new Byte[ms.Length];
            //    ms.Position = 0;
            //    ms.Read(bytBloadData, 0, Convert.ToInt32(ms.Length));
            //    SqlParameter prm = new SqlParameter("@rasm", SqlDbType.VarBinary, bytBloadData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytBloadData);
            //    cmd.Parameters.Add(prm);
            //    cmd.ExecuteNonQuery();
            //    sql.Close();
            //    clearAll();
            //    rasm = 0;
            //}
            //else
            //{
                Guna2TextBox[] textboxv = { txtTanlovA, txtTanlovB, txtTanlovC, txtTanlovD };
                sql.Open();
                var cmd = new SqlCommand($"update [Savollar] set savol=@savol, Avariant=@tanlovA,Bvariant=@tanlovB,Cvariant=@tanlovC,Dvariant=@tanlovD,javob=@javob,Izoh=@izoh,rasm=@rasm where id={int.Parse(guna2ComboBox1.SelectedItem.ToString())}", sql);
                cmd.Parameters.AddWithValue("@savol", txtSavol.Text);
                cmd.Parameters.AddWithValue("@tanlovA", txtTanlovA.Text);
                cmd.Parameters.AddWithValue("@tanlovB", txtTanlovB.Text);
                cmd.Parameters.AddWithValue("@tanlovC", txtTanlovC.Text);
                cmd.Parameters.AddWithValue("@tanlovD", txtTanlovD.Text);
                cmd.Parameters.AddWithValue("@javob", txtjavob.Text);
                cmd.Parameters.AddWithValue("@izoh", guna2TextBox1.Text);
                MemoryStream ms = new MemoryStream();
                guna2PictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                Byte[] bytBloadData = new Byte[ms.Length];
                ms.Position = 0;
                ms.Read(bytBloadData, 0, Convert.ToInt32(ms.Length));
                SqlParameter prm = new SqlParameter("@rasm", SqlDbType.VarBinary, bytBloadData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytBloadData);
                cmd.Parameters.Add(prm);
                cmd.ExecuteNonQuery();
                sql.Close();
                clearAll();
                rasm = 0;
            //}        
        }

        private void SavolTahrirlash_Load(object sender, EventArgs e)
        {
            sql = new SqlConnection(connstring);

            sql.Open();

            var cmd = new SqlCommand($"select id from Savollar", sql);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                guna2ComboBox1.Items.Add(reader.GetInt32(0));
            }
            sql.Close();
        }
        private void txtsavolnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            sql.Open();
            var cmds = new SqlCommand($"select savol from Savollar where id={int.Parse(guna2ComboBox1.SelectedItem.ToString())}", sql);
            var readers = cmds.ExecuteReader();

            while (readers.Read())
            {
                txtSavol.Text = readers.GetString(0);
            }
            sql.Close();
            sql.Open();

            var cmdv = new SqlCommand($"select Avariant,Bvariant,Cvariant,Dvariant,javob, Izoh, rasm from Savollar where id={int.Parse(guna2ComboBox1.SelectedItem.ToString())}", sql);
            var readerv = cmdv.ExecuteReader();

            while (readerv.Read())
            {
                txtTanlovA.Text = readerv.GetString(0);
                txtTanlovB.Text = readerv.GetString(1);
                txtTanlovC.Text = readerv.GetString(2);
                txtTanlovD.Text = readerv.GetString(3);
                txtjavob.Text = readerv.GetString(4);
                guna2TextBox1.Text = readerv.GetString(5);


            }
            sql.Close();

            sql.Open();
            SqlCommand cmd2 = new SqlCommand($"select rasm from Savollar where id={int.Parse(guna2ComboBox1.SelectedItem.ToString())}", sql);
            var reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                MemoryStream stream = new MemoryStream(reader2.GetSqlBytes(0).Buffer);
                guna2PictureBox1.Image = Image.FromStream(stream);
            }
            sql.Close();
            if (txtjavob.Text.Equals(txtTanlovA.Text))
            {
                javobcom.Text = "A";
                txtTanlovA.FillColor = Color.Green;
            }
            if (txtjavob.Text.Equals(txtTanlovB.Text))
            {
                javobcom.Text = "B";
                txtTanlovB.FillColor = Color.Green;
            }
            if (txtjavob.Text.Equals(txtTanlovC.Text))
            {
                javobcom.Text = "C";
                txtTanlovC.FillColor = Color.Green;
            }
            if (txtjavob.Text.Equals(txtTanlovD.Text))
            {
                javobcom.Text = "D";
                txtTanlovD.FillColor = Color.Green;
            }
            sql.Close();
        }

        private void javobcom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (javobcom.SelectedItem.ToString().Equals("A"))
            {
                txtTanlovA.FillColor = Color.Green;
                txtjavob.Text = txtTanlovA.Text;
                txtTanlovB.FillColor = Color.White;
                txtTanlovC.FillColor = Color.White;
                txtTanlovD.FillColor = Color.White;
            }
            if (javobcom.SelectedItem.ToString().Equals("B"))
            {
                txtTanlovA.FillColor = Color.White;
                txtTanlovB.FillColor = Color.Green;
                txtjavob.Text = txtTanlovB.Text;
                txtTanlovC.FillColor = Color.White;
                txtTanlovD.FillColor = Color.White;
            }
            if (javobcom.SelectedItem.ToString().Equals("C"))
            {
                txtTanlovA.FillColor = Color.White;
                txtTanlovB.FillColor = Color.White;
                txtTanlovC.FillColor = Color.Green;
                txtjavob.Text = txtTanlovC.Text;
                txtTanlovD.FillColor = Color.White;
            }
            if (javobcom.SelectedItem.ToString().Equals("D"))
            {
                txtTanlovA.FillColor = Color.White;
                txtTanlovB.FillColor = Color.White;
                txtTanlovC.FillColor = Color.White;
                txtTanlovD.FillColor = Color.Green;
                txtjavob.Text = txtTanlovD.Text;
            }
        }

        private void btnQaytadan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Saqlamasdan davom ettirasizmi ?", "OGOHLANTIRISH", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearAll();
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            rasm=1;
            Bitmap image;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "ImageFiles(*.JPG)|*.JPG";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = new Bitmap(openFile.FileName);
                    guna2PictureBox1.Image = image;
                    guna2PictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Faylni ochib bo'lmadi", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2PictureBox1.Image = null;
            rasm = 0;
        }

        private void txtSavol_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
