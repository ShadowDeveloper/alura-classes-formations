﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ByteBank
{
    public class SaldoInsuficienteException : OperacaofinanceiraException
    {
        //public override string Message { get; set; }

        public double Saldo { get; }
        public double ValorSaque { get; }

        public SaldoInsuficienteException() { }

        public SaldoInsuficienteException(double saldo, double valorSaque) : this("Tentativa de saque do valor de " + valorSaque + " em uma conta com o saldo de " + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }

        public SaldoInsuficienteException(string mensagem) : base(mensagem) { }

        public SaldoInsuficienteException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna) { }
    }
}
