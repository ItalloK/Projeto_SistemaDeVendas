﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using static Supermercado.Produtos;

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

                    string sqlClientes = @"
                    CREATE TABLE IF NOT EXISTS clientes (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        nome TEXT NOT NULL,
                        email TEXT,
                        telefone TEXT,
                        cpf TEXT, 
                        dataNasc TEXT,
                        endereco TEXT,
                        anotacoes TEXT
                    )";

                    string sqlProdutos = @"
                    CREATE TABLE IF NOT EXISTS produtos (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        codigo TEXT NOT NULL,
                        descricao TEXT NOT NULL,
                        preco NUMERIC NOT NULL DEFAULT 0,
                        quantidade NUMERIC NOT NULL DEFAULT 0,
                        peso NUMERIC DEFAULT 0
                    )";

                    using (SQLiteCommand comando = new SQLiteCommand(sqlClientes, conexao))
                    {
                        comando.ExecuteNonQuery();
                    }

                    using (SQLiteCommand comando = new SQLiteCommand(sqlProdutos, conexao))
                    {
                        comando.ExecuteNonQuery();
                    }

                    string verificarTabela = "SELECT name FROM sqlite_master WHERE type='table' AND name='clientes';";
                    using (SQLiteCommand cmdVerificar = new SQLiteCommand(verificarTabela, conexao))
                    {
                        var resultado = cmdVerificar.ExecuteScalar();
                        if (resultado != null)
                        {
                            Console.WriteLine("Tabela 'clientes' criada com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Erro ao criar tabela 'clientes'.");
                        }
                    }

                    Console.WriteLine("Tabelas criadas com sucesso!");
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
            using (var connection = new SQLiteConnection(stringConexao)) // Use sua conexão aqui
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
                                Quantidade = Convert.ToInt32(reader["quantidade"]), // Quantidade em estoque
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
    }
}
