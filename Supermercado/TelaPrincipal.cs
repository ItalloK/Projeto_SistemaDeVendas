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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Supermercado
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
            CarregarPromo();
            homeLabel.BringToFront();
            PlaceHolders();

            if (Global.nomeFuncionario != null && Global.cpfFuncionario != null)
            {
                string nome = Global.nomeFuncionario, cpf = Global.cpfFuncionario;
                lbl_DadosFuncionario.Text = $"Usuário: {nome}, Cpf: {cpf}";
            }

            
        }

        private int idCliente = -1;
        private string nomeCliente;
        private string telefoneCliente;
        private string emailCliente;
        private string cpfCliente;
        private string dataNascCliente;
        private string enderecoCliente;
        private string anotacoesCliente;

        private int idProduto = -1;
        private string descricaoProduto;
        private decimal precoProduto;
        private decimal pesoProduto;
        private decimal quantidadeProduto;

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            CarregarClientes(); // fazer função
            CarregarEstoque();
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
            Funcoes.Notificar("AVISO", "Cliente não inserido.");
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

            tbAtt_NomeCliente.Clear();
            mtbAtt_CpfCliente.Clear();
            mtbAtt_DataNascCliente.Clear();
            mtbAtt_TelefoneCliente.Clear();
            tbAtt_EmailCliente.Clear();
            tbAtt_EnderecoCliente.Clear();
            tbAtt_AnotacoesCliente.Clear();
        }


        private void CarregarClientes()
        {
            dgv_Dados.DataSource = Banco.DadosClientes();
            dgv_Dados.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private void CarregarEstoque()
        {

            dgv_Estoque.DataSource = Banco.Estoque();

            dgv_Estoque.Columns["codigo"].DisplayIndex = 0;
            dgv_Estoque.Columns["descricao"].DisplayIndex = 1;
            dgv_Estoque.Columns["preco"].DisplayIndex = 2;
            dgv_Estoque.Columns["peso"].DisplayIndex = 3;
            dgv_Estoque.Columns["quantidade"].DisplayIndex = 4;

            dgv_Estoque.Columns["codigo"].HeaderText = "Cod. Produto";
            dgv_Estoque.Columns["descricao"].HeaderText = "Desc. Produto";
            dgv_Estoque.Columns["preco"].HeaderText = "Preço";
            dgv_Estoque.Columns["peso"].HeaderText = "Peso";
            dgv_Estoque.Columns["quantidade"].HeaderText = "Quantidade";

            dgv_Estoque.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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

        private void dgv_Dados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Dados.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_Dados.SelectedRows[0];
                idCliente = Convert.ToInt32(selectedRow.Cells["id"].Value);
                nomeCliente = selectedRow.Cells["nome"].Value.ToString();
                telefoneCliente = selectedRow.Cells["telefone"].Value.ToString();
                emailCliente = selectedRow.Cells["email"].Value.ToString();
                cpfCliente = selectedRow.Cells["cpf"].Value.ToString();
                dataNascCliente = selectedRow.Cells["dataNasc"].Value.ToString();
                enderecoCliente = selectedRow.Cells["endereco"].Value.ToString();
                anotacoesCliente = selectedRow.Cells["anotacoes"].Value.ToString();
            }
            else
            {
                idCliente = -1;
            }
        }

        private void btn_AttCliente_Click(object sender, EventArgs e)
        {
            LimparDados();
            PegarDadosCliente();
        }

        private void PegarDadosCliente()
        {
            if(idCliente != -1)
            {
                panelAttCliente.BringToFront();
                tbAtt_NomeCliente.Text = nomeCliente;
                mtbAtt_TelefoneCliente.Text = telefoneCliente;
                tbAtt_EmailCliente.Text = emailCliente;
                mtbAtt_CpfCliente.Text = cpfCliente;
                mtbAtt_CpfCliente.Enabled = false;
                mtbAtt_DataNascCliente.Text = dataNascCliente;
                tbAtt_EnderecoCliente.Text = enderecoCliente;
                tbAtt_AnotacoesCliente.Text = anotacoesCliente;
            }
            else
            {
                MessageBox.Show("Selecione um cliente para atualizar!");
                return;
            }
        }

        private void btnCancelarAtualizar_Click(object sender, EventArgs e)
        {
            LimparDados();
            treeLabel.BringToFront();
            Funcoes.Notificar("AVISO", "Atualização Cancelada.");
        }

        private void btnAtualizarCliente_Click(object sender, EventArgs e)
        {
            AtualizarCliente();
        }

        private void AtualizarCliente()
        {
            string nome = tbAtt_NomeCliente.Text;
            mtbAtt_TelefoneCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string telefone = mtbAtt_TelefoneCliente.Text;
            string email = tbAtt_EmailCliente.Text;
            mtbAtt_CpfCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string cpf = mtbAtt_CpfCliente.Text;
            mtbAtt_DataNascCliente.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string dataNasc = mtbAtt_DataNascCliente.Text;
            string endereco = tbAtt_EnderecoCliente.Text;
            string anotacoes = tbAtt_AnotacoesCliente.Text;

            var result = Banco.AtualizarCliente(nome, telefone, email, cpf, dataNasc, endereco, anotacoes);
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

        private void btn_DelCliente_Click(object sender, EventArgs e)
        {
            DeletarCliente();
        }

        private void DeletarCliente()
        {
            if (idCliente != -1)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja deletar?","Confirmação",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(resultado == DialogResult.Yes)
                {
                    var result = Banco.DeletarCliente(idCliente);
                    if (result)
                    {
                        CarregarClientes();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Funcoes.Notificar("AVISO", "Usuario nao deletado.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente para deletar!");
                return;
            }
        }

        private void btn_NovoProduto_Click(object sender, EventArgs e)
        {
            LimparDadosProduto();
            PanelCadProduto.BringToFront();
        }

        private void LimparDadosProduto()
        {
            tb_DescricaoProduto.Clear();
            tb_PrecoProduto.Clear();
            tb_PesoProduto.Clear();
            tb_QuantidadeProduto.Clear();

            tbAttDescProduto.Clear();
            tbAttPrecoProduto.Clear();
            tbAttPesoProduto.Clear();
            tbAttQuantidadeProduto.Clear();
        }

        private void btn_AtualizarProduto_Click(object sender, EventArgs e)
        {
            LimparDadosProduto();
            PegarDadosProduto();            
        }

        private void PegarDadosProduto()
        {
            if (idProduto != -1)
            {
                PanelAttProduto.BringToFront();
                tbAttDescProduto.Text = descricaoProduto;
                tbAttPrecoProduto.Text = precoProduto.ToString();
                tbAttPesoProduto.Text = pesoProduto.ToString();
                tbAttQuantidadeProduto.Text = quantidadeProduto.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um produto para atualizar!");
                return;
            }
        }

        private void AtualizarProduto()
        {
            string descricao = tbAttDescProduto.Text;
            decimal preco = decimal.Parse(tbAttPrecoProduto.Text);
            decimal peso = decimal.Parse(tbAttPesoProduto.Text);
            decimal quantidade = decimal.Parse(tbAttQuantidadeProduto.Text);
            var result = Banco.AtualizarProduto(descricao, preco, peso, quantidade, idProduto);
            if (result)
            {
                seccondLabel.BringToFront();
                LimparDadosProduto();
                CarregarEstoque();
            }
            else
            {
                return;
            }
        }

        private void dgv_Estoque_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Estoque.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_Estoque.SelectedRows[0];
                idProduto = Convert.ToInt32(selectedRow.Cells["codigo"].Value);
                descricaoProduto = selectedRow.Cells["descricao"].Value.ToString();
                precoProduto = Convert.ToDecimal(selectedRow.Cells["preco"].Value);
                pesoProduto = Convert.ToDecimal(selectedRow.Cells["peso"].Value);
                quantidadeProduto = Convert.ToDecimal(selectedRow.Cells["quantidade"].Value);
            }
            else
            {
                idProduto = -1;
            }
        }

        private void btnAtualizarProduto_Click(object sender, EventArgs e)
        {
            AtualizarProduto();
        }

        private void btn_CadastrarProduto_Click(object sender, EventArgs e)
        {
            CadastrarProduto();
        }

        private void CadastrarProduto()
        {
            string descricao = tb_DescricaoProduto.Text;
            decimal preco = decimal.Parse(tb_PrecoProduto.Text);
            decimal peso = decimal.Parse(tb_PesoProduto.Text);
            decimal quantidade = decimal.Parse(tb_QuantidadeProduto.Text);

            var result = Banco.CadastrarProduto(descricao, preco, quantidade, peso);
            if (result)
            {
                seccondLabel.BringToFront();
                LimparDadosProduto();
                CarregarEstoque();
            }
            else
            {
                return;
            }
        }

        private void btn_CancelarCadProduto_Click(object sender, EventArgs e)
        {
            LimparDadosProduto();
            seccondLabel.BringToFront();
            Funcoes.Notificar("AVISO", "Produto não inserido.");
        }

        private void btnCancelarAttProduto_Click(object sender, EventArgs e)
        {
            LimparDadosProduto();
            seccondLabel.BringToFront();
            Funcoes.Notificar("AVISO", "Atualização Cancelada.");
        }

        private void PlaceHolders()
        {
            Funcoes.SetPlaceholder(tb_Pesquisa, "Digite para pesquisar nos dados...");
            Funcoes.SetPlaceholder(tb_NomeCliente, "Digite o nome do cliente...");
            Funcoes.SetPlaceholder(tb_EmailCliente, "Digite o email do cliente...");
            Funcoes.SetPlaceholder(tb_EnderecoCliente, "Digite o endereço do cliente...");
            Funcoes.SetPlaceholder(tb_AnotacoesCliente, "Digite aqui anotações para este cliente...");
            Funcoes.SetPlaceholder(tb_PesquisarProduto, "Digite o nome ou codigo do produto...");
            Funcoes.SetPlaceholder(tbAttDescProduto, "Digite o nome do produto.");
            Funcoes.SetPlaceholder(tbAttPrecoProduto, "Digite o preço, ex: '1000' é '1.000'.");
            Funcoes.SetPlaceholder(tbAttPesoProduto, "Digite o peso em gramas, ex: '1000' é 1KG.");
            Funcoes.SetPlaceholder(tbAttQuantidadeProduto, "Digite a quantidade, ex: '1' = '1,00' é 1 unidade.");
            Funcoes.SetPlaceholder(tb_DescricaoProduto, "Digite o nome do produto.");
            Funcoes.SetPlaceholder(tb_PrecoProduto, "Digite o preço, ex: '1000' é '1.000'.");
            Funcoes.SetPlaceholder(tb_PesoProduto, "Digite o peso em gramas, ex: '1000' é 1KG.");
            Funcoes.SetPlaceholder(tb_QuantidadeProduto, "Digite a quantidade, ex: '1' = '1,00' é 1 unidade.");
        }

        private void tbAttPrecoProduto_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(tbAttPrecoProduto.Text, out decimal preco))
            {
                tbAttPrecoProduto.Text = preco.ToString("N2");
            }
        }

        private void tbAttPesoProduto_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(tbAttPesoProduto.Text, out decimal preco))
            {
                tbAttPesoProduto.Text = preco.ToString("N2");
            }
        }

        private void tbAttQuantidadeProduto_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(tbAttQuantidadeProduto.Text, out decimal preco))
            {
                tbAttQuantidadeProduto.Text = preco.ToString("N2");
            }
        }

        private void tbAttPrecoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1 || (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbAttPesoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1 || (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbAttQuantidadeProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1 || (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tb_PrecoProduto_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(tb_PrecoProduto.Text, out decimal preco))
            {
                tb_PrecoProduto.Text = preco.ToString("N2");
            }
        }

        private void tb_PesoProduto_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(tb_PesoProduto.Text, out decimal preco))
            {
                tb_PesoProduto.Text = preco.ToString("N2");
            }
        }

        private void tb_QuantidadeProduto_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(tb_QuantidadeProduto.Text, out decimal preco))
            {
                tb_QuantidadeProduto.Text = preco.ToString("N2");
            }
        }

        private void tb_PrecoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1 || (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tb_PesoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1 || (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tb_QuantidadeProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',' || e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(',') > -1 || (sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
