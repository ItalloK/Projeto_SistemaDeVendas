﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermercado
{
    internal class Funcoes
    {
        public static void SetPlaceholder(System.Windows.Forms.TextBox textBox, string placeholderText)
        {
            textBox.ForeColor = Color.Gray;
            textBox.Text = placeholderText;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        public static void Notificar(string tipo, string mensagem)
        {
            Notificacao not = new Notificacao(tipo, mensagem);
            not.Show();
        }

        public static void CriarLogLocal(string erroMessage)
        {
            LogLocal logLocal = new LogLocal();
            logLocal.RegistrarLog(erroMessage);
        }
    }
}
