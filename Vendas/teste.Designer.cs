namespace Supermercado
{
    partial class teste
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
            this.dgv_Estoque = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Estoque)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Estoque
            // 
            this.dgv_Estoque.AllowUserToAddRows = false;
            this.dgv_Estoque.AllowUserToDeleteRows = false;
            this.dgv_Estoque.AllowUserToResizeColumns = false;
            this.dgv_Estoque.AllowUserToResizeRows = false;
            this.dgv_Estoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Estoque.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Estoque.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Estoque.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Estoque.Location = new System.Drawing.Point(29, 50);
            this.dgv_Estoque.MultiSelect = false;
            this.dgv_Estoque.Name = "dgv_Estoque";
            this.dgv_Estoque.ReadOnly = true;
            this.dgv_Estoque.RowHeadersVisible = false;
            this.dgv_Estoque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Estoque.Size = new System.Drawing.Size(742, 351);
            this.dgv_Estoque.TabIndex = 23;
            // 
            // teste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgv_Estoque);
            this.Name = "teste";
            this.Text = "teste";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Estoque)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Estoque;
    }
}