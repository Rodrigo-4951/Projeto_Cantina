using System;
using System.Collections.Generic;
using System.Text;

namespace RegistradorCantina.Entities
{
    internal class Produto
    {
        public string Nome { get; set; }
        public double Preço { get; set; }
        public DateTime Validade { get; set; }
        public int Estoque { get; set; }
        public string Lote { get; set; }

        public Produto() 
        { 
        }

        public Produto(string nome, double preço, DateTime validade,string lote, int estoque)
        {
            Nome = nome;
            Preço = preço;
            Validade = validade;
            Lote = lote;
            Estoque = estoque;
        }

        public void MudarPreço(double novo)
        {
        Preço = novo;
        }

        public void AdicionarEstoque(int quantidade)
        {
            Estoque += quantidade;
        }

        public void VendaEstoque(int quantidade)
        {
            Estoque -= quantidade;
        }

        public void AlertaValidade(DateTime hoje)
        {
            int diasRestantes = (Validade.Date - hoje).Days;

                switch (diasRestantes)
            {
                case 30:
                    Console.WriteLine("Alerta: faltam 30 dias!");
                    break;

                case 14:
                    Console.WriteLine("Alerta: faltam 14 dias!");
                    break;

                case 7:
                    Console.WriteLine("Alerta: faltam 7 dias!");
                    break;

                case 0:
                    Console.WriteLine("Atenção: vence hoje!");
                    break;

                default:
                    if (diasRestantes < 0)
                        Console.WriteLine("Produto vencido!");
                    else
                        Console.WriteLine(
                            $"Faltam {diasRestantes} dias para o vencimento."
                        );
                    break;
            }
        }
    }
}
