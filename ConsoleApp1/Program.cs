using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ContaBancaria> contas = new List<ContaBancaria>
            {
                new ContaBancaria("78764-7", 7000, "5978", "Banco do Brasil", "Cariacica", "ES"),
                new ContaBancaria("1660050-4", 100, "6389", "Bradesco", "Porto Belo", "SC"),
                new ContaBancaria("43885652-0", 5000, "3712", "Santander", "Florianopolis", "SC")
            };

            List<Thread> threads = new List<Thread>();

            foreach (var conta in contas)
            {
                Thread threadDeposito = new Thread(() => RealizarTranzacoes(conta));
                Thread threadSaque = new Thread(() => RealizarTranzacoes(conta));
                threads.Add(threadDeposito);
                threads.Add(threadSaque);

                threadDeposito.Start();
                threadSaque.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("\nInformações das Contas:");
            Console.WriteLine(new string('-', 50));
            foreach (var conta in contas)
            {
                Console.WriteLine(conta);
            }

            // Mantém o console aberto até que o usuário pressione "Enter"
            Console.WriteLine("Pressione Enter para sair...");
            Console.ReadLine();
        }

        private static void RealizarTranzacoes(ContaBancaria conta)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int acao = random.Next(0, 2);
                double saldo = random.Next(1, 100);

                if (acao == 0)
                    conta.Deposito(saldo);
                else
                    conta.Saque(saldo);

                Thread.Sleep(random.Next(100, 500));
            }
        }
    }
}
