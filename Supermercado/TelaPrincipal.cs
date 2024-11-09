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
    }
}
