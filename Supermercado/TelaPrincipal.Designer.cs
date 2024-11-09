namespace Supermercado
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel_Close = new System.Windows.Forms.Panel();
            this.painel_Minimize = new System.Windows.Forms.Panel();
            this.painel_Maximize = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Horario = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 20);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(37, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 100);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de Supermercado por: ItalloK";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.panel_Close);
            this.panel3.Controls.Add(this.painel_Minimize);
            this.panel3.Controls.Add(this.painel_Maximize);
            this.panel3.Location = new System.Drawing.Point(705, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(95, 28);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BackgroundImage = global::Supermercado.Properties.Resources.btn7;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(6, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(25, 25);
            this.panel4.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Controls.Add(this.lbl_Horario);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 430);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(800, 20);
            this.panel5.TabIndex = 8;
            // 
            // panel_Close
            // 
            this.panel_Close.BackColor = System.Drawing.Color.White;
            this.panel_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel_Close.BackgroundImage")));
            this.panel_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel_Close.Location = new System.Drawing.Point(65, 2);
            this.panel_Close.Name = "panel_Close";
            this.panel_Close.Size = new System.Drawing.Size(25, 25);
            this.panel_Close.TabIndex = 3;
            this.panel_Close.Click += new System.EventHandler(this.panel_Close_Click);
            // 
            // painel_Minimize
            // 
            this.painel_Minimize.BackColor = System.Drawing.Color.White;
            this.painel_Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("painel_Minimize.BackgroundImage")));
            this.painel_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.painel_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.painel_Minimize.Location = new System.Drawing.Point(5, 2);
            this.painel_Minimize.Name = "painel_Minimize";
            this.painel_Minimize.Size = new System.Drawing.Size(25, 25);
            this.painel_Minimize.TabIndex = 5;
            this.painel_Minimize.Click += new System.EventHandler(this.painel_Minimize_Click);
            // 
            // painel_Maximize
            // 
            this.painel_Maximize.BackColor = System.Drawing.Color.White;
            this.painel_Maximize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("painel_Maximize.BackgroundImage")));
            this.painel_Maximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.painel_Maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.painel_Maximize.Location = new System.Drawing.Point(35, 2);
            this.painel_Maximize.Name = "painel_Maximize";
            this.painel_Maximize.Size = new System.Drawing.Size(25, 25);
            this.painel_Maximize.TabIndex = 4;
            this.painel_Maximize.Click += new System.EventHandler(this.painel_Maximize_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Horario
            // 
            this.lbl_Horario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Horario.AutoSize = true;
            this.lbl_Horario.ForeColor = System.Drawing.Color.White;
            this.lbl_Horario.Location = new System.Drawing.Point(9, 3);
            this.lbl_Horario.Name = "lbl_Horario";
            this.lbl_Horario.Size = new System.Drawing.Size(35, 13);
            this.lbl_Horario.TabIndex = 9;
            this.lbl_Horario.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.TelaPrincipal_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Close;
        private System.Windows.Forms.Panel painel_Maximize;
        private System.Windows.Forms.Panel painel_Minimize;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_Horario;
        private System.Windows.Forms.Timer timer1;
    }
}

