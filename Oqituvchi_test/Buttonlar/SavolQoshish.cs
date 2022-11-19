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
    public partial class SavolQoshish : Form
    {
        private string connstring = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files (x86)\JIZZAKH AUTO SCHOOL\Setup\Avtotest1.mdf;Integrated Security=True");
        private SqlConnection sql = null;

        
        public SavolQoshish()
        {
            InitializeComponent();
            LoadTheme();
        }
        public void savolraqam()
        {
            sql = new SqlConnection(connstring);          
                sql.Open();
                var cmd = new SqlCommand($"select * from Savollar", sql);
                var reader = cmd.ExecuteReader();
                int k = 0;
                while (reader.Read())
                {
                    k++;
                }
                if (k > 0)
                {
                    label4.Text = (k + 1).ToString();
                }
                else
                {
                    label4.Text = "1";
                }
                sql.Close();
            
        }

        private void SavolQoshish_Load(object sender, EventArgs e)
        {
            savolraqam();
        }

        public void clearAll()
        {
            txtSavol.Clear();
            txtTanlovA.Clear();
            txtTanlovB.Clear();
            txtTanlovC.Clear();
            txtTanlovD.Clear();
            txtjavob.Clear();
            izohtxt.Clear();
            guna2PictureBox1.Image = null;
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btns.BackColor = FonRangi.PrimaryColor;
                    btns.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = FonRangi.SecondaryColor;
                }
            }
        }
        public int rasm = 0;
            private void btnKeyingi_Click(object sender, EventArgs e)
        {
            if(!txtSavol.Text.Equals("") && !txtTanlovA.Text.Equals("") && !txtTanlovB.Text.Equals("") && !txtTanlovC.Text.Equals("") && !txtTanlovD.Text.Equals("") && !izohtxt.Text.Equals("") && !txtjavob.Text.Equals(""))
            {
                Guna2TextBox[] textboxv = { txtTanlovA, txtTanlovB, txtTanlovC, txtTanlovD };
                sql.Open();
                if (rasm != 0)
                {
                    var cmd = new SqlCommand("insert into [Savollar](id,savol,Avariant,Bvariant,Cvariant,Dvariant,javob,Izoh,rasm)values(@id,@savol,@Avariant,@Bvariant,@Cvariant,@Dvariant,@javob,@Izoh,@rasm)", sql);
                    cmd.Parameters.AddWithValue("@id", int.Parse(label4.Text));
                    cmd.Parameters.AddWithValue("@savol", txtSavol.Text);
                    cmd.Parameters.AddWithValue("@Avariant", txtTanlovA.Text);
                    cmd.Parameters.AddWithValue("@Bvariant", txtTanlovB.Text);
                    cmd.Parameters.AddWithValue("@Cvariant", txtTanlovC.Text);
                    cmd.Parameters.AddWithValue("@Dvariant", txtTanlovD.Text);
                    cmd.Parameters.AddWithValue("@javob", txtjavob.Text);
                    cmd.Parameters.AddWithValue("@Izoh", izohtxt.Text);
                    MemoryStream ms = new MemoryStream();
                    guna2PictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                    Byte[] bytBloadData = new Byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(bytBloadData, 0, Convert.ToInt32(ms.Length));
                    SqlParameter prm = new SqlParameter("@rasm", SqlDbType.VarBinary, bytBloadData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytBloadData);
                    cmd.Parameters.Add(prm);
                    cmd.ExecuteNonQuery();
                    guna2PictureBox1.Image = null;
                    rasm = 0;
                }
                else if (rasm == 0)
                {
                    var cmd = new SqlCommand("insert into [Savollar](id,savol,Avariant,Bvariant,Cvariant,Dvariant,javob,Izoh,rasm)values(@id,@savol,@Avariant,@Bvariant,@Cvariant,@Dvariant,@javob,@Izoh,@rasm)", sql);
                    cmd.Parameters.AddWithValue("@id", int.Parse(label4.Text));
                    cmd.Parameters.AddWithValue("@savol", txtSavol.Text);
                    cmd.Parameters.AddWithValue("@Avariant", txtTanlovA.Text);
                    cmd.Parameters.AddWithValue("@Bvariant", txtTanlovB.Text);
                    cmd.Parameters.AddWithValue("@Cvariant", txtTanlovC.Text);
                    cmd.Parameters.AddWithValue("@Dvariant", txtTanlovD.Text);
                    cmd.Parameters.AddWithValue("@javob", txtjavob.Text);
                    cmd.Parameters.AddWithValue("@Izoh", izohtxt.Text);
                    MemoryStream ms = new MemoryStream();
                    guna2PictureBox2.Image.Save(ms, ImageFormat.Jpeg);
                    Byte[] bytBloadData = new Byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(bytBloadData, 0, Convert.ToInt32(ms.Length));
                    SqlParameter prm = new SqlParameter("@rasm", SqlDbType.VarBinary, bytBloadData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, bytBloadData);
                    cmd.Parameters.Add(prm);
                    cmd.ExecuteNonQuery();
                    rasm = 0;

                }

                sql.Close();
                savolraqam();
                clearAll();


                foreach (var v in textboxv)
                {
                    v.FillColor = Color.White;
                }
                guna2ComboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Barcha maydonlarga ma'lumotlarni kiriting !!!", "Ogohlaantirish");
            }
          
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedItem.ToString().Equals("A"))
            {
                txtTanlovA.FillColor = Color.Green;
                txtjavob.Text = txtTanlovA.Text;
                txtTanlovB.FillColor = Color.White;
                txtTanlovC.FillColor = Color.White;
                txtTanlovD.FillColor = Color.White;
            }
            if (guna2ComboBox1.SelectedItem.ToString().Equals("B"))
            {
                txtTanlovA.FillColor = Color.White;
                txtTanlovB.FillColor = Color.Green;
                txtjavob.Text = txtTanlovB.Text;
                txtTanlovC.FillColor = Color.White;
                txtTanlovD.FillColor = Color.White;
            }
            if (guna2ComboBox1.SelectedItem.ToString().Equals("C"))
            {
                txtTanlovA.FillColor = Color.White;
                txtTanlovB.FillColor = Color.White;
                txtTanlovC.FillColor = Color.Green;
                txtjavob.Text = txtTanlovC.Text;
                txtTanlovD.FillColor = Color.White;
            }
            if (guna2ComboBox1.SelectedItem.ToString().Equals("D"))
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
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            rasm++;
            Bitmap image;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "ImageFiles(*.JPG)|*.JPG;(*.PNG)|*.PNG;(*.JPEG)|*.JPEG";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                  image=new  Bitmap(openFile.FileName);
                    guna2PictureBox1.Image = image;
                    guna2PictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Faylni ochib bo'lmadi", "Xatolik", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            
            }
        }
    }
}
