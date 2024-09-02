using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ContaBancaria
    {
        public string NumeroDaConta { get; set; }
        public string Agencia {  get; set; }
        public string Banco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public double Saldo { get; set; }

        private readonly object travaSaldo = new object();

        public ContaBancaria(string numeroDaConta, double saldoInicial, string agencia, string banco, string cidade, string estado)
        {
            NumeroDaConta = numeroDaConta;
            Saldo = saldoInicial;
            Agencia = agencia;
            Banco = banco;
            Cidade = cidade;
            Estado = estado;
        }

        public void Deposito(double quantia)
        {
            lock (travaSaldo)
            {
                Saldo += quantia;
                Console.WriteLine($"Conta {NumeroDaConta}: Depositado {quantia}, Saldo Atual: {Saldo}");
            }
        }

        public void Saque(double quantia)
        {
            lock (travaSaldo)
            {
                if (Saldo >= quantia)
                {
                    Saldo -= quantia;
                    Console.WriteLine($"Conta {NumeroDaConta}: Sacado {quantia}, Saldo Atual: {Saldo}");
                    return;
                }

                Console.WriteLine($"Conta {NumeroDaConta}: Saldo insuficiente para saque de {Saldo}");
            }
        }

        public override string ToString()
        {
            return $"Número da Conta: {NumeroDaConta,-10} | Agência: {Agencia,-6} | Banco: {Banco,-15} | Cidade: {Cidade,-15} | Estado: {Estado,-2} | Saldo: {Saldo,10:C}";
        }
    }
}
