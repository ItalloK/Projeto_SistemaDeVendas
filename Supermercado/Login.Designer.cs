namespace Supermercado
{
    partial class Login
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
            this.tb_Codigo = new CuoreUI.Controls.cuiTextBox2();
            this.tb_Senha = new CuoreUI.Controls.cuiTextBox2();
            this.btn_Login = new CuoreUI.Controls.cuiButton();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Codigo
            // 
            this.tb_Codigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_Codigo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tb_Codigo.BorderFocusColor = System.Drawing.Color.LightGray;
            this.tb_Codigo.BorderSize = 1;
            this.tb_Codigo.Content = "";
            this.tb_Codigo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Codigo.ForeColor = System.Drawing.Color.Gray;
            this.tb_Codigo.Location = new System.Drawing.Point(65, 164);
            this.tb_Codigo.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Codigo.Multiline = false;
            this.tb_Codigo.Name = "tb_Codigo";
            this.tb_Codigo.Padding = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.tb_Codigo.PasswordChar = false;
            this.tb_Codigo.PlaceholderColor = System.Drawing.Color.White;
            this.tb_Codigo.PlaceholderText = "Digite seu codigo de login:";
            this.tb_Codigo.Rounding = 8;
            this.tb_Codigo.Size = new System.Drawing.Size(266, 45);
            this.tb_Codigo.TabIndex = 1;
            this.tb_Codigo.TextOffset = new System.Drawing.Size(0, 0);
            this.tb_Codigo.UnderlinedStyle = false;
            // 
            // tb_Senha
            // 
            this.tb_Senha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_Senha.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tb_Senha.BorderFocusColor = System.Drawing.Color.LightGray;
            this.tb_Senha.BorderSize = 1;
            this.tb_Senha.Content = "";
            this.tb_Senha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_Senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Senha.ForeColor = System.Drawing.Color.Gray;
            this.tb_Senha.Location = new System.Drawing.Point(65, 217);
            this.tb_Senha.Margin = new System.Windows.Forms.Padding(4);
            this.tb_Senha.Multiline = false;
            this.tb_Senha.Name = "tb_Senha";
            this.tb_Senha.Padding = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.tb_Senha.PasswordChar = true;
            this.tb_Senha.PlaceholderColor = System.Drawing.Color.White;
            this.tb_Senha.PlaceholderText = "Digite sua senha:";
            this.tb_Senha.Rounding = 8;
            this.tb_Senha.Size = new System.Drawing.Size(266, 45);
            this.tb_Senha.TabIndex = 2;
            this.tb_Senha.TextOffset = new System.Drawing.Size(0, 0);
            this.tb_Senha.UnderlinedStyle = false;
            // 
            // btn_Login
            // 
            this.btn_Login.CheckButton = false;
            this.btn_Login.Checked = false;
            this.btn_Login.CheckedBackground = System.Drawing.Color.Silver;
            this.btn_Login.CheckedImageTint = System.Drawing.Color.White;
            this.btn_Login.CheckedOutline = System.Drawing.Color.Silver;
            this.btn_Login.Content = "Fazer Login";
            this.btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.HoverBackground = System.Drawing.Color.Silver;
            this.btn_Login.HoveredImageTint = System.Drawing.Color.White;
            this.btn_Login.HoverOutline = System.Drawing.Color.Empty;
            this.btn_Login.Image = null;
            this.btn_Login.ImageAutoCenter = true;
            this.btn_Login.ImageExpand = new System.Drawing.Point(0, 0);
            this.btn_Login.ImageOffset = new System.Drawing.Point(0, 0);
            this.btn_Login.ImageTint = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(65, 269);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.NormalBackground = System.Drawing.Color.Black;
            this.btn_Login.NormalOutline = System.Drawing.Color.Empty;
            this.btn_Login.OutlineThickness = 1.6F;
            this.btn_Login.PressedBackground = System.Drawing.Color.Silver;
            this.btn_Login.PressedImageTint = System.Drawing.Color.White;
            this.btn_Login.PressedOutline = System.Drawing.Color.Empty;
            this.btn_Login.Rounding = new System.Windows.Forms.Padding(8);
            this.btn_Login.Size = new System.Drawing.Size(266, 45);
            this.btn_Login.TabIndex = 3;
            this.btn_Login.TextOffset = new System.Drawing.Point(0, 0);
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::Supermercado.Properties.Resources.btn6Menormm;
            this.button1.Location = new System.Drawing.Point(381, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Supermercado.Properties.Resources.Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(142, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(418, 337);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.tb_Senha);
            this.Controls.Add(this.tb_Codigo);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private CuoreUI.Controls.cuiTextBox2 tb_Codigo;
        private CuoreUI.Controls.cuiTextBox2 tb_Senha;
        private CuoreUI.Controls.cuiButton btn_Login;
        private System.Windows.Forms.Button button1;
    }
}