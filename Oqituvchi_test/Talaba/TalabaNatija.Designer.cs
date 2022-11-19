
namespace Oqituvchi_test.Talaba
{
    partial class TalabaNatija
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSaqlash = new Guna.UI2.WinForms.Guna2Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSaqlash
            // 
            this.btnSaqlash.BorderRadius = 18;
            this.btnSaqlash.BorderThickness = 1;
            this.btnSaqlash.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaqlash.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaqlash.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaqlash.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaqlash.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaqlash.ForeColor = System.Drawing.Color.White;
            this.btnSaqlash.HoverState.FillColor = System.Drawing.Color.White;
            this.btnSaqlash.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(70)))));
            this.btnSaqlash.Location = new System.Drawing.Point(321, 388);
            this.btnSaqlash.Name = "btnSaqlash";
            this.btnSaqlash.Size = new System.Drawing.Size(180, 45);
            this.btnSaqlash.TabIndex = 3;
            this.btnSaqlash.Text = "Saqlash";
            this.btnSaqlash.Click += new System.EventHandler(this.btnSaqlash_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(44, 51);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(484, 302);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // TalabaNatija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(579, 445);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnSaqlash);
            this.Name = "TalabaNatija";
            this.Text = "TalabaNatija";
            this.Load += new System.EventHandler(this.TalabaNatija_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnSaqlash;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}