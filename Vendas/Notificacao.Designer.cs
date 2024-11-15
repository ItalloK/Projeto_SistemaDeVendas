namespace Supermercado
{
    partial class Notificacao
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
            this.components = new System.ComponentModel.Container();
            this.toastBorder = new System.Windows.Forms.Panel();
            this.lbType = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.toastTimer = new System.Windows.Forms.Timer(this.components);
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.toastHide = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // toastBorder
            // 
            this.toastBorder.BackColor = System.Drawing.Color.Green;
            this.toastBorder.Location = new System.Drawing.Point(-4, -6);
            this.toastBorder.Name = "toastBorder";
            this.toastBorder.Size = new System.Drawing.Size(12, 69);
            this.toastBorder.TabIndex = 0;
            // 
            // lbType
            // 
            this.lbType.AutoSize = true;
            this.lbType.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbType.Location = new System.Drawing.Point(54, 9);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(38, 17);
            this.lbType.TabIndex = 2;
            this.lbType.Text = "Type";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.Location = new System.Drawing.Point(54, 32);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(82, 13);
            this.lbMessage.TabIndex = 3;
            this.lbMessage.Text = "Toast Message";
            // 
            // toastTimer
            // 
            this.toastTimer.Enabled = true;
            this.toastTimer.Interval = 10;
            this.toastTimer.Tick += new System.EventHandler(this.toastTimer_Tick);
            // 
            // picIcon
            // 
            this.picIcon.Image = global::Supermercado.Properties.Resources.sucess;
            this.picIcon.Location = new System.Drawing.Point(17, 16);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(25, 25);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            // 
            // toastHide
            // 
            this.toastHide.Tick += new System.EventHandler(this.toastHide_Tick);
            // 
            // Notificacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 59);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.picIcon);
            this.Controls.Add(this.toastBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notificacao";
            this.Text = "Notificacao";
            this.Load += new System.EventHandler(this.Notificacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel toastBorder;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lbType;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Timer toastTimer;
        private System.Windows.Forms.Timer toastHide;
    }
}