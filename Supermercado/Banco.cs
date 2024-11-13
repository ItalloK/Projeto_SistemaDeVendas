using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace Supermercado
{
    internal class Banco
    {
        private static string stringConexao = "Data Source=banco.db;Version=3;";

        static Banco()
        {
            VerificarBanco();
        }

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
                MessageBox.Show($"Cliente {nome}, inserido com sucesso!");
                return true;
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Erro ao inserir cliente no banco de dados: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao cadastrar o cliente: " + ex.Message);
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
                MessageBox.Show($"Erro SQL: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
                return null;
            }
        }

        private static void VerificarBanco()
        {
            if (!File.Exists("banco.db"))
            {
                SQLiteConnection.CreateFile("banco.db");
                Console.WriteLine("Banco de dados criado com sucesso!");

                using (SQLiteConnection conexao = new SQLiteConnection("Data Source=banco.db;Version=3;"))
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
                    CREATE TABLE IF NOT EXISTS Produtos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Preco DECIMAL(10, 2) NOT NULL,
                        Quantidade INTEGER NOT NULL
                    )";

                    using (SQLiteCommand comando = new SQLiteCommand(sqlClientes, conexao))
                    {
                        comando.ExecuteNonQuery();
                    }

                    using (SQLiteCommand comando = new SQLiteCommand(sqlProdutos, conexao))
                    {
                        comando.ExecuteNonQuery();
                    }

                    // Verificando se a tabela 'clientes' foi criada corretamente
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
    }
}
