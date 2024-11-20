using Supermercado.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supermercado.Produtos;
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
            AtivarPainel(homeLabel); // ativa apenas o home
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
        private string codigoProduto;
        private string descricaoProduto;
        private decimal precoProduto;
        private decimal pesoProduto;
        private decimal quantidadeProduto;

        private int idProdutoDGV = -1;

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {
            CarregarClientes(); // fazer função
            CarregarEstoque();
            CarregarRelatorios();
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
            AtivarPainel(painelRealizarVenda);
        }

        private void btn_Estoque_Click(object sender, EventArgs e)
        {
            if (verificarFuncionario() == false) { MessageBox.Show("Você não está logado como funcionario."); return; }
            slidePanel.Height = btn_Estoque.Height;
            slidePanel.Top = btn_Estoque.Top;  // Ajusta a posição vertical
            AtivarPainel(painelVerEstoque);
        }

        private void btn_Clientes_Click(object sender, EventArgs e)
        {
            if (verificarFuncionario() == false) { MessageBox.Show("Você não está logado como funcionario."); return; }
            slidePanel.Height = btn_Clientes.Height;
            slidePanel.Top = btn_Clientes.Top;  // Ajusta a posição vertical
            AtivarPainel(painelClientes);
        }

        private void btn_Relatorios_Click(object sender, EventArgs e)
        {
            if (verificarFuncionario() == false) { MessageBox.Show("Você não está logado como funcionario."); return; }
            slidePanel.Height = btn_Relatorios.Height;
            slidePanel.Top = btn_Relatorios.Top;  // Ajusta a posição vertical
            AtivarPainel(fourLabel);
        }

        private void btn_Funcionario_Click(object sender, EventArgs e)
        {
            slidePanel.Height = btn_Funcionario.Height;
            slidePanel.Top = btn_Funcionario.Top;
            if (verificarFuncionario() == false)
            {
                AtivarPainel(panel_Login);
                return;
            }
            AtivarPainel(painelFuncionario);
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
            AtivarPainel(homeLabel);
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

        private void btn_CancelarCadCliente_Click(object sender, EventArgs e)
        {
            LimparDados();
            AtivarPainel(painelClientes);
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

            dgv_Estoque.Columns["id"].DisplayIndex = 0;
            dgv_Estoque.Columns["codigo"].DisplayIndex = 1;
            dgv_Estoque.Columns["descricao"].DisplayIndex = 2;
            dgv_Estoque.Columns["preco"].DisplayIndex = 3;
            dgv_Estoque.Columns["peso"].DisplayIndex = 4;
            dgv_Estoque.Columns["quantidade"].DisplayIndex = 5;

            dgv_Estoque.Columns["preco"].DefaultCellStyle.Format = "C2";

            dgv_Estoque.Columns["id"].HeaderText = "ID";
            dgv_Estoque.Columns["codigo"].HeaderText = "Cod. Produto";
            dgv_Estoque.Columns["descricao"].HeaderText = "Desc. Produto";
            dgv_Estoque.Columns["preco"].HeaderText = "Preço";
            dgv_Estoque.Columns["peso"].HeaderText = "Peso";
            dgv_Estoque.Columns["quantidade"].HeaderText = "Quantidade";

            //dgv_Estoque.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void CarregarRelatorios()
        {
            dgv_DadosRelatorios.DataSource = Banco.Vendas();

            EstatisticasRelatorios();

            dgv_DadosRelatorios.Columns["id"].Visible = false; // oculta id

            dgv_DadosRelatorios.Columns["dataVenda"].DisplayIndex = 0; // altera ordem
            dgv_DadosRelatorios.Columns["total"].DisplayIndex = 1;
            dgv_DadosRelatorios.Columns["vendedor"].DisplayIndex = 2;
            dgv_DadosRelatorios.Columns["clienteCpf"].DisplayIndex = 3;

            dgv_DadosRelatorios.Columns["total"].DefaultCellStyle.Format = "C2";

            dgv_DadosRelatorios.Columns["dataVenda"].HeaderText = "Data da Venda"; // altera nome
            dgv_DadosRelatorios.Columns["total"].HeaderText = "Valor da Venda";
            dgv_DadosRelatorios.Columns["vendedor"].HeaderText = "Vendedor";
            dgv_DadosRelatorios.Columns["clienteCpf"].HeaderText = "Cpf do Cliente";

            dgv_DadosRelatorios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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
                AtivarPainel(painelClientes);
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

        private void PegarDadosCliente()
        {
            if(idCliente != -1)
            {
                AtivarPainel(panelAttCliente);
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
            AtivarPainel(painelClientes);
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
                AtivarPainel(painelClientes);
                LimparDados();
                CarregarClientes();
            }
            else
            {
                return;
            }
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

        private void PegarDadosProduto()
        {
            if (idProduto != -1)
            {
                AtivarPainel(PanelAttProduto);
                tbAttCodigoProduto.Text = codigoProduto;
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
            string codigo = tbAttCodigoProduto.Text;
            var result = Banco.AtualizarProduto(codigo, descricao, preco, peso, quantidade, idProduto);
            if (result)
            {
                AtivarPainel(painelVerEstoque);
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
                idProduto = Convert.ToInt32(selectedRow.Cells["id"].Value);
                codigoProduto = selectedRow.Cells["codigo"].Value.ToString();
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
            string codigo = tb_CodigoProduto.Text;

            var result = Banco.CadastrarProduto(codigo, descricao, preco, quantidade, peso);
            if (result)
            {
                AtivarPainel(painelVerEstoque);
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
            AtivarPainel(painelVerEstoque);
            Funcoes.Notificar("AVISO", "Produto não inserido.");
        }

        private void btnCancelarAttProduto_Click(object sender, EventArgs e)
        {
            LimparDadosProduto();
            AtivarPainel(painelVerEstoque);
            Funcoes.Notificar("AVISO", "Atualização Cancelada.");
        }

        private void PlaceHolders()
        {
            //Funcoes.SetPlaceholder(tb_Pesquisa, "Digite o Nome ou CPF do cliente...");
            //Funcoes.SetPlaceholder(tb_PesquisarProduto, "Digite o nome ou codigo do produto...");

            /* Os de cima removido devido a bugs na hora de pesquisar, e o placeholder influencia. */

            Funcoes.SetPlaceholder(tb_NomeCliente, "Digite o nome do cliente...");
            Funcoes.SetPlaceholder(tb_EmailCliente, "Digite o email do cliente...");
            Funcoes.SetPlaceholder(tb_EnderecoCliente, "Digite o endereço do cliente...");
            Funcoes.SetPlaceholder(tb_AnotacoesCliente, "Digite aqui anotações para este cliente...");
            Funcoes.SetPlaceholder(tbAttDescProduto, "Digite o nome do produto.");
            Funcoes.SetPlaceholder(tbAttPrecoProduto, "Digite o preço, ex: '1000' é '1.000'.");
            Funcoes.SetPlaceholder(tbAttPesoProduto, "Digite o peso em gramas, ex: '1000' é 1KG.");
            Funcoes.SetPlaceholder(tbAttQuantidadeProduto, "Digite a quantidade, ex: '1' = '1,00' é 1 unidade.");
            Funcoes.SetPlaceholder(tb_DescricaoProduto, "Digite o nome do produto.");
            Funcoes.SetPlaceholder(tb_PrecoProduto, "Digite o preço, ex: '1000' é '1.000'.");
            Funcoes.SetPlaceholder(tb_PesoProduto, "Digite o peso em gramas, ex: '1000' é 1KG.");
            Funcoes.SetPlaceholder(tb_QuantidadeProduto, "Digite a quantidade, ex: '1' = '1,00' é 1 unidade.");
            Funcoes.SetPlaceholder(tbAttCodigoProduto, "Digite o código do produto.");
            Funcoes.SetPlaceholder(tb_CodigoProduto, "Digite o código do produto.");
            Funcoes.SetPlaceholder(tb_EmailOuCodigo, "Digite o Email ou Codigo de login...");
            Funcoes.SetPlaceholder(tb_SenhaUsuario, "******");

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

        private void tb_PesquisarProduto_TextChanged(object sender, EventArgs e)
        {
            string filterText = tb_PesquisarProduto.Text;
            if (dgv_Estoque.DataSource is DataTable dataTable)
            {
                if (!string.IsNullOrEmpty(filterText))
                {
                    dataTable.DefaultView.RowFilter = $"descricao LIKE '%{filterText}%' or codigo LIKE '%{filterText}%'";
                }
                else
                {
                    dataTable.DefaultView.RowFilter = string.Empty;
                }
            }
            else
            {
                Console.WriteLine("DataSource não é um DataTable.");
            }
        }

        private void tb_Pesquisa_TextChanged(object sender, EventArgs e)
        {
            string filterText = tb_Pesquisa.Text;
            if (dgv_Dados.DataSource is DataTable dataTable)
            {
                if (!string.IsNullOrEmpty(filterText))
                {
                    dataTable.DefaultView.RowFilter = $"nome LIKE '%{filterText}%' or cpf LIKE '%{filterText}%'";
                }
                else
                {
                    dataTable.DefaultView.RowFilter = string.Empty;
                }
            }
            else
            {
                Console.WriteLine("DataSource não é um DataTable.");
            }
        }

        private void AtivarPainel(Panel painelAtivar)
        {
            painelRealizarVenda.Visible = false; // Painel que realiza a venda
            panelAttCliente.Visible = false; // Painel de Atualizar Cliente
            painelCadCliente.Visible = false; // Painel de Cadastrar Cliente
            painelClientes.Visible = false; // Painel que mostra os Clientes
            PanelAttProduto.Visible = false; // Painel para Atualizar Produtos
            PanelCadProduto.Visible = false; // Painel para Cadastrar Produtos
            homeLabel.Visible = false; // Painel onde fica as Promos ( home )
            painelFuncionario.Visible = false; // Painel que mostra os dados do funcionario
            painelVerEstoque.Visible = false; // Painel onde ver o estoque e funcionalidades dos produtos
            fourLabel.Visible = false; // não sei
            panel_Login.Visible = false;
            painelAtivar.Visible = true;
        }

        private void TelaPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (painelRealizarVenda.Visible && e.KeyCode == Keys.F1)
            {
                
                DialogResult resultado = MessageBox.Show("Você deseja inciar uma nova Venda?", "Confirmação", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    if (listaDeProdutos.Count > 0)
                    {
                        MessageBox.Show("Carrinho limpo.");
                        CancelarVenda();
                        CarregarEstoque();   
                    }
                    tb_CodigoDeBarrasV.Focus(); // foca no codigo de barras
                    tb_QntItensV.Text = 1.ToString(); // poe a quantidade inicial de itens
                }
                else if (resultado == DialogResult.No)
                {
                    Funcoes.Notificar("AVISO", "Você não inicio uma nova venda.");
                }
                e.Handled = true;
            }
            if (painelRealizarVenda.Visible && e.KeyCode == Keys.F5)
            {
                if (listaDeProdutos.Count <= 0)
                {
                    MessageBox.Show("Não há itens no carrinho.");
                    return;
                }
                DialogResult resultado = MessageBox.Show("Você deseja finalizar a Venda?", "Confirmação", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    FinalizarVenda();
                }
                else if (resultado == DialogResult.No)
                {
                    Funcoes.Notificar("AVISO", "Você não finalizou a venda.");
                }
                e.Handled = true;
            }
            if (painelRealizarVenda.Visible && e.KeyCode == Keys.F4)
            {
                DialogResult resultado = MessageBox.Show("Você deseja Cancelar a Venda?", "Confirmação", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    CancelarVenda();
                    CarregarEstoque();
                }
                else if (resultado == DialogResult.No)
                {
                    Funcoes.Notificar("AVISO", "Você não cancelou a venda.");
                }
                e.Handled = true;
            }

            if (painelRealizarVenda.Visible && e.KeyCode == Keys.F3)
            {
                DialogResult resultado = MessageBox.Show($"Você deseja remover o Item?", "Confirmação", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    if(idProdutoDGV != -1)
                    {
                        CancelarVendaPorId(idProdutoDGV);
                    }
                    else
                    {
                        Funcoes.Notificar("ERRO", "Nenhum item selecionado.");
                    }
                }
                else if (resultado == DialogResult.No)
                {
                    Funcoes.Notificar("AVISO", "Você não removeu o item.");
                }
                e.Handled = true;
            }
        }

        private void tb_QntItensV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_CodigoDeBarrasV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void tb_TotalRecebidoV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private List<Produto> listaDeProdutos = new List<Produto>(); // Lista para armazenar os produtos

        private void tb_CodigoDeBarrasV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PesquisarItemV(); 
                e.SuppressKeyPress = true;
            }
        }

        private void PesquisarItemV()
        {
            if (string.IsNullOrEmpty(tb_QntItensV.Text) || !int.TryParse(tb_QntItensV.Text, out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Por favor, insira uma quantidade válida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string codigoDeBarras = tb_CodigoDeBarrasV.Text;
            Produto produto = Banco.BuscarProdutoPorCodigo(codigoDeBarras);

            if (produto == null)
            {
                MessageBox.Show("Produto não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (quantidade > produto.Quantidade)
            {
                MessageBox.Show($"Quantidade solicitada ({quantidade}) é maior que o estoque disponível ({produto.Quantidade}).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_QntItensV.Text = produto.Quantidade.ToString();
                return;
            }
            lbl_DescProdutoV.Text = string.Empty;
            tb_ValorUnitarioV.Text = string.Empty;
            AdicionarProdutoNaLista(produto, quantidade);
            tb_CodigoDeBarrasV.Clear();
            lbl_DescProdutoV.Text = produto.Descricao;
            tb_ValorUnitarioV.Text = produto.Preco.ToString("N2");
            tb_QntItensV.Text = "1";
            AtualizarDataGridView();
            CalcularSubTotal();
        }

        private void AdicionarProdutoNaLista(Produto produto, int quantidade)
        {
            Produto produtoExistente = listaDeProdutos.FirstOrDefault(p => p.Codigo == produto.Codigo);

            if (produtoExistente != null)
            {
                produtoExistente.Quantidade += quantidade;
            }
            else
            {
                int novoIdExibicao = listaDeProdutos.Count > 0 ? listaDeProdutos.Max(p => p.IdExibicao) + 1 : 1;

                Produto produtoComQuantidade = new Produto
                {
                    Id = produto.Id,
                    Codigo = produto.Codigo,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Quantidade = quantidade,
                    Peso = produto.Peso,
                    IdExibicao = novoIdExibicao
                };

                listaDeProdutos.Add(produtoComQuantidade);
            }
        }

        private void FinalizarVenda()
        {
            decimal totalVenda = listaDeProdutos.Sum(p => p.Quantidade * p.Preco);

            if (Banco.FecharVenda(listaDeProdutos, totalVenda, Global.cpfFuncionario))
            {
                listaDeProdutos.Clear();
                AtualizarDataGridView();
                MessageBox.Show("Venda finalizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CarregarEstoque();
                LimparCarrinho();
                CarregarRelatorios();
            }
            else
            {
                MessageBox.Show("Erro ao finalizar a venda. Verifique o log.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AtualizarDataGridView()
        {
            dgv_ListaProdutos.DataSource = null;
            dgv_ListaProdutos.DataSource = listaDeProdutos;

            dgv_ListaProdutos.Columns["IdExibicao"].HeaderText = "ID";
            dgv_ListaProdutos.Columns["Codigo"].HeaderText = "Código";
            dgv_ListaProdutos.Columns["Descricao"].HeaderText = "Descrição";
            dgv_ListaProdutos.Columns["Quantidade"].HeaderText = "Quantidade";
            dgv_ListaProdutos.Columns["Preco"].HeaderText = "Preço Unitário";

            dgv_ListaProdutos.Columns["Preco"].DefaultCellStyle.Format = "C2";

            dgv_ListaProdutos.Columns["Id"].Visible = false;
            dgv_ListaProdutos.Columns["peso"].Visible = false;

            dgv_ListaProdutos.Columns["IdExibicao"].DisplayIndex = 0;
            dgv_ListaProdutos.Columns["Codigo"].DisplayIndex = 1;
            dgv_ListaProdutos.Columns["Descricao"].DisplayIndex = 2;
            dgv_ListaProdutos.Columns["Quantidade"].DisplayIndex = 3;
            dgv_ListaProdutos.Columns["Preco"].DisplayIndex = 4;

            dgv_ListaProdutos.Columns["IdExibicao"].Width = 50;
            dgv_ListaProdutos.Columns["Codigo"].Width = 100;
            dgv_ListaProdutos.Columns["Descricao"].Width = 200;
            dgv_ListaProdutos.Columns["Quantidade"].Width = 80;
            dgv_ListaProdutos.Columns["Preco"].Width = 100;
        }

        private void CalcularSubTotal()
        {
            decimal total = 0;

            foreach (var produto in listaDeProdutos)
            {
                total += produto.Preco * produto.Quantidade;
            }

            tb_SubTotalV.Text = $"R$ {total:N2}";
            
        }

        private void tb_TotalRecebidoV_TextChanged(object sender, EventArgs e)
        {
            CalcularTroco();
        }

        private void CalcularTroco()
        {
            if (decimal.TryParse(tb_SubTotalV.Text.Replace("R$", "").Trim(), out decimal subtotal) &&
                decimal.TryParse(tb_TotalRecebidoV.Text, out decimal valorPago))
            {
                if (valorPago >= subtotal)
                {
                    decimal troco = valorPago - subtotal;
                    tb_TrocoV.Text = $"R$ {troco:N2}";
                }
                else
                {
                    tb_TrocoV.Text = "Valor insuficiente";
                }
            }
            else
            {
                tb_TrocoV.Clear();
            }
        }

        private void CancelarVenda()
        {
            if (listaDeProdutos.Count > 0)
            {
                LimparCarrinho();
                MessageBox.Show("Venda cancelada com sucesso.", "Cancelamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Não há produtos no carrinho para cancelar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCarrinho()
        {
            listaDeProdutos.Clear();
            AtualizarDataGridView();
            tb_SubTotalV.Clear();
            tb_TrocoV.Clear();
            tb_TotalRecebidoV.Clear();
            tb_ValorUnitarioV.Clear();
            tb_QntItensV.Text = 1.ToString();
        }

        private void dgv_ListaProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }


        private void CancelarVendaPorId(int idExibicao)
        {
            if (listaDeProdutos.Count > 0)
            {
                var produtoParaCancelar = listaDeProdutos.FirstOrDefault(p => p.IdExibicao == idExibicao);

                if (produtoParaCancelar != null)
                {
                    Produto produtoNoBanco = Banco.BuscarProdutoPorCodigo(produtoParaCancelar.Codigo);
                    if (produtoNoBanco != null)
                    {
                        listaDeProdutos.Remove(produtoParaCancelar);
                        AtualizarDataGridView();
                        CalcularSubTotal();
                        CarregarEstoque();
                        MessageBox.Show("Produto removido com sucesso.", "Cancelamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Produto não encontrado no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Produto não encontrado no carrinho.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Não há produtos no carrinho para cancelar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_ListaProdutos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_ListaProdutos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_ListaProdutos.SelectedRows[0];
                idProdutoDGV = Convert.ToInt32(selectedRow.Cells["IdExibicao"].Value);
            }
            else
            {
                idProdutoDGV = -1;
            }
        }

        private void tb_QntItensV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PesquisarItemV();
                e.SuppressKeyPress = true;
            }
        }

        private void btn_DeletarProduto_Click(object sender, EventArgs e)
        { 
            DeletarProduto();
        }

        private void DeletarProduto()
        {
            if (idProduto != -1)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja deletar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    var result = Banco.DeletarProduto(idProduto);
                    if (result)
                    {
                        CarregarEstoque();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    Funcoes.Notificar("AVISO", "Produto nao deletado.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Selecione um Produto para deletar!");
                return;
            }
        }

        private void btn_PesquisarRelatorio_Click(object sender, EventArgs e)
        {
            string dataSelecionada = dtp_DataRelatorio.Value.ToString("yyyy-MM-dd");
            var dt = Banco.VendasPorData(dataSelecionada);
            dgv_DadosRelatorios.DataSource = dt;
            EstatisticasRelatorios();
        }

        private void btn_VerTodosRelatorios_Click(object sender, EventArgs e)
        {
            CarregarRelatorios();
        }

        private void EstatisticasRelatorios()
        {
            decimal soma = 0;
            int qntVendas = 0;
            foreach (DataGridViewRow row in dgv_DadosRelatorios.Rows)
            {
                if (row.Cells["total"].Value != null && row.Cells["total"].Value != DBNull.Value)
                {
                    soma += Convert.ToDecimal(row.Cells["total"].Value);
                    qntVendas++;
                }
            }

            lbl_QntVendas.Text = $"Qnt Vendas: {qntVendas}";
            lbl_ValTotalVendas.Text = $"Total Vendas: R$ {soma}";
        }

        private void btn_NovoProduto_Click(object sender, EventArgs e)
        {
            LimparDadosProduto();
            AtivarPainel(PanelCadProduto);
        }

        private void btn_AtualizarProduto_Click(object sender, EventArgs e)
        {
            LimparDadosProduto();
            PegarDadosProduto();
        }

        private void btn_DeletarProduto_Click_1(object sender, EventArgs e)
        {
            DeletarProduto();
        }

        private void btn_CadCliente_Click(object sender, EventArgs e)
        {
            AtivarPainel(painelCadCliente);
        }

        private void btn_AttCliente_Click(object sender, EventArgs e)
        {
            LimparDados();
            PegarDadosCliente();
        }

        private void btn_DelCliente_Click(object sender, EventArgs e)
        {
            DeletarCliente();
        }

        private void btn_RealizarLogin_Click(object sender, EventArgs e)
        {
            RealizarLogin();
        }
        private void RealizarLogin()
        {
            string email = tb_EmailOuCodigo.Text;
            string senha = tb_SenhaUsuario.Text;
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                Funcoes.Notificar("ERRO", "Digite o Email/Codigo e a Senha.");
                return;
            }
            var conta = Banco.VerificarConta(email, senha);

            if (conta != null) 
            {
                AtivarPainel(painelFuncionario);
                lbl_DadosFuncionario.Text = $"Usuário: {conta.Nome} - CPF: {conta.Cpf}";

                Global.idFuncionario = conta.Id;
                Global.nomeFuncionario = conta.Nome;
                Global.emailFuncionario = conta.Email;
                Global.cpfFuncionario = conta.Cpf;
                Global.codigoFuncionario = conta.Codigo;
                Global.telefoneFuncionario = conta.Telefone;
                Global.datanascimentoFuncionario = conta.DataNascimento;

                lbl_NomeFunc.Text = $"Nome: {conta.Nome}";
                lbl_CPFFunc.Text = $"CPF: {conta.Cpf}";
                lbl_DataNascFunc.Text = $"Data de Nascimento: {conta.DataNascimento}";
                lbl_EmailFunc.Text = $"Email: {conta.Email}";
                lbl_CodigoFunc.Text = $"Código: {conta.Codigo}";
                lbl_TelefoneFunc.Text = $"Telefone: {conta.Telefone}";
            }
            else
            {
                Funcoes.Notificar("ERRO", "Email/Código ou Senha inválidos.");
                return;
            }
        }

        private void cb_ExibirSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (tb_SenhaUsuario.PasswordChar == '*')
            {
                tb_SenhaUsuario.PasswordChar = '\0';
                cb_ExibirSenha.Checked = true;
            }
            else
            {
                tb_SenhaUsuario.PasswordChar = '*';
                cb_ExibirSenha.Checked = false;
            }
        }
    }
}
