﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
                ContaCorrente conta1 = new ContaCorrente(4588, 123669);
                ContaCorrente conta2 = new ContaCorrente(8977, 255633);

                //conta1.Transferir(1000, conta2);
                conta1.Sacar(5000);

            }
            catch (OperacaofinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                //Console.WriteLine("informações da INNER EXCEPTION (EXCEÇÃO INTERNA):");

            }

            try
            {
                ContaCorrente conta = new ContaCorrente(544, 4688);
                ContaCorrente conta2 = new ContaCorrente(545, 4678);

                conta2.Transferir(1000, conta);

                //conta.Depositar(50);
                conta.Sacar(-500);
                //Console.WriteLine(conta.Saldo);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Argumento com problema: " + ex.ParamName);
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Saldo);
                Console.WriteLine(ex.ValorSaque);

                Console.WriteLine(ex.StackTrace);

                Console.WriteLine("Exceção do Saldo insuficiente Exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //conta.Agencia = 465;

            Metodo();


            Console.ReadLine();
        }

        // Teste com a cadeia de chamada:
        // Metodo -> TestaDivisao -> Dividir

        private static void Metodo()
        {
            TestaDivisao(10);
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            //Console.WriteLine("Resultado da divisão de 10 por " + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            try
            {
                return numero / divisor;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com numero=" + numero + " e divisor=" + divisor);
                throw;
            }
        }
    }
}
