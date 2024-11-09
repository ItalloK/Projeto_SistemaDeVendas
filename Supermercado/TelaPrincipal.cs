using Supermercado.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermercado
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
            firstLabel.BringToFront();
        }

        private void panel_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel_Close_Enter(object sender, EventArgs e)
        {
            panel_Close.BackgroundImage = Resources.btn6;
        }

        private void panel_Close_Leave(object sender, EventArgs e)
        {
            panel_Close.BackgroundImage = Resources.btn3;
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            //panel_Close.BackgroundImage = Resources.btn6;
        }

        private void painel_Maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void painel_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime agora = DateTime.Now;
            string hora = agora.ToString("HH:mm:ss");

            lbl_Horario.Text = $"São Luis, {hora}";
        }

        private void btn_Venda_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btn_Venda.Height;
            slidePanel.Top = btn_Venda.Top;  // Ajusta a posição vertical
            firstLabel.BringToFront();
        }

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btn_Estoque.Height;
            slidePanel.Top = btn_Estoque.Top;  // Ajusta a posição vertical
            seccondLabel.BringToFront();
        }

        private void btn_Clientes_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btn_Clientes.Height;
            slidePanel.Top = btn_Clientes.Top;  // Ajusta a posição vertical
            treeLabel.BringToFront();
        }

        private void btn_Relatorios_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btn_Relatorios.Height;
            slidePanel.Top = btn_Relatorios.Top;  // Ajusta a posição vertical
            fourLabel.BringToFront();
        }
    }
}
