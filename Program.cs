using System;
using System.Globalization;
using System.Collections.Generic;
using RegistradorCantina.Entities;

namespace RegistradorCantina
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Produto> lista = new List<Produto>();
            int num = 0;

            Console.WriteLine("==================Registrador da Fast Lanches==================");
            do
            {
                Console.WriteLine("Digite 1 para adicionar produto");
                Console.WriteLine("Digite 2 para remover produto");
                Console.WriteLine("Digite 3 para modificar preço de um produto");
                Console.WriteLine("Digite 4 para verificar as validades");
                Console.WriteLine("Digite 0 para fechar o programa");
                Console.Write("Opção:");
                num = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                
                switch(num)
                {
                    case 1:
                        
                        Console.Write("Digite o nome do Produto:");
                        string nome = Console.ReadLine();
                        Console.Write("Digite o preço do Produto:");
                        double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Digite a data de validade do Produto (dia/mes/ano):");
                        DateTime validade = DateTime.Parse(Console.ReadLine());
                        Console.Write("Digite o lote do produto:");
                        string lote = Console.ReadLine();
                        Console.Write("Digite o estoque do Produto:");
                        int estoque = int.Parse(Console.ReadLine());
                        lista.Add(new Produto(nome, preco, validade, lote, estoque));
                        
                        Console.WriteLine("Produto Cadastrado\n");
                        break;

                    case 2:
                        Console.Write("Digite o lote do produto a remover: ");
                        lote = Console.ReadLine();
                        Produto produto = lista.Find(p => p.Lote == lote);
                        lista.Remove(produto);
                        
                        Console.WriteLine("Produto removido!\n");
                        break;

                    case 3:
                        Console.Write("Digite o lote do produto: ");
                        lote = Console.ReadLine();
                        produto = lista.Find(p => p.Lote == lote);
                        Console.Write("Novo preço: ");
                        double novoPreco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        produto.MudarPreço(novoPreco);

                        Console.WriteLine("Preço atualizado!\n");
                        break;

                    case 4:
                        int posicao = 0;
                            if (lista.Count == 0)
                            {
                                Console.WriteLine("Nenhum produto cadastrado.\n");
                                break;
                            }

                            DateTime hoje = DateTime.Today;

                            foreach (Produto p1 in lista)
                            {
                                posicao ++;
                                Console.WriteLine($"Produto:{posicao}");
                                Console.WriteLine($"\nProduto: {p1.Nome}");
                                Console.WriteLine($"Lote: {p1.Lote}");
                                Console.WriteLine($"Validade: {p1.Validade:dd/MM/yyyy}");

                                p1.AlertaValidade(hoje);
                            }

                            Console.WriteLine();
                                break;

                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!\n");
                        break;
                }
            }
            while (num != 0);
        }
    }
}
