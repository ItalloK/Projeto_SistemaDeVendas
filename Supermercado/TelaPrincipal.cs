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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Supermercado
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
            CarregarPromo();
            homeLabel.BringToFront();
            Funcoes.SetPlaceholder(tb_Pesquisa, "Digite para pesquisar nos dados...");
            Funcoes.SetPlaceholder(tb_NomeCliente, "Digite o nome do cliente...");
            Funcoes.SetPlaceholder(tb_EmailCliente, "Digite o email do cliente...");
            Funcoes.SetPlaceholder(tb_EnderecoCliente, "Digite o endereço do cliente...");
            Funcoes.SetPlaceholder(tb_AnotacoesCliente, "Digite aqui anotações para este cliente...");

            if(Global.nomeFuncionario != null && Global.cpfFuncionario != null)
            {
                string nome = Global.nomeFuncionario, cpf = Global.cpfFuncionario;
                lbl_DadosFuncionario.Text = $"Usuário: {nome}, Cpf: {cpf}";
            }

        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            CarregarClientes(); // fazer função
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime agora = DateTime.Now;
            string hora = agora.ToString("HH:mm:ss");

            lbl_Horario.Text = $"São Luis, {hora}";
        }

        private void btn_Venda_Click(object sender, EventArgs e)
        {
            if (verificarFuncionario() == false) { MessageBox.Show("Você não está logado como funcionario."); return; }
            slidePanel.Height = btn_Venda.Height;
            slidePanel.Top = btn_Venda.Top;  // Ajusta a posição vertical
            firstLabel.BringToFront();
        }

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            if (verificarFuncionario() == false) { MessageBox.Show("Você não está logado como funcionario."); return; }
            slidePanel.Height = btn_Estoque.Height;
            slidePanel.Top = btn_Estoque.Top;  // Ajusta a posição vertical
            seccondLabel.BringToFront();
        }

        private void btn_Clientes_Click(object sender, EventArgs e)
        {
            if (verificarFuncionario() == false) { MessageBox.Show("Você não está logado como funcionario."); return; }
            slidePanel.Height = btn_Clientes.Height;
            slidePanel.Top = btn_Clientes.Top;  // Ajusta a posição vertical
            treeLabel.BringToFront();
        }

        private void btn_Relatorios_Click(object sender, EventArgs e)
        {
            if (verificarFuncionario() == false) { MessageBox.Show("Você não está logado como funcionario."); return; }
            slidePanel.Height = btn_Relatorios.Height;
            slidePanel.Top = btn_Relatorios.Top;  // Ajusta a posição vertical
            fourLabel.BringToFront();
        }

        private void btn_Funcionario_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btn_Funcionario.Height;
            slidePanel.Top = btn_Funcionario.Top;
            if (verificarFuncionario() == false)
            {
                Login login = new Login();
                login.ShowDialog();
                return;
            }
            fiveLabel.BringToFront();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Maximize_Click(object sender, EventArgs e)
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

        private void btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btn_Home.Height;
            slidePanel.Top = btn_Home.Top;  // Ajusta a posição vertical
            homeLabel.BringToFront();
        }


        private bool verificarFuncionario()
        {
            if (Global.nomeFuncionario == null || Global.cpfFuncionario == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_CadCliente_Click(object sender, EventArgs e)
        {
            painelCadCliente.BringToFront();
        }

        private void btn_CancelarCadCliente_Click(object sender, EventArgs e)
        {
            LimparDados();
            treeLabel.BringToFront();
        }


        private void LimparDados()
        {
            tb_NomeCliente.Clear();
            mtb_CPFCliente.Clear();
            mtb_DataNascCliente.Clear();
            mtb_TelefoneCliente.Clear();
            tb_EmailCliente.Clear();
            tb_EnderecoCliente.Clear();
            tb_AnotacoesCliente.Clear();
        }


        private void CarregarClientes()
        {
            dgv_Dados.DataSource = Banco.DadosClientes();
        }

        private void CadastrarCliente()
        {
            string nome = tb_NomeCliente.Text;
            mtb_TelefoneCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string telefone = mtb_TelefoneCliente.Text;
            string email = tb_EmailCliente.Text;
            mtb_CPFCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string cpf = mtb_CPFCliente.Text;
            mtb_DataNascCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string dataNasc = mtb_DataNascCliente.Text;
            string endereco = tb_EnderecoCliente.Text;
            string anotacoes = tb_AnotacoesCliente.Text;

            var result =  Banco.CadastrarCliente(nome, telefone, email, cpf, dataNasc, endereco, anotacoes);
            if (result)
            {
                treeLabel.BringToFront();
                LimparDados();
                CarregarClientes();
            }
            else
            {
                return;
            }
        }

        private void CarregarPromo()
        {
            try
            {
                string caminhoDaImagem = System.IO.Path.Combine(Application.StartupPath, "promo.png");
                if (System.IO.File.Exists(caminhoDaImagem))
                {
                    pictureboxPromo.Image = Image.FromFile(caminhoDaImagem);
                }
                else
                {
                    MessageBox.Show("O arquivo de imagem 'promo.png' não foi encontrado na pasta raiz.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_CadastrarCliente_Click(object sender, EventArgs e)
        {
            CadastrarCliente();
        }
    }
}
