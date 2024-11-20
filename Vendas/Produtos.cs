using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado
{
    internal class Produtos
    {
        public class Produto
        {
            public int Id { get; set; } 
            public string Codigo { get; set; }
            public string Descricao { get; set; }
            public decimal Preco { get; set; }
            public int Quantidade { get; set; }
            public decimal Peso { get; set; }
            public int IdExibicao { get; set; }
        }
    }
}
