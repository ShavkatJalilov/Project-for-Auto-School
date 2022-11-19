using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oqituvchi_test
{
    public partial class Form1 : Form
    {
       
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        //Construktor
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChildForm.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private Color SelectThemeColor()
        {
            int index = random.Next(FonRangi.ColorList.Count);
            while (tempIndex==index)
            {
                index= random.Next(FonRangi.ColorList.Count);
            }
            tempIndex = index;
            string color = FonRangi.ColorList[index];
            return ColorTranslator.FromHtml(color);

        }

        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender) {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular);
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = FonRangi.ChangeColorBrightness(color, -0.3);
                    FonRangi.PrimaryColor = color;
                    FonRangi.SecondaryColor= FonRangi.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (btnSavolQoshish.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Regular);
                }
            }
        }

        private void OpenChildForm(Form childForm,object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActiveButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelSavolQoshish.Controls.Add(childForm);
            this.panelSavolQoshish.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }


        private void btnSavolQoshish_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Buttonlar.SavolQoshish(), sender);
        }

        private void btnSavolTahrirlash_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Buttonlar.SavolTahrirlash(), sender);            
        }

        private void btnSKorishVaOchirish_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Buttonlar.SKorishVaOchirish(), sender);
        }

        private void btnChiqish_Click(object sender, EventArgs e)
        {          
            ActiveButton(sender);
            Admin admin = new Admin();
            admin.Show();
            this.Hide();
        }
        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0,192,192);
            panelLogo.BackColor = Color.FromArgb(40,40,56);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Buttonlar.Login_Parollar(), sender);
        }
    }
}
