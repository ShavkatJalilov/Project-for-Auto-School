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

namespace Oqituvchi_test.Buttonlar
{
    public partial class LoginParols : Form
    {
        public LoginParols()
        {
            InitializeComponent();
        }
        SqlConnection sql = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC-SHOP\Documents\Test.mdf;Integrated Security=True;Connect Timeout=30");

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            sql.Open();
            var cmd = new SqlCommand($"select Logins, Parols from Login where Logins='{guna2TextBox1.Text}' and Parols='{guna2TextBox2.Text}' and Lavozim='admin'", sql);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if(reader.GetString(0).Equals(guna2TextBox1.Text) && reader.GetString(1).Equals(guna2TextBox2.Text))
                {
                    i++;
                }
            }
            sql.Close();
           
            if (i != 0)
            {
                if (guna2TextBox3.Text.Length > 4 && guna2TextBox5.Text.Length > 4 && guna2TextBox4.Text.Length > 4)
                {
                    if (guna2TextBox3.Text.Equals(guna2TextBox5.Text))
                        {
                            if (guna2ComboBox1.SelectedIndex!=-1)
                            {
                                xato6.Visible = false;
                                int i2 = 0;
                                sql.Open();                           
                                var cmd2 = new SqlCommand($"select Logins, Parols from Login where Logins='{guna2TextBox4.Text}' and Parols='{guna2TextBox3.Text}' and Lavozim='{guna2ComboBox1.SelectedItem.ToString()}'", sql);
                                var reader1 = cmd2.ExecuteReader();
                                while (reader1.Read())
                                {
                                    if (reader1.GetString(0).Equals(guna2TextBox4.Text) && reader1.GetString(1).Equals(guna2TextBox5.Text))
                                    {
                                        i2++;
                                    }
                                }

                                sql.Close();
                                if (i2 == 0)
                                {
                                    sql.Open();
                                    var cmd1 = new SqlCommand("insert into [Login](Logins,Parols,Lavozim,Activ)values(@Logins,@Parols,@Lavozim,@Activ)", sql);
                                    cmd1.Parameters.AddWithValue("@Logins", guna2TextBox4.Text);
                                    cmd1.Parameters.AddWithValue("@Parols", guna2TextBox5.Text);
                                    cmd1.Parameters.AddWithValue("@Lavozim", guna2ComboBox1.SelectedItem.ToString());
                                    cmd1.Parameters.AddWithValue("@Activ", (0).ToString());
                                    cmd1.ExecuteNonQuery();
                                    sql.Close();
                                    var sqladapter = new SqlDataAdapter("select * from Login", sql);
                                    DataSet dt = new DataSet();
                                    sqladapter.Fill(dt);
                                    guna2DataGridView1.DataSource = dt.Tables[0];
                                    for (int i1 = 0; i1 < guna2DataGridView1.RowCount; i1++)
                                    {
                                        guna2DataGridView1.Rows[i1].Cells[0].Value = (i1 + 1).ToString();
                                    }
                                    guna2TextBox3.Text = "";
                                    guna2TextBox4.Text = "";
                                    guna2TextBox5.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Bunay Login parolga ega bo'lgan foydalanuvchi mavjud!!! \n Iltimos boshqa login parol kiriting !!!","Ogohlantirish");
                                }
                            }
                            else
                            {
                                xato6.Text = "Turini tanlang";
                                xato6.Visible = true;
                            }
                        }
                        else
                        {
                            xato4.Text = "Parollar bir xil emas !!!";
                            xato5.Text = "Parollar bir xil emas !!!";
                            xato4.Visible = true;
                            xato5.Visible = true;
                        }
            }
            else
            {
                xato3.Visible = true;
                xato4.Visible = true;
                xato5.Visible = true;
                xato3.Text = "Login juda oson min 5 ta";
                xato4.Text = "Parol juda oson min 5 ta";
                xato5.Text = "Parol juda oson min 5 ta";
            }
        }
            else
            {
                xato1.Text = "Login yoki parol xato !!!";
                xato2.Text = "Login yoki parol xato !!!";
                xato1.Visible = true;
                xato2.Visible = true;
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
            }
        }

        private void LoginParols_Load(object sender, EventArgs e)
        {
            guna2Button1.Enabled = false;
            guna2Button2.Enabled = false;
            guna2Button3.Enabled = false;
            xato1.Visible = false;
            xato2.Visible = false;
            xato3.Visible = false;
            xato4.Visible = false;
            xato5.Visible = false;
            xato6.Visible = false;
            xato1.Text = "Maydonni to'ldiring";
            xato2.Text = "Maydonni to'ldiring";
            xato3.Text = "Maydonni to'ldiring";
            xato4.Text = "Maydonni to'ldiring";
            xato5.Text = "Maydonni to'ldiring";
            xato6.Text = "Maydonni to'ldiring";
            sql.Open();
            var sqladapter = new SqlDataAdapter("select * from Login", sql);
            DataSet dt = new DataSet();
            sqladapter.Fill(dt);
            guna2DataGridView1.DataSource = dt.Tables[0];

            sql.Close();
            for (int i = 0; i < guna2DataGridView1.RowCount; i++)
            {
                guna2DataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }

        }
        char[] belgi = { ' ', '/', '*', '+', '-', '\'', '!', '@', '#', '$', '%', '^', '&', '(', ')', '_', '=', '`', '~', '.' };

        private void timer1_Tick(object sender, EventArgs e)
        {
            int k = 0;
            int j = 0;
            if (!guna2TextBox1.Text.Equals(belgi) && guna2TextBox1.Text != "") { k++; j++;  }
            if (!guna2TextBox2.Text.Equals(belgi) && guna2TextBox2.Text != "") { k++; j++; } 
            if (!guna2TextBox3.Text.Equals(belgi) && guna2TextBox3.Text != "") { k++; j++;  } 
            if (!guna2TextBox4.Text.Equals(belgi) && guna2TextBox4.Text != "") { k++; j++;  } 
            if (!guna2TextBox5.Text.Equals(belgi) && guna2TextBox5.Text != "") { k++;  } 
            if (k>4)
            {
                guna2Button1.Enabled = true;
                guna2Button2.Enabled = true;
                guna2Button3.Enabled = true;
            }
            if (j > 3)
            {
                guna2Button2.Enabled = true;
                guna2Button3.Enabled = true;
            }
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int i = 0;
            sql.Open();
            var cmd = new SqlCommand($"select Logins, Parols from Login where Logins='{guna2TextBox1.Text}' and Parols='{guna2TextBox2.Text}' and Lavozim='admin'", sql);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Equals(guna2TextBox1.Text) && reader.GetString(1).Equals(guna2TextBox2.Text))
                {
                    i++;
                }
            }
            sql.Close();
            if (i != 0)
            {
                try
                {
                    if (guna2TextBox3.Text.Equals(guna2TextBox5.Text))
                    {
                        xato4.Visible = false;
                        xato5.Visible = false;
                        sql.Open();
                        var cmd1 = new SqlCommand($"delete from Login where  Parols='{guna2TextBox5.Text}' and Logins='{guna2TextBox4.Text}'", sql);
                        var read = cmd1.ExecuteNonQuery();
                        sql.Close();
                        var sqladapter = new SqlDataAdapter("select * from Login", sql);
                        DataSet dt = new DataSet();
                        sqladapter.Fill(dt);
                        guna2DataGridView1.DataSource = dt.Tables[0];

                        sql.Close();
                        for (int i1 = 0; i1 < guna2DataGridView1.RowCount; i1++)
                        {
                            guna2DataGridView1.Rows[i1].Cells[0].Value = (i1 + 1).ToString();
                        }
                        guna2TextBox3.Text = "";
                        guna2TextBox4.Text = "";
                        guna2TextBox5.Text = "";
                    }
                    else
                    {
                        xato4.Text = "Parollar bir xil emas";
                        xato5.Text = "Parollar bir xil emas";
                        xato4.Visible = true;
                        xato5.Visible = true;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Siz kiritgan Login va Parol ma'lumotlar bazasida mavjud emas ya'ni bunday foydalanuvchi ro'yxatdan o'tmagan","Ogohlantirsh xatolik");
                    guna2TextBox3.Text = "";
                    guna2TextBox4.Text = "";
                }
                                     
            }
            else
            {
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                xato1.Visible = true;
                xato2.Visible = true;
                xato1.Text = "Login yoki parol xato !!!";
                xato2.Text = "Login yoki parol xato !!!";
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            sql.Open();
            var cmd = new SqlCommand($"select Logins, Parols from Login where Logins='{guna2TextBox1.Text}' and Parols='{guna2TextBox2.Text}' and Lavozim='admin'", sql);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(0).Equals(guna2TextBox1.Text) && reader.GetString(1).Equals(guna2TextBox2.Text))
                {
                    i++;
                }
            }
            sql.Close();
            if (i != 0)
            {
                if (guna2TextBox3.Text.Length > 4 && guna2TextBox5.Text.Length > 4)
                {
                    if (guna2TextBox3.Text.Equals(guna2TextBox5.Text))
                    {
                        xato4.Visible = false;
                        xato5.Visible = false;
                        sql.Open();
                        var cmd1 = new SqlCommand($" update Login set Parols='{guna2TextBox5.Text}' where Logins='{guna2TextBox4.Text}'", sql);
                        var read = cmd1.ExecuteNonQuery();
                        sql.Close();
                        var sqladapter = new SqlDataAdapter("select * from Login", sql);
                        DataSet dt = new DataSet();
                        sqladapter.Fill(dt);
                        guna2DataGridView1.DataSource = dt.Tables[0];

                        sql.Close();
                        for (int i1 = 0; i1 < guna2DataGridView1.RowCount; i1++)
                        {
                            guna2DataGridView1.Rows[i1].Cells[0].Value = (i1 + 1).ToString();
                        }
                        guna2TextBox3.Text = "";
                        guna2TextBox4.Text = "";
                        guna2TextBox5.Text = "";

                    }
                    else
                    {
                        xato4.Text = "Parollar bir xil emas";
                        xato5.Text = "Parollar bir xil emas";
                        xato4.Visible = true;
                        xato5.Visible = true;
                    }
                }
                else
                {
                    xato4.Text = "Parol juda oson min 5 ta belgi";
                    xato5.Text = "Parol juda oson min 5 ta belgi";
                    xato4.Visible = true;
                    xato5.Visible = true;
                }

            }
            else
            {
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                xato1.Visible = true;
                xato2.Visible = true;
                xato1.Text = "Login yoki parol xato !!!";
                xato2.Text = "Login yoki parol xato !!!";
            }
        }
        private int selectrow;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectrow = e.RowIndex;
            guna2TextBox4.Text = guna2DataGridView1.Rows[selectrow].Cells[1].Value.ToString();
            guna2TextBox3.Text = guna2DataGridView1.Rows[selectrow].Cells[2].Value.ToString();
            guna2TextBox5.Text = guna2DataGridView1.Rows[selectrow].Cells[2].Value.ToString();

        }
    }
}
