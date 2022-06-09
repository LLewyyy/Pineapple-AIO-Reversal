namespace TestKey
{
	// Token: 0x0200000D RID: 13
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000089 RID: 137 RVA: 0x000041A4 File Offset: 0x000023A4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000041DC File Offset: 0x000023DC
		private void InitializeComponent()
		{
            this.logInThemeContainer1 = new LogIn_Theme_Dll_By_xVenoxi.LogInThemeContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.logInButton2 = new LogIn_Theme_Dll_By_xVenoxi.LogInButton();
            this.logInButton1 = new LogIn_Theme_Dll_By_xVenoxi.LogInButton();
            this.key = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.logInThemeContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // logInThemeContainer1
            // 
            this.logInThemeContainer1.AllowClose = true;
            this.logInThemeContainer1.AllowMaximize = true;
            this.logInThemeContainer1.AllowMinimize = true;
            this.logInThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.logInThemeContainer1.BaseColour = System.Drawing.Color.Red;
            this.logInThemeContainer1.BorderColour = System.Drawing.Color.Black;
            this.logInThemeContainer1.ContainerColour = System.Drawing.Color.Black;
            this.logInThemeContainer1.Controls.Add(this.pictureBox1);
            this.logInThemeContainer1.Controls.Add(this.label3);
            this.logInThemeContainer1.Controls.Add(this.label2);
            this.logInThemeContainer1.Controls.Add(this.label1);
            this.logInThemeContainer1.Controls.Add(this.logInButton2);
            this.logInThemeContainer1.Controls.Add(this.logInButton1);
            this.logInThemeContainer1.Controls.Add(this.key);
            this.logInThemeContainer1.Controls.Add(this.password);
            this.logInThemeContainer1.Controls.Add(this.username);
            this.logInThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logInThemeContainer1.FontColour = System.Drawing.Color.White;
            this.logInThemeContainer1.FontSize = 12;
            this.logInThemeContainer1.HoverColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.logInThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.logInThemeContainer1.Name = "logInThemeContainer1";
            this.logInThemeContainer1.ShowIcon = true;
            this.logInThemeContainer1.Size = new System.Drawing.Size(317, 351);
            this.logInThemeContainer1.TabIndex = 0;
            this.logInThemeContainer1.Text = "PINEAPPLE IS A NIGGER";
            this.logInThemeContainer1.Click += new System.EventHandler(this.logInThemeContainer1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(41, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Enter License Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(41, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Enter Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(44, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Enter Username:";
            // 
            // logInButton2
            // 
            this.logInButton2.BackColor = System.Drawing.Color.Transparent;
            this.logInButton2.BaseColour = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logInButton2.BorderColour = System.Drawing.Color.Red;
            this.logInButton2.FontColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.logInButton2.HoverColour = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.logInButton2.Location = new System.Drawing.Point(44, 300);
            this.logInButton2.Name = "logInButton2";
            this.logInButton2.PressedColour = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.logInButton2.ProgressColour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.logInButton2.Size = new System.Drawing.Size(223, 30);
            this.logInButton2.TabIndex = 11;
            this.logInButton2.Text = "Register License Key";
            this.logInButton2.Click += new System.EventHandler(this.logInButton2_Click);
            // 
            // logInButton1
            // 
            this.logInButton1.BackColor = System.Drawing.Color.Transparent;
            this.logInButton1.BaseColour = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.logInButton1.BorderColour = System.Drawing.Color.Red;
            this.logInButton1.FontColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.logInButton1.HoverColour = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.logInButton1.Location = new System.Drawing.Point(44, 264);
            this.logInButton1.Name = "logInButton1";
            this.logInButton1.PressedColour = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.logInButton1.ProgressColour = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(255)))));
            this.logInButton1.Size = new System.Drawing.Size(223, 30);
            this.logInButton1.TabIndex = 10;
            this.logInButton1.Text = "Connect";
            this.logInButton1.Click += new System.EventHandler(this.logInButton1_Click);
            // 
            // key
            // 
            this.key.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.key.ForeColor = System.Drawing.Color.White;
            this.key.Location = new System.Drawing.Point(44, 221);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(223, 20);
            this.key.TabIndex = 9;
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.ForeColor = System.Drawing.Color.White;
            this.password.Location = new System.Drawing.Point(44, 156);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(223, 20);
            this.password.TabIndex = 6;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.ForeColor = System.Drawing.Color.White;
            this.username.Location = new System.Drawing.Point(44, 88);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(223, 20);
            this.username.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 351);
            this.Controls.Add(this.logInThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.logInThemeContainer1.ResumeLayout(false);
            this.logInThemeContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}

		// Token: 0x04000038 RID: 56
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000039 RID: 57
		private global::LogIn_Theme_Dll_By_xVenoxi.LogInThemeContainer logInThemeContainer1;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.TextBox key;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.TextBox password;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.TextBox username;

		// Token: 0x0400003D RID: 61
		private global::LogIn_Theme_Dll_By_xVenoxi.LogInButton logInButton2;

		// Token: 0x0400003E RID: 62
		private global::LogIn_Theme_Dll_By_xVenoxi.LogInButton logInButton1;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
