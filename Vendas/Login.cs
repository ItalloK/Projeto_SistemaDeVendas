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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string codigo = tb_Codigo.Content;
            string senha = tb_Senha.Content;
            if(string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Digite o codigo e a senha para fazer login.");
                return;
            }
            if (codigo.Length != 6)
            {
                MessageBox.Show("O codigo deve conter 6 digitos.");
                return;
            }
        }
    }
}
