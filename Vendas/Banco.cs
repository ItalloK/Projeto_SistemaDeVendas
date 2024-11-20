using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using static Supermercado.Produtos;
using System.Drawing;

namespace Supermercado
{
    internal class Banco
    {
        private static string stringConexao = "Data Source=Banco de Dados\\banco.db;Version=3;";

        static Banco()
        {
            VerificarBanco();
        }

        /* ------------------------------- Clientes ------------------------------- */
        public static bool CadastrarCliente(string nome, string telefone, string email, string cpf, string dataNasc, string endereco, string anotacoes)
        {
            try
            {
                string query = "INSERT INTO clientes (nome, telefone, email, cpf, dataNasc, endereco, anotacoes) VALUES (@nome, @telefone, @email, @cpf, @dataNasc, @endereco, @anotacoes)";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nome", nome);
                        command.Parameters.AddWithValue("@telefone", telefone);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@cpf", cpf);
                        command.Parameters.AddWithValue("@dataNasc", dataNasc);
                        command.Parameters.AddWithValue("@endereco", endereco);
                        command.Parameters.AddWithValue("@anotacoes", anotacoes);

                        command.ExecuteNonQuery();
                    }
                }
                Funcoes.Notificar("SUCESSO", "Cliente Inserido com Sucesso!");
                return true;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal("Erro ao inserir cliente no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao inserir cliente, olhe o LOG!");
                return false;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal("Erro ao inserir cliente no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao inserir cliente, olhe o LOG!");
                return false;
            }
        }

        public static bool AtualizarCliente(string nome, string telefone, string email, string cpf, string dataNasc, string endereco, string anotacoes)
        {
            try
            {
                string query = "UPDATE clientes SET nome = @nome, telefone = @telefone, email = @email, dataNasc = @dataNasc, endereco = @endereco, anotacoes = @anotacoes WHERE cpf = @cpf";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nome", nome);
                        command.Parameters.AddWithValue("@telefone", telefone);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@cpf", cpf);
                        command.Parameters.AddWithValue("@dataNasc", dataNasc);
                        command.Parameters.AddWithValue("@endereco", endereco);
                        command.Parameters.AddWithValue("@anotacoes", anotacoes);

                        command.ExecuteNonQuery();
                    }
                }
                Funcoes.Notificar("SUCESSO", "Cliente Atualizado com Sucesso!");
                return true;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal("Erro ao atualizar cliente no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao atualizar cliente, olhe o LOG!");
                return false;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal("Erro ao atualizar cliente no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao atualizar cliente, olhe o LOG!");
                return false;
            }
        }

        public static bool DeletarCliente(int id)
        {
            try
            {
                string query = "DELETE FROM clientes WHERE id = @id";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                Funcoes.Notificar("SUCESSO", "Cliente deletado com Sucesso!");
                return true;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal("Erro ao deletar cliente no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao deletar cliente, olhe o LOG!");
                return false;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal("Erro ao deletar cliente no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao deletar cliente, olhe o LOG!");
                return false;
            }
        }

        public static bool DeletarProduto(int id)
        {
            try
            {
                string query = "DELETE FROM produtos WHERE id = @id";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                Funcoes.Notificar("SUCESSO", "Produto deletado com Sucesso!");
                return true;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal("Erro ao deletar Produto no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao deletar Produto, olhe o LOG!");
                return false;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal("Erro ao deletar Produto no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao deletar Produto, olhe o LOG!");
                return false;
            }
        }

        public static DataTable DadosClientes()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM clientes";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal($"Erro SQL: {ex.Message}");
                Funcoes.Notificar("ERRO", "Erro ao receber dados, olhe o LOG!");
                return null;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal($"Erro SQL: {ex.Message}");
                Funcoes.Notificar("ERRO", "Erro ao receber dados, olhe o LOG!");
                return null;
            }
        }
        /* ------------------------------- Clientes ------------------------------- */


        /* ------------------------------- Produtos ------------------------------- */

        public static bool CadastrarProduto(string codigo, string descricao, decimal preco, decimal quantidade, decimal peso)
        {
            try
            {
                string query = "INSERT INTO produtos (codigo, descricao, preco, quantidade, peso) VALUES (@codigo,@descricao, @preco, @quantidade, @peso)";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", codigo);
                        command.Parameters.AddWithValue("@descricao", descricao);
                        command.Parameters.AddWithValue("@preco", preco);
                        command.Parameters.AddWithValue("@quantidade", quantidade);
                        command.Parameters.AddWithValue("@peso", peso);
                        command.ExecuteNonQuery();
                    }
                }
                Funcoes.Notificar("SUCESSO", "Produto Inserido com Sucesso!");
                return true;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal("Erro ao inserir Produto no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao inserir Produto, olhe o LOG!");
                return false;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal("Erro ao inserir Produto no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao inserir Produto, olhe o LOG!");
                return false;
            }
        }

        public static bool AtualizarProduto(string codigo, string descricao, decimal preco, decimal peso, decimal quantidade, int id)
        {
            try
            {
                string query = "UPDATE produtos SET codigo = @codigo, descricao = @descricao, preco = @preco, peso = @peso, quantidade = @quantidade WHERE id = @id";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigo", codigo);
                        command.Parameters.AddWithValue("@descricao", descricao);
                        command.Parameters.AddWithValue("@preco", preco);
                        command.Parameters.AddWithValue("@peso", peso);
                        command.Parameters.AddWithValue("@quantidade", quantidade);
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
                Funcoes.Notificar("SUCESSO", "Produto Atualizado com Sucesso!");
                return true;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal("Erro ao atualizar Produto no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao atualizar Produto, olhe o LOG!");
                return false;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal("Erro ao atualizar Produto no banco de dados: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao atualizar Produto, olhe o LOG!");
                return false;
            }
        }

        public static DataTable Estoque()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM produtos";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal($"Erro SQL: {ex.Message}");
                Funcoes.Notificar("ERRO", "Erro ao receber dados, olhe o LOG!");
                return null;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal($"Erro SQL: {ex.Message}");
                Funcoes.Notificar("ERRO", "Erro ao receber dados, olhe o LOG!");
                return null;
            }
        }
        /* ------------------------------- Produtos ------------------------------- */

        public static DataTable VendasPorData(string data)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM vendas WHERE DATE(dataVenda) = @data;";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            command.Parameters.AddWithValue("@data", data);
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal($"Erro SQL: {ex.Message}");
                Funcoes.Notificar("ERRO", "Erro ao receber dados, olhe o LOG!");
                return null;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal($"Erro SQL: {ex.Message}");
                Funcoes.Notificar("ERRO", "Erro ao receber dados, olhe o LOG!");
                return null;
            }
        }

        public static DataTable Vendas()
        {
            try
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM vendas";
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (SQLiteException ex)
            {
                Funcoes.CriarLogLocal($"Erro SQL: {ex.Message}");
                Funcoes.Notificar("ERRO", "Erro ao receber dados, olhe o LOG!");
                return null;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal($"Erro SQL: {ex.Message}");
                Funcoes.Notificar("ERRO", "Erro ao receber dados, olhe o LOG!");
                return null;
            }
        }

        private static void VerificarBanco()
        {
            if (!Directory.Exists("Banco de Dados"))
            {
                Directory.CreateDirectory("Banco de Dados");
            }

            if (!File.Exists("Banco de Dados\\banco.db"))
            {
                SQLiteConnection.CreateFile("Banco de Dados\\banco.db");
                Console.WriteLine("Banco de dados criado com sucesso!");

                using (SQLiteConnection conexao = new SQLiteConnection(stringConexao))
                {
                    conexao.Open();
                    var tabelasSQL = new Dictionary<string, string>
            {
                { "clientes", @"
                    CREATE TABLE IF NOT EXISTS clientes (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome TEXT NOT NULL,
                        email TEXT,
                        telefone TEXT,
                        cpf TEXT, 
                        dataNasc TEXT,
                        endereco TEXT,
                        anotacoes TEXT
                    )" },
                { "produtos", @"
                    CREATE TABLE IF NOT EXISTS produtos (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        codigo TEXT NOT NULL,
                        descricao TEXT NOT NULL,
                        preco NUMERIC NOT NULL DEFAULT 0,
                        quantidade NUMERIC NOT NULL DEFAULT 0,
                        peso NUMERIC DEFAULT 0
                    )" },
                { "vendas", @"
                    CREATE TABLE IF NOT EXISTS vendas (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        dataVenda TEXT NOT NULL,
                        total NUMERIC NOT NULL,
                        vendedor TEXT NOT NULL,
                        clienteCpf TEXT,
                        FOREIGN KEY (clienteCpf) REFERENCES clientes(cpf)
                    )" },
                { "funcionarios", @"
                    CREATE TABLE IF NOT EXISTS funcionarios (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome TEXT NOT NULL,
                        email TEXT,
                        cpf TEXT NOT NULL,
                        codigo TEXT,
                        telefone TEXT,
                        datanascimento TEXT NOT NULL,
                        senha TEXT NOT NULL
                    )" },
                { "itens_venda", @"
                    CREATE TABLE IF NOT EXISTS itens_venda (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        venda_id INTEGER NOT NULL,
                        produto_id INTEGER NOT NULL,
                        quantidade NUMERIC NOT NULL,
                        preco_unitario NUMERIC NOT NULL,
                        FOREIGN KEY (venda_id) REFERENCES vendas(id),
                        FOREIGN KEY (produto_id) REFERENCES produtos(id)
                    )" }
            };

                    foreach (var tabela in tabelasSQL)
                    {
                        using (SQLiteCommand comando = new SQLiteCommand(tabela.Value, conexao))
                        {
                            comando.ExecuteNonQuery();
                            Console.WriteLine($"Tabela '{tabela.Key}' verificada/criada com sucesso.");
                        }
                    }

                    conexao.Close();
                }
            }
            else
            {
                Console.WriteLine("O banco de dados já existe.");
            }
        }


        public static Produto BuscarProdutoPorCodigo(string codigoDeBarras)
        {
            Produto produto = null;

            string query = "SELECT * FROM produtos WHERE codigo = @codigo";
            using (var connection = new SQLiteConnection(stringConexao))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@codigo", codigoDeBarras);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produto = new Produto
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Codigo = reader["codigo"].ToString(),
                                Descricao = reader["descricao"].ToString(),
                                Preco = Convert.ToDecimal(reader["preco"]),
                                Quantidade = Convert.ToInt32(reader["quantidade"]),
                                Peso = Convert.ToDecimal(reader["peso"])
                            };
                        }
                    }
                }
            }

            return produto;
        }

        public static void AtualizarEstoqueProduto(string codigo, int novoEstoque)
        {
            using (var conn = new SQLiteConnection(stringConexao))
            {
                conn.Open();
                string sql = "UPDATE produtos SET quantidade = @quantidade WHERE codigo = @codigo";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@quantidade", novoEstoque);
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool FecharVenda(List<Produto> itens, decimal totalVenda, string vendedor)
        {
            try
            {
                using (var connection = new SQLiteConnection(stringConexao))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        string queryVenda = "INSERT INTO vendas (dataVenda, total, vendedor) VALUES (@data, @total, @vendedor); SELECT last_insert_rowid();";
                        int vendaId;
                        using (var command = new SQLiteCommand(queryVenda, connection))
                        {
                            command.Parameters.AddWithValue("@data", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@total", totalVenda);
                            command.Parameters.AddWithValue("@vendedor", vendedor);

                            vendaId = Convert.ToInt32(command.ExecuteScalar());
                        }

                        string queryItem = "INSERT INTO itens_venda (venda_id, produto_id, quantidade, preco_unitario) VALUES (@venda_id, @produto_id, @quantidade, @preco_unitario)";
                        foreach (var item in itens)
                        {
                            using (var command = new SQLiteCommand(queryItem, connection))
                            {
                                command.Parameters.AddWithValue("@venda_id", vendaId);
                                command.Parameters.AddWithValue("@produto_id", item.Id);
                                command.Parameters.AddWithValue("@quantidade", item.Quantidade);
                                command.Parameters.AddWithValue("@preco_unitario", item.Preco);

                                command.ExecuteNonQuery();
                            }

                            string queryEstoqueAtual = "SELECT quantidade FROM produtos WHERE codigo = @codigo";
                            int estoqueAtual = 0;

                            using (var command = new SQLiteCommand(queryEstoqueAtual, connection))
                            {
                                command.Parameters.AddWithValue("@codigo", item.Codigo);
                                estoqueAtual = Convert.ToInt32(command.ExecuteScalar());
                            }

                            if (estoqueAtual < item.Quantidade)
                            {
                                Funcoes.CriarLogLocal($"Não há estoque suficiente para o produto {item.Descricao} (Código: {item.Codigo}). Estoque disponível: {estoqueAtual}");
                            }

                            string queryEstoque = "UPDATE produtos SET quantidade = quantidade - @quantidade WHERE codigo = @codigo";
                            using (var command = new SQLiteCommand(queryEstoque, connection))
                            {
                                command.Parameters.AddWithValue("@quantidade", item.Quantidade);
                                command.Parameters.AddWithValue("@codigo", item.Codigo);

                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }

                Funcoes.Notificar("SUCESSO", "Venda registrada com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Funcoes.CriarLogLocal("Erro ao registrar venda: " + ex.Message);
                Funcoes.Notificar("ERRO", "Erro ao registrar venda, verifique o LOG!");
                return false;
            }
        }

        

        public static Contas.Conta VerificarConta(string emailOrCodigo, string senha)
        {
            using (var connection = new SQLiteConnection(stringConexao))
            {
                connection.Open();
                string query = @"SELECT * FROM funcionarios WHERE senha = @Senha AND (email = @emailOrCodigo OR codigo = @emailOrCodigo)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@emailOrCodigo", emailOrCodigo);
                    command.Parameters.AddWithValue("@Senha", senha);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Contas.Conta
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Email = reader.GetString(2),   
                                Cpf = reader.GetString(3),
                                Codigo = reader.GetString(4),
                                Telefone = reader.GetString(5),
                                DataNascimento = reader.GetString(6)
                            };
                        }
                        else
                        {
                            Console.WriteLine("ERRO");
                            return null;
                        }
                    }
                }
            }
        }

    }
}
