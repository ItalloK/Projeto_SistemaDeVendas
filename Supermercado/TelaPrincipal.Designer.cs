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
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_Horario = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Relatorios = new System.Windows.Forms.Button();
            this.btn_Clientes = new System.Windows.Forms.Button();
            this.btn_Estoque = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_Venda = new System.Windows.Forms.Button();
            this.panel_Close = new System.Windows.Forms.Panel();
            this.painel_Minimize = new System.Windows.Forms.Panel();
            this.painel_Maximize = new System.Windows.Forms.Panel();
            this.slidePanel = new System.Windows.Forms.Panel();
            this.firstLabel = new System.Windows.Forms.Panel();
            this.seccondLabel = new System.Windows.Forms.Panel();
            this.treeLabel = new System.Windows.Forms.Panel();
            this.fourLabel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 20);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 25);
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
            this.panel3.Location = new System.Drawing.Point(843, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(95, 28);
            this.panel3.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.lbl_Horario);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 473);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(938, 20);
            this.panel5.TabIndex = 8;
            // 
            // lbl_Horario
            // 
            this.lbl_Horario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_Horario.AutoSize = true;
            this.lbl_Horario.ForeColor = System.Drawing.Color.White;
            this.lbl_Horario.Location = new System.Drawing.Point(37, 3);
            this.lbl_Horario.Name = "lbl_Horario";
            this.lbl_Horario.Size = new System.Drawing.Size(96, 13);
            this.lbl_Horario.TabIndex = 9;
            this.lbl_Horario.Text = "São Luis, 00:00:00";
            this.lbl_Horario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.slidePanel);
            this.panel4.Controls.Add(this.btn_Relatorios);
            this.panel4.Controls.Add(this.btn_Clientes);
            this.panel4.Controls.Add(this.btn_Estoque);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.btn_Venda);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(179, 453);
            this.panel4.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(186, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Usuário: USERNAME CPF: 000.000.000-00";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(433, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(310, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "www.sitedaloja.com.br";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Relatorios
            // 
            this.btn_Relatorios.FlatAppearance.BorderSize = 0;
            this.btn_Relatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Relatorios.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Relatorios.ForeColor = System.Drawing.Color.White;
            this.btn_Relatorios.Image = global::Supermercado.Properties.Resources.btn_Relatorios;
            this.btn_Relatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Relatorios.Location = new System.Drawing.Point(12, 303);
            this.btn_Relatorios.Name = "btn_Relatorios";
            this.btn_Relatorios.Size = new System.Drawing.Size(164, 48);
            this.btn_Relatorios.TabIndex = 14;
            this.btn_Relatorios.Text = "     Relatórios";
            this.btn_Relatorios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Relatorios.UseVisualStyleBackColor = true;
            this.btn_Relatorios.Click += new System.EventHandler(this.btn_Relatorios_Click);
            // 
            // btn_Clientes
            // 
            this.btn_Clientes.FlatAppearance.BorderSize = 0;
            this.btn_Clientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clientes.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clientes.ForeColor = System.Drawing.Color.White;
            this.btn_Clientes.Image = global::Supermercado.Properties.Resources.btn_Clientes;
            this.btn_Clientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clientes.Location = new System.Drawing.Point(12, 249);
            this.btn_Clientes.Name = "btn_Clientes";
            this.btn_Clientes.Size = new System.Drawing.Size(164, 48);
            this.btn_Clientes.TabIndex = 13;
            this.btn_Clientes.Text = "     Clientes";
            this.btn_Clientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Clientes.UseVisualStyleBackColor = true;
            this.btn_Clientes.Click += new System.EventHandler(this.btn_Clientes_Click);
            // 
            // btn_Estoque
            // 
            this.btn_Estoque.FlatAppearance.BorderSize = 0;
            this.btn_Estoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Estoque.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Estoque.ForeColor = System.Drawing.Color.White;
            this.btn_Estoque.Image = global::Supermercado.Properties.Resources.btn_Estoque;
            this.btn_Estoque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Estoque.Location = new System.Drawing.Point(12, 195);
            this.btn_Estoque.Name = "btn_Estoque";
            this.btn_Estoque.Size = new System.Drawing.Size(164, 48);
            this.btn_Estoque.TabIndex = 12;
            this.btn_Estoque.Text = "     Ver Estoque";
            this.btn_Estoque.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Estoque.UseVisualStyleBackColor = true;
            this.btn_Estoque.Click += new System.EventHandler(this.btn_Estoque_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(43, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 90);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // btn_Venda
            // 
            this.btn_Venda.FlatAppearance.BorderSize = 0;
            this.btn_Venda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Venda.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Venda.ForeColor = System.Drawing.Color.White;
            this.btn_Venda.Image = global::Supermercado.Properties.Resources.btn_Venda;
            this.btn_Venda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Venda.Location = new System.Drawing.Point(12, 141);
            this.btn_Venda.Name = "btn_Venda";
            this.btn_Venda.Size = new System.Drawing.Size(164, 48);
            this.btn_Venda.TabIndex = 9;
            this.btn_Venda.Text = "     Realizar Venda";
            this.btn_Venda.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Venda.UseVisualStyleBackColor = true;
            this.btn_Venda.Click += new System.EventHandler(this.btn_Venda_Click);
            // 
            // panel_Close
            // 
            this.panel_Close.BackColor = System.Drawing.Color.White;
            this.panel_Close.BackgroundImage = global::Supermercado.Properties.Resources.btn6;
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
            this.painel_Minimize.BackgroundImage = global::Supermercado.Properties.Resources.btn4;
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
            this.painel_Maximize.BackgroundImage = global::Supermercado.Properties.Resources.btn5;
            this.painel_Maximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.painel_Maximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.painel_Maximize.Location = new System.Drawing.Point(35, 2);
            this.painel_Maximize.Name = "painel_Maximize";
            this.painel_Maximize.Size = new System.Drawing.Size(25, 25);
            this.painel_Maximize.TabIndex = 4;
            this.painel_Maximize.Click += new System.EventHandler(this.painel_Maximize_Click);
            // 
            // slidePanel
            // 
            this.slidePanel.BackColor = System.Drawing.Color.LightGray;
            this.slidePanel.Location = new System.Drawing.Point(3, 141);
            this.slidePanel.Name = "slidePanel";
            this.slidePanel.Size = new System.Drawing.Size(10, 48);
            this.slidePanel.TabIndex = 9;
            // 
            // firstLabel
            // 
            this.firstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstLabel.BackColor = System.Drawing.Color.Black;
            this.firstLabel.Location = new System.Drawing.Point(185, 57);
            this.firstLabel.Name = "firstLabel";
            this.firstLabel.Size = new System.Drawing.Size(748, 410);
            this.firstLabel.TabIndex = 9;
            // 
            // seccondLabel
            // 
            this.seccondLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seccondLabel.BackColor = System.Drawing.Color.Gray;
            this.seccondLabel.Location = new System.Drawing.Point(185, 57);
            this.seccondLabel.Name = "seccondLabel";
            this.seccondLabel.Size = new System.Drawing.Size(748, 410);
            this.seccondLabel.TabIndex = 10;
            // 
            // treeLabel
            // 
            this.treeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeLabel.BackColor = System.Drawing.Color.Gainsboro;
            this.treeLabel.Location = new System.Drawing.Point(185, 57);
            this.treeLabel.Name = "treeLabel";
            this.treeLabel.Size = new System.Drawing.Size(748, 410);
            this.treeLabel.TabIndex = 11;
            // 
            // fourLabel
            // 
            this.fourLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fourLabel.BackColor = System.Drawing.Color.RosyBrown;
            this.fourLabel.Location = new System.Drawing.Point(185, 57);
            this.fourLabel.Name = "fourLabel";
            this.fourLabel.Size = new System.Drawing.Size(748, 410);
            this.fourLabel.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Company Market";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(938, 493);
            this.Controls.Add(this.fourLabel);
            this.Controls.Add(this.treeLabel);
            this.Controls.Add(this.seccondLabel);
            this.Controls.Add(this.firstLabel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.TelaPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Close;
        private System.Windows.Forms.Panel painel_Maximize;
        private System.Windows.Forms.Panel painel_Minimize;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_Horario;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_Relatorios;
        private System.Windows.Forms.Button btn_Clientes;
        private System.Windows.Forms.Button btn_Estoque;
        private System.Windows.Forms.Panel slidePanel;
        private System.Windows.Forms.Button btn_Venda;
        private System.Windows.Forms.Panel firstLabel;
        private System.Windows.Forms.Panel seccondLabel;
        private System.Windows.Forms.Panel treeLabel;
        private System.Windows.Forms.Panel fourLabel;
        private System.Windows.Forms.Label label4;
    }
}

