using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oqituvchi_test.Talaba
{
    public partial class testishlash : Form
    {

        int togri=0;
        int test = 0;
        int notugri = 0;
        private string fish = null, guruh = null;

        SqlConnection sql = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files (x86)\JIZZAKH AUTO SCHOOL\Setup\Avtotest1.mdf;Integrated Security=True");
        int c = 0;
        public testishlash()
        {
            InitializeComponent();
        }

        int k = 0;
        int soniya = 59, minut = 24;
        int k1 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (k1 == 0)
            {
                soniya--;
                if (soniya <= 0)
                {
                    minut--;
                    soniya = 59;
                    if (minut == 0)
                    {
                        k1 = 1;
                        label6.ForeColor = Color.Red;
                    }
                    label2.Text = minut.ToString();
                }
                label6.Text = soniya.ToString();
            }
            if (k1 == 1)
            {
                soniya--;
                if (soniya == 0)
                {
                    timer2.Stop();
                    if (togri < 18)
                    {                       
                        timer2.Stop();
                       if(MessageBox.Show("Kechirasi sizning vaqtingiz tugadi siz ushbu testdan o`tolmadiz !!!\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Muavffaqiyatsizlik", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            this.Close();
                            Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                            testishlash.Show();
                        }
                        timer1.Stop();
                        string daq = "25:00";
                    }
                    if (test == 20)
                    {
                        if (togri == 17)
                        {
                            timer2.Stop();
                           if(MessageBox.Show("Kechirasi sizning vaqtingiz tugadi siz ushbu testdan muavffaqiyatli o'tdingiz sizning bahoyingi 'Qoniqarli' !!!\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                this.Close();
                                Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                                testishlash.Show();
                            }
                            timer1.Stop();
                            string daq = "25:00";
                        }
                        if (togri == 18)
                        {
                            timer2.Stop();
                           if(MessageBox.Show("Kechirasi sizning vaqtingiz tugadi siz ushbu testdan muavffaqiyatli o'tdingiz sizning bahoyingi 'Yaxshi' !!!\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                this.Close();
                                Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                                testishlash.Show();
                            }
                            timer1.Stop();
                            string daq = "25:00";
                        }
                        if (togri >= 19)
                        {
                            timer2.Stop();
                           if(MessageBox.Show("Kechirasi sizning vaqtingiz tugadi siz ushbu testdan muavffaqiyatli o'tdingiz sizning bahoyingi 'A'lo' !!!\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                this.Close();
                                Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                                testishlash.Show();
                            }                            
                            timer1.Stop();
                            string daq = "25:00";
                        }
                    }
                   

                }
                label6.Text = soniya.ToString();
            }
        }

        public int var_soni()
        {
            int k = 0;
            sql.Open();

            var command = new SqlCommand($"select * from  Savollar", sql);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                k++;
            }
            reader.Close();
            sql.Close();
            return k;
        }

        public void ekranga1(int c)
        {
            int id = 0;
            sql.Open();
            SqlCommand cmd = new SqlCommand($"select savolId,javob from Bilet where tr={c}", sql);
            var reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                id = reader.GetInt32(0);

            }
            sql.Close();
            var rand = new Random();
            List<int> possible = Enumerable.Range(1, 4).ToList();
            List<int> listNumbers = new List<int>();
            int[] son1 = new int[4];
            for (int i1 = 0; i1 < 4; i1++)
            {
                int index = rand.Next(0, possible.Count);
                listNumbers.Add(possible[index]);
                possible.RemoveAt(index);
            }
            int j1 = 0;
            foreach (int i1 in listNumbers)
            {
                son1[j1] = i1;
                j1++;
            }

            int j = 0;
            sql.Open();
            SqlCommand cmd1 = new SqlCommand($"select savol,Avariant,Bvariant,Cvariant,Dvariant,Izoh from Savollar where id={id}", sql);
            var reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                savoltxt.Text = reader1.GetString(0);
                txt_A.Text = reader1.GetString(son1[0]);
                txt_B.Text = reader1.GetString(son1[1]);
                txt_C.Text = reader1.GetString(son1[2]);
                txt_D.Text = reader1.GetString(son1[3]);
                izohtxt.Text = reader1.GetString(5);               
                j++;
            }

            sql.Close();

            sql.Open();
            SqlCommand cmd2 = new SqlCommand($"select rasm from Savollar where id={id}", sql);
            var reader2= cmd2.ExecuteReader();
            if (reader2.Read())
            {
                MemoryStream stream = new MemoryStream(reader2.GetSqlBytes(0).Buffer);
                pictureBox1.Image = Image.FromStream(stream);
            }
            sql.Close();
            izohtxt.Visible = false;
        }
      
        public void tugma(int raqam)
        {
            if (raqam == 1) { guna2Button1.BorderRadius = 14; guna2Button1.FillColor = Color.Green; guna2Button1.BackColor = Color.Transparent; }
            if (raqam == 2) { guna2Button2.BorderRadius = 14; guna2Button2.FillColor = Color.Green; guna2Button2.BackColor = Color.Transparent; }
            if (raqam == 3) { guna2Button3.BorderRadius = 14; guna2Button3.FillColor = Color.Green; guna2Button3.BackColor = Color.Transparent; }
            if (raqam == 4) { guna2Button4.BorderRadius = 14; guna2Button4.FillColor = Color.Green; guna2Button4.BackColor = Color.Transparent; }
            if (raqam == 5) { guna2Button5.BorderRadius = 14; guna2Button5.FillColor = Color.Green; guna2Button5.BackColor = Color.Transparent; }
            if (raqam == 6) { guna2Button6.BorderRadius = 14; guna2Button6.FillColor = Color.Green; guna2Button6.BackColor = Color.Transparent; }
            if (raqam == 7) { guna2Button7.BorderRadius = 14; guna2Button7.FillColor = Color.Green; guna2Button7.BackColor = Color.Transparent; }
            if (raqam == 8) { guna2Button8.BorderRadius = 14; guna2Button8.FillColor = Color.Green; guna2Button8.BackColor = Color.Transparent; }
            if (raqam == 9) { guna2Button9.BorderRadius = 14; guna2Button9.FillColor = Color.Green; guna2Button9.BackColor = Color.Transparent; }
            if (raqam == 10) { guna2Button10.BorderRadius = 14; guna2Button10.FillColor = Color.Green; guna2Button10.BackColor = Color.Transparent; }
            if (raqam == 11) { guna2Button11.BorderRadius = 14; guna2Button11.FillColor = Color.Green; guna2Button11.BackColor = Color.Transparent; }
            if (raqam == 12) { guna2Button12.BorderRadius = 14; guna2Button12.FillColor = Color.Green; guna2Button12.BackColor = Color.Transparent; }
            if (raqam == 13) { guna2Button13.BorderRadius = 14; guna2Button13.FillColor = Color.Green; guna2Button13.BackColor = Color.Transparent; }
            if (raqam == 14) { guna2Button14.BorderRadius = 14; guna2Button14.FillColor = Color.Green; guna2Button14.BackColor = Color.Transparent; }
            if (raqam == 15) { guna2Button15.BorderRadius = 14; guna2Button15.FillColor = Color.Green; guna2Button15.BackColor = Color.Transparent; }
            if (raqam == 16) { guna2Button16.BorderRadius = 14; guna2Button16.FillColor = Color.Green; guna2Button16.BackColor = Color.Transparent; }
            if (raqam == 17) { guna2Button17.BorderRadius = 14; guna2Button17.FillColor = Color.Green; guna2Button17.BackColor = Color.Transparent; }
            if (raqam == 18) { guna2Button18.BorderRadius = 14; guna2Button18.FillColor = Color.Green; guna2Button18.BackColor = Color.Transparent; }
            if (raqam == 19) { guna2Button19.BorderRadius = 14; guna2Button19.FillColor = Color.Green; guna2Button19.BackColor = Color.Transparent; }
            if (raqam == 20) { guna2Button20.BorderRadius = 14; guna2Button20.FillColor = Color.Green; guna2Button20.BackColor = Color.Transparent; }
        }

        public void tugmafalse(int raqam)
        {
            if (raqam == 1) { guna2Button1.BackColor = Color.Red; guna2Button1.FillColor = Color.Red; guna2Button1.BorderColor = Color.Red; }
            if (raqam == 2) { guna2Button2.BackColor = Color.Red; guna2Button2.FillColor = Color.Red; guna2Button2.BorderColor = Color.Red; }
            if (raqam == 3) { guna2Button3.BackColor = Color.Red; guna2Button3.FillColor = Color.Red; guna2Button3.BorderColor = Color.Red; }
            if (raqam == 4) { guna2Button4.BackColor = Color.Red; guna2Button4.FillColor = Color.Red; guna2Button4.BorderColor = Color.Red; }
            if (raqam == 5) { guna2Button5.BackColor = Color.Red; guna2Button5.FillColor = Color.Red; guna2Button5.BorderColor = Color.Red; }
            if (raqam == 6) { guna2Button6.BackColor = Color.Red; guna2Button6.FillColor = Color.Red; guna2Button6.BorderColor = Color.Red; }
            if (raqam == 7) { guna2Button7.BackColor = Color.Red; guna2Button7.FillColor = Color.Red; guna2Button7.BorderColor = Color.Red; }
            if (raqam == 8) { guna2Button8.BackColor = Color.Red; guna2Button8.FillColor = Color.Red; guna2Button8.BorderColor = Color.Red; }
            if (raqam == 9) { guna2Button9.BackColor = Color.Red; guna2Button9.FillColor = Color.Red; guna2Button9.BorderColor = Color.Red; }
            if (raqam == 10) { guna2Button10.BackColor = Color.Red; guna2Button10.FillColor = Color.Red; guna2Button10.BorderColor = Color.Red; }
            if (raqam == 11) { guna2Button11.BackColor = Color.Red; guna2Button11.FillColor = Color.Red; guna2Button11.BorderColor = Color.Red; }
            if (raqam == 12) { guna2Button12.BackColor = Color.Red; guna2Button12.FillColor = Color.Red; guna2Button12.BorderColor = Color.Red; }
            if (raqam == 13) { guna2Button13.BackColor = Color.Red; guna2Button13.FillColor = Color.Red; guna2Button13.BorderColor = Color.Red; }
            if (raqam == 14) { guna2Button14.BackColor = Color.Red; guna2Button14.FillColor = Color.Red; guna2Button14.BorderColor = Color.Red; }
            if (raqam == 15) { guna2Button15.BackColor = Color.Red; guna2Button15.FillColor = Color.Red; guna2Button15.BorderColor = Color.Red; }
            if (raqam == 16) { guna2Button16.BackColor = Color.Red; guna2Button16.FillColor = Color.Red; guna2Button16.BorderColor = Color.Red; }
            if (raqam == 17) { guna2Button17.BackColor = Color.Red; guna2Button17.FillColor = Color.Red; guna2Button17.BorderColor = Color.Red; }
            if (raqam == 18) { guna2Button18.BackColor = Color.Red; guna2Button18.FillColor = Color.Red; guna2Button18.BorderColor = Color.Red; }
            if (raqam == 19) { guna2Button19.BackColor = Color.Red; guna2Button19.FillColor = Color.Red; guna2Button19.BorderColor = Color.Red; }
            if (raqam == 20) { guna2Button20.BackColor = Color.Red; guna2Button20.FillColor = Color.Red; guna2Button20.BorderColor = Color.Red; }
        }

        public void keyingisi(int raqam)
        {
            if (raqam == 1) { guna2Button1.BackColor = Color.Yellow; guna2Button1.FillColor = Color.Yellow; guna2Button1.BorderColor = Color.Yellow; }
            if (raqam == 2){ guna2Button2.BackColor = Color.Yellow; guna2Button2.FillColor = Color.Yellow; guna2Button2.BorderColor = Color.Yellow; }
            if (raqam == 3){ guna2Button3.BackColor = Color.Yellow; guna2Button3.FillColor = Color.Yellow; guna2Button3.BorderColor = Color.Yellow; }
            if (raqam == 4){ guna2Button4.BackColor = Color.Yellow; guna2Button4.FillColor = Color.Yellow; guna2Button4.BorderColor = Color.Yellow; }
            if (raqam == 5){ guna2Button5.BackColor = Color.Yellow; guna2Button5.FillColor = Color.Yellow; guna2Button5.BorderColor = Color.Yellow; }
            if (raqam == 6){ guna2Button6.BackColor = Color.Yellow; guna2Button6.FillColor = Color.Yellow; guna2Button6.BorderColor = Color.Yellow; }
            if (raqam == 7){ guna2Button7.BackColor = Color.Yellow; guna2Button7.FillColor = Color.Yellow; guna2Button7.BorderColor = Color.Yellow; }
            if (raqam == 8){ guna2Button8.BackColor = Color.Yellow; guna2Button8.FillColor = Color.Yellow; guna2Button8.BorderColor = Color.Yellow; }
            if (raqam == 9){ guna2Button9.BackColor = Color.Yellow; guna2Button9.FillColor = Color.Yellow; guna2Button9.BorderColor = Color.Yellow; }
            if (raqam == 10){ guna2Button10.BackColor = Color.Yellow; guna2Button10.FillColor = Color.Yellow; guna2Button10.BorderColor = Color.Yellow; }
            if (raqam == 11){ guna2Button11.BackColor = Color.Yellow; guna2Button11.FillColor = Color.Yellow; guna2Button11.BorderColor = Color.Yellow; }
            if (raqam == 12){ guna2Button12.BackColor = Color.Yellow; guna2Button12.FillColor = Color.Yellow; guna2Button12.BorderColor = Color.Yellow; }
            if (raqam == 13){ guna2Button13.BackColor = Color.Yellow; guna2Button13.FillColor = Color.Yellow; guna2Button13.BorderColor = Color.Yellow; }
            if (raqam == 14){ guna2Button14.BackColor = Color.Yellow; guna2Button14.FillColor = Color.Yellow; guna2Button14.BorderColor = Color.Yellow; }
            if (raqam == 15){ guna2Button15.BackColor = Color.Yellow; guna2Button15.FillColor = Color.Yellow; guna2Button15.BorderColor = Color.Yellow; }
            if (raqam == 16){ guna2Button16.BackColor = Color.Yellow; guna2Button16.FillColor = Color.Yellow; guna2Button16.BorderColor = Color.Yellow; }
            if (raqam == 17){ guna2Button17.BackColor = Color.Yellow; guna2Button17.FillColor = Color.Yellow; guna2Button17.BorderColor = Color.Yellow; }
            if (raqam == 18){ guna2Button18.BackColor = Color.Yellow; guna2Button18.FillColor = Color.Yellow; guna2Button18.BorderColor = Color.Yellow; }
            if (raqam == 19){ guna2Button19.BackColor = Color.Yellow; guna2Button19.FillColor = Color.Yellow; guna2Button19.BorderColor = Color.Yellow; }
            if (raqam == 20){ guna2Button20.BackColor = Color.Yellow; guna2Button20.FillColor = Color.Yellow; guna2Button20.BorderColor = Color.Yellow; }
        }

        public void tugmaload(int raqam)
        {
            if (raqam == 1) { guna2Button1.BackColor = Color.Gainsboro; guna2Button1.FillColor = Color.Gainsboro; guna2Button1.BorderColor = Color.White; }
            if (raqam == 2) { guna2Button2.BackColor = Color.Gainsboro; guna2Button2.FillColor = Color.Gainsboro; guna2Button2.BorderColor = Color.White; }
            if (raqam == 3) { guna2Button3.BackColor = Color.Gainsboro; guna2Button3.FillColor = Color.Gainsboro; guna2Button3.BorderColor = Color.White; }
            if (raqam == 4) { guna2Button4.BackColor = Color.Gainsboro; guna2Button4.FillColor = Color.Gainsboro; guna2Button4.BorderColor = Color.White; }
            if (raqam == 5) { guna2Button5.BackColor = Color.Gainsboro; guna2Button5.FillColor = Color.Gainsboro; guna2Button5.BorderColor = Color.White; }
            if (raqam == 6) { guna2Button6.BackColor = Color.Gainsboro; guna2Button6.FillColor = Color.Gainsboro; guna2Button6.BorderColor = Color.White; }
            if (raqam == 7) { guna2Button7.BackColor = Color.Gainsboro; guna2Button7.FillColor = Color.Gainsboro; guna2Button7.BorderColor = Color.White; }
            if (raqam == 8) { guna2Button8.BackColor = Color.Gainsboro; guna2Button8.FillColor = Color.Gainsboro; guna2Button8.BorderColor = Color.White; }
            if (raqam == 9) { guna2Button9.BackColor = Color.Gainsboro; guna2Button9.FillColor = Color.Gainsboro; guna2Button9.BorderColor = Color.White; }
            if (raqam == 10) { guna2Button10.BackColor = Color.Gainsboro; guna2Button10.FillColor = Color.Gainsboro; guna2Button10.BorderColor = Color.White; }
            if (raqam == 11) { guna2Button11.BackColor = Color.Gainsboro; guna2Button11.FillColor = Color.Gainsboro; guna2Button11.BorderColor = Color.White; }
            if (raqam == 12) { guna2Button12.BackColor = Color.Gainsboro; guna2Button12.FillColor = Color.Gainsboro; guna2Button12.BorderColor = Color.White; }
            if (raqam == 13) { guna2Button13.BackColor = Color.Gainsboro; guna2Button13.FillColor = Color.Gainsboro; guna2Button13.BorderColor = Color.White; }
            if (raqam == 14) { guna2Button14.BackColor = Color.Gainsboro; guna2Button14.FillColor = Color.Gainsboro; guna2Button14.BorderColor = Color.White; }
            if (raqam == 15) { guna2Button15.BackColor = Color.Gainsboro; guna2Button15.FillColor = Color.Gainsboro; guna2Button15.BorderColor = Color.White; }
            if (raqam == 16) { guna2Button16.BackColor = Color.Gainsboro; guna2Button16.FillColor = Color.Gainsboro; guna2Button16.BorderColor = Color.White; }
            if (raqam == 17) { guna2Button17.BackColor = Color.Gainsboro; guna2Button17.FillColor = Color.Gainsboro; guna2Button17.BorderColor = Color.White; }
            if (raqam == 18) { guna2Button18.BackColor = Color.Gainsboro; guna2Button18.FillColor = Color.Gainsboro; guna2Button18.BorderColor = Color.White; }
            if (raqam == 19) { guna2Button19.BackColor = Color.Gainsboro; guna2Button19.FillColor = Color.Gainsboro; guna2Button19.BorderColor = Color.White; }
            if (raqam == 20) { guna2Button20.BackColor = Color.Gainsboro; guna2Button20.FillColor = Color.Gainsboro; guna2Button20.BorderColor = Color.White; }

        }
        public void javobtanlash(int savolId, string javob)
        {
            test++;
            sql.Open();
            int i = 0;
            var cmd1 = new SqlCommand($"select javob from Bilet where tr={savolId}", sql);
            var reader = cmd1.ExecuteReader();
            while(reader.Read())
            {
             if (reader.GetString(0).Equals(javob))
                {
                  i++;
                  togri++;
                }
                else
                {
                    notugri++;
                }
            }
            if (i != 0) 
            {
                tugma(savolId);
            }
            else if (i == 0)
            { 
                tugmafalse(savolId);
            }
            sql.Close();
        }
        
        private void testishlash_Load(object sender, EventArgs e)
        {
            btnKeyingi.Enabled = false;
            btnTugatish.Enabled = false;
            guna2Button1.Enabled = false;
            guna2Button2.Enabled = false;
            guna2Button3.Enabled = false;
            guna2Button4.Enabled = false;
            guna2Button5.Enabled = false;
            guna2Button6.Enabled = false;
            guna2Button7.Enabled = false;
            guna2Button8.Enabled = false;
            guna2Button9.Enabled = false;
            guna2Button10.Enabled = false;
            guna2Button11.Enabled = false;
            guna2Button12.Enabled = false;
            guna2Button13.Enabled = false;
            guna2Button14.Enabled = false;
            guna2Button15.Enabled = false;
            guna2Button16.Enabled = false;
            guna2Button17.Enabled = false;
            guna2Button18.Enabled = false;
            guna2Button19.Enabled = false;
            guna2Button20.Enabled = false;
            guna2Button23.Enabled = false;
            f1btn.Enabled = false;
            F2btn.Enabled = false;
            F3btn.Enabled = false;
            F4btn.Enabled = false;
        }       

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnKeyingi_Click(object sender, EventArgs e)
        {
            int raqam = int.Parse(lblSavolRaqam.Text);
            keyingisi(raqam);
            lblSavolRaqam.Text = (raqam + 1).ToString();
            ekranga1(raqam + 1);
            tugmaload(raqam + 1);
            izohtxt.Visible = false;
        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            if (lblSavolRaqam.Text.Equals("20"))
            {
                if (guna2Button20.FillColor != Color.Red || guna2Button20.FillColor != Color.Green)
                {
                    int raqam = int.Parse(lblSavolRaqam.Text);
                    javobtanlash(raqam, txt_B.Text);
                    lblSavolRaqam.Text = (raqam + 1).ToString();
                    ekranga1(raqam + 1);
                    tugmaload(raqam + 1);
                    izohtxt.Visible = false;
                }
                else
                {
                    MessageBox.Show("Siz ushbu savolga javob belgilagansiz !!! \nBelgilanmagan savollarni ishlash uchun sariq tugmachani bosing.");
                }
            }
            else
            {
                int raqam = int.Parse(lblSavolRaqam.Text);
                javobtanlash(raqam, txt_B.Text);
                lblSavolRaqam.Text = (raqam + 1).ToString();
                ekranga1(raqam + 1);
                tugmaload(raqam + 1);
                izohtxt.Visible = false;
            }
        }
        private void guna2Button24_Click(object sender, EventArgs e)
        {
            if (F3btn.FillColor == Color.Yellow || F3btn.FillColor == Color.LightSeaGreen || F3btn.FillColor == Color.Gainsboro)
            {
                int raqam = int.Parse(lblSavolRaqam.Text);
            javobtanlash(raqam, txt_C.Text);
            lblSavolRaqam.Text = (raqam + 1).ToString();
            ekranga1(raqam + 1);
            tugmaload(raqam + 1);
            izohtxt.Visible = false;
            }
            else
            {
                MessageBox.Show("Siz ushbu savolga javob belgilagansiz !!!");
            }
        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {
            if (lblSavolRaqam.Text.Equals("20"))
            {
                if (guna2Button20.FillColor != Color.Red || guna2Button20.FillColor != Color.Green)
                {
                    int raqam = int.Parse(lblSavolRaqam.Text);
                    javobtanlash(raqam, txt_D.Text);
                    lblSavolRaqam.Text = (raqam + 1).ToString();
                    ekranga1(raqam + 1);
                    tugmaload(raqam + 1);
                    izohtxt.Visible = false;
                }
                else
                {
                    MessageBox.Show("Siz ushbu savolga javob belgilagansiz !!! \nBelgilanmagan savollarni ishlash uchun sariq tugmachani bosing.");
                }
            }
            else
            {
                int raqam = int.Parse(lblSavolRaqam.Text);
                javobtanlash(raqam, txt_D.Text);
                lblSavolRaqam.Text = (raqam + 1).ToString();
                ekranga1(raqam + 1);
                tugmaload(raqam + 1);
                izohtxt.Visible = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2Button1.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button1.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (guna2Button2.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button2.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (guna2Button3.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button3.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (guna2Button4.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button4.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (guna2Button5.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button5.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (guna2Button6.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button6.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (guna2Button7.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button7.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (guna2Button8.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button8.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (guna2Button9.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button9.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (guna2Button10.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button10.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (guna2Button11.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button11.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (guna2Button12.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button12.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            if (guna2Button13.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button13.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            if (guna2Button14.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button14.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            if (guna2Button15.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button15.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            if (guna2Button16.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button16.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            if (guna2Button17.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button17.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            if (guna2Button18.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button18.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            if (guna2Button19.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button19.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            if (guna2Button20.BackColor == Color.Yellow)
            {
                int raqam = int.Parse(guna2Button20.Text);
                lblSavolRaqam.Text = raqam.ToString();
                ekranga1(raqam);
            }
            else
            {
                MessageBox.Show("Kechirasiz siz ushbu savolga javob belgilagansiz !!!\nJavob belgilanmagan savollarga javob belgilash uchun \nsariq rangdagi tugmalarni bosing !!!", "Ma'lumot");
            }
        }

        private void guna2Button22_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (lblSavolRaqam.Text.Equals("20"))
                {
                    if (guna2Button20.FillColor != Color.Red || guna2Button20.FillColor != Color.Green)
                    {
                        int raqam = int.Parse(lblSavolRaqam.Text);
                        javobtanlash(raqam, txt_A.Text);
                        lblSavolRaqam.Text = (raqam + 1).ToString();
                        ekranga1(raqam + 1);
                        tugmaload(raqam + 1);
                        izohtxt.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Siz ushbu savolga javob belgilagansiz !!! \nBelgilanmagan savollarni ishlash uchun sariq tugmachani bosing.");
                    }
                }
                else
                {
                    int raqam = int.Parse(lblSavolRaqam.Text);
                    javobtanlash(raqam, txt_A.Text);
                    lblSavolRaqam.Text = (raqam + 1).ToString();
                    ekranga1(raqam + 1);
                    tugmaload(raqam + 1);
                    izohtxt.Visible = false;
                }
               

            }
            if (e.KeyCode == Keys.F2)
            {
                if (lblSavolRaqam.Text.Equals("20"))
                {
                    if (guna2Button20.FillColor != Color.Red || guna2Button20.FillColor != Color.Green)
                    {
                        int raqam = int.Parse(lblSavolRaqam.Text);
                        javobtanlash(raqam, txt_B.Text);
                        lblSavolRaqam.Text = (raqam + 1).ToString();
                        ekranga1(raqam + 1);
                        tugmaload(raqam + 1);
                        izohtxt.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Siz ushbu savolga javob belgilagansiz !!! \nBelgilanmagan savollarni ishlash uchun sariq tugmachani bosing.");
                    }
                }
                else
                {
                    int raqam = int.Parse(lblSavolRaqam.Text);
                    javobtanlash(raqam, txt_B.Text);
                    lblSavolRaqam.Text = (raqam + 1).ToString();
                    ekranga1(raqam + 1);
                    tugmaload(raqam + 1);
                    izohtxt.Visible = false;
                }
              
            }
            if (e.KeyCode == Keys.F3)
            {
                if (lblSavolRaqam.Text.Equals("20"))
                {
                    if (guna2Button20.FillColor != Color.Red || guna2Button20.FillColor != Color.Green)
                    {
                        int raqam = int.Parse(lblSavolRaqam.Text);
                        javobtanlash(raqam, txt_C.Text);
                        lblSavolRaqam.Text = (raqam + 1).ToString();
                        ekranga1(raqam + 1);
                        tugmaload(raqam + 1);
                        izohtxt.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Siz ushbu savolga javob belgilagansiz !!! \nBelgilanmagan savollarni ishlash uchun sariq tugmachani bosing.");
                    }
                }
                else
                {
                    int raqam = int.Parse(lblSavolRaqam.Text);
                    javobtanlash(raqam, txt_C.Text);
                    lblSavolRaqam.Text = (raqam + 1).ToString();
                    ekranga1(raqam + 1);
                    tugmaload(raqam + 1);
                    izohtxt.Visible = false;
                }
            }
            if (e.KeyCode == Keys.F4)
            {
                if (lblSavolRaqam.Text.Equals("20"))
                {
                    if (guna2Button20.FillColor != Color.Red || guna2Button20.FillColor != Color.Green)
                    {
                        int raqam = int.Parse(lblSavolRaqam.Text);
                        javobtanlash(raqam, txt_D.Text);
                        lblSavolRaqam.Text = (raqam + 1).ToString();
                        ekranga1(raqam + 1);
                        tugmaload(raqam + 1);
                        izohtxt.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Siz ushbu savolga javob belgilagansiz !!! \nBelgilanmagan savollarni ishlash uchun sariq tugmachani bosing.");
                    }
                }
                else
                {
                    int raqam = int.Parse(lblSavolRaqam.Text);
                    javobtanlash(raqam, txt_D.Text);
                    lblSavolRaqam.Text = (raqam + 1).ToString();
                    ekranga1(raqam + 1);
                    tugmaload(raqam + 1);
                    izohtxt.Visible = false;
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                if (test == 19)
                {
                    MessageBox.Show("Bu so'ngi savol ishlash majburiy");
                }
                int raqam = int.Parse(lblSavolRaqam.Text);
                keyingisi(raqam);
                lblSavolRaqam.Text = (raqam + 1).ToString();
                ekranga1(raqam + 1);
                tugmaload(raqam + 1);
                izohtxt.Visible = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("Savolni o'tkazib yuborish va keyingi savolga o'tish uchun F7 tugmasini bosing.");
            }
         

            if (e.KeyCode == Keys.Space)
            {
                MessageBox.Show("Savolni o'tkazib yuborish va keyingi savolga o'tish uchun F7 tugmasini bosing.");
            }
            

        }

        private void btnTugatish_Click(object sender, EventArgs e)
        {

            if (notugri == 3)
            {
                timer2.Stop();
                timer1.Stop();
                string daq = label2.Text + label5.Text + label6.Text;
                MessageBox.Show("Siz ushbu testdan o`tolmadiz !!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Muavffaqiyatsizlik");
            }
            if (notugri<=3)
            {
                timer2.Stop();
                timer1.Stop();
                string daq = label2.Text + label5.Text + label6.Text;
                MessageBox.Show("Siz ushbu testni muddatidan oldin tugatdingiz!!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun");
                this.Visible = false;
                Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                testishlash.Show();
            }
        }

        private void guna2Button23_Click_1(object sender, EventArgs e)
        {
            if (izohtxt.Visible == true)
            {
                izohtxt.Visible = false;
            }
            if(izohtxt.Visible == false)
            {
                izohtxt.Visible = true;
            }
            
        }

        private void f1btn_Click(object sender, EventArgs e)
        {
            if (lblSavolRaqam.Text.Equals("20"))
            {
                if (guna2Button20.FillColor != Color.Red || guna2Button20.FillColor != Color.Green)
                {
                    int raqam = int.Parse(lblSavolRaqam.Text);
                    javobtanlash(raqam, txt_A.Text);
                    lblSavolRaqam.Text = (raqam + 1).ToString();
                    ekranga1(raqam + 1);
                    tugmaload(raqam + 1);
                    izohtxt.Visible = false;
                }
                else
                {
                    MessageBox.Show("Siz ushbu savolga javob belgilagansiz !!! \nBelgilanmagan savollarni ishlash uchun sariq tugmachani bosing.");
                }
            }
            else
            {
                int raqam = int.Parse(lblSavolRaqam.Text);
                javobtanlash(raqam, txt_A.Text);
                lblSavolRaqam.Text = (raqam + 1).ToString();
                ekranga1(raqam + 1);
                tugmaload(raqam + 1);
                izohtxt.Visible = false;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (test == 20)
            {
                timer3.Stop();
                if (togri < 17)
                {
                    timer2.Stop();
                    timer1.Stop();
                    string daq = label2.Text + label5.Text + label6.Text;
                    if (MessageBox.Show("Siz ushbu testdan o'ta olmadingiz sizning bahoyingi 'Qoniqarsiz' !!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Visible = false;
                        Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                        testishlash.Show();
                    }
                }
                if (togri == 17)
                {
                    timer2.Stop();
                    timer1.Stop();
                    string daq = label2.Text + label5.Text + label6.Text;
                    if (MessageBox.Show("Siz ushbu testdan muavffaqiyatli o'tdingiz sizning bahoyingi 'Qoniqarli' !!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Visible = false;
                        Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                        testishlash.Show();
                    }
                }
                if (togri == 18)
                {
                    timer2.Stop();
                    timer1.Stop();
                    string daq = label2.Text + label5.Text + label6.Text;
                    if (MessageBox.Show("Siz ushbu testdan muavffaqiyatli o'tdingiz sizning bahoyingi 'Yaxshi' !!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Visible = false;
                        Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                        testishlash.Show();
                    }
                }
                if (togri >= 19)
                {
                    timer2.Stop();
                    timer1.Stop();
                    string daq = label2.Text + label5.Text + label6.Text;
                    if (MessageBox.Show("Siz ushbu testdan muavffaqiyatli o'tdingiz sizning bahoyingi 'A'lo' !!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Visible = false;
                        Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                        testishlash.Show();
                    }
                }
            }
        }

        private void guna2Button22_Click_1(object sender, EventArgs e)
        {

            string nomi="";
            sql.Open();
            var command = new SqlCommand($"select nomi from TestTuri", sql);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                nomi = reader.GetString(0);
            }
            sql.Close();

            sql.Open();
            var command1 = new SqlCommand($"delete from TestTuri", sql);
            command1.ExecuteNonQuery();
            sql.Close();
            testTuri.Text = nomi;
            if(nomi.Equals("Yakuniy test"))
            {
                timer1.Start();
                timer2.Start();
                guna2Button23.Visible = false;
            }
            else
            {
                timer1.Stop();
                timer2.Start();
                guna2Button23.Visible = true;
            }

            sql.Open();
            var delete = new SqlCommand("delete from Bilet", sql);
            delete.ExecuteNonQuery();
            sql.Close();

            sql.Open();
            var delete1 = new SqlCommand("delete from Variantlar", sql);
            delete1.ExecuteNonQuery();
            sql.Close();

            var rand = new Random();
            List<int> possible = Enumerable.Range(1, var_soni()).ToList();
            List<int> listNumbers = new List<int>();
            int[] son1 = new int[20];
            for (int i = 0; i < 20; i++)
            {
                int index = rand.Next(0, possible.Count);
                listNumbers.Add(possible[index]);
                possible.RemoveAt(index);
            }
            int j = 0;
            foreach (int i in listNumbers)
            {
                son1[j] = i;
                j++;
            }
            string[] javob2 = new string[20];
            sql.Open();
            for (int i = 0; i < 20; i++)
            {
                var cmd1 = new SqlCommand($"select javob from Savollar where id={son1[i]}", sql);
                var reader2 = cmd1.ExecuteReader();
                while (reader2.Read())
                {
                    javob2[i] = reader2.GetString(0);
                }
                reader2.Close();
            }
            sql.Close();

            sql.Open();
            for (int i = 0; i < 20; i++)
            {
                var cmd = new SqlCommand($"insert into [Bilet](savolId,javob,tr)values(@savolId,@javob,@tr)", sql);
                cmd.Parameters.AddWithValue("@savolId", son1[i]);
                cmd.Parameters.AddWithValue("@javob", javob2[i]);
                cmd.Parameters.AddWithValue("@tr", (i + 1).ToString());
                cmd.ExecuteNonQuery();
            }
            sql.Close();
           
            c = 1;
            sql.Close();

            int n = 0;
            sql.Open();

            var cmd3 = new SqlCommand("select * from Bilet ", sql);
            var reader3 = cmd3.ExecuteReader();
            while (reader3.Read())
            {
                n++;
            }
            sql.Close();
            ekranga1(c);
            tugmaload(c);
            lblUmumiySavollar.Text = n.ToString();
            lblSavolRaqam.Text = c.ToString();
            btnKeyingi.Enabled = true;
            btnTugatish.Enabled = true;
            guna2Button1.Enabled = true;
            guna2Button2.Enabled = true;
            guna2Button3.Enabled = true;
            guna2Button4.Enabled = true;
            guna2Button5.Enabled = true;
            guna2Button6.Enabled = true;
            guna2Button7.Enabled = true;
            guna2Button8.Enabled = true;
            guna2Button9.Enabled = true;
            guna2Button10.Enabled = true;
            guna2Button11.Enabled = true;
            guna2Button12.Enabled = true;
            guna2Button13.Enabled = true;
            guna2Button14.Enabled = true;
            guna2Button15.Enabled = true;
            guna2Button16.Enabled = true;
            guna2Button17.Enabled = true;
            guna2Button18.Enabled = true;
            guna2Button19.Enabled = true;
            guna2Button20.Enabled = true;
            guna2Button23.Enabled = true;
            f1btn.Enabled = true;
            F2btn.Enabled = true;
            F3btn.Enabled = true;
            F4btn.Enabled = true;
        }   

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (notugri == 3)
            {
                timer2.Stop();
                timer1.Stop();
                string daq = label2.Text + label5.Text + label6.Text;
               if(MessageBox.Show("Siz ushbu testdan o`tolmadiz !!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri+" ta", "Muavffaqiyatsizlik", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK){
                    this.Visible = false;
                    Talaba.TestBoshlash testBoshlash = new TestBoshlash();
                    testBoshlash.Show();
                }
               
            }
            if (test == 20)
            {
                if (togri == 17)
                {
                    timer2.Stop();
                    timer1.Stop();
                    string daq = label2.Text + label5.Text + label6.Text;
                    if (MessageBox.Show("Siz ushbu testdan muavffaqiyatli o'tdingiz sizning bahoyingi 'Qoniqarli' !!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Visible = false;
                        Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                        testishlash.Show();
                    }
                }
                if (togri == 18)
                {
                    timer2.Stop();
                    timer1.Stop();
                    string daq = label2.Text + label5.Text + label6.Text;
                    if (MessageBox.Show("Siz ushbu testdan muavffaqiyatli o'tdingiz sizning bahoyingi 'Yaxshi' !!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Visible = false;
                        Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                        testishlash.Show();
                    }                  
                }
                if (togri >= 19)
                {
                    timer2.Stop();
                    timer1.Stop();
                    string daq = label2.Text + label5.Text + label6.Text;
                    if (MessageBox.Show("Siz ushbu testdan muavffaqiyatli o'tdingiz sizning bahoyingi 'A'lo' !!!\n\nTest ishlangan vaqt " + daq + "\n\nTo`g`ri topilgan javoblar soni " + togri + " ta", "Yakun", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        this.Visible = false;
                        Talaba.TestBoshlash testishlash = new Talaba.TestBoshlash();
                        testishlash.Show();
                    }
                }
            }           
        }
    }
}
