﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado
{
    internal class Contas
    {
        public class Conta
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Cpf { get; set; }
            public string Codigo { get; set; }
            public string Telefone { get; set; }
            public string DataNascimento { get; set; }
        }
        
    }
}
