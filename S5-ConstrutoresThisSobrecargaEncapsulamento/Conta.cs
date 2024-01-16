using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace S5_ConstrutoresThisSobrecargaEncapsulamento
{
    internal class Conta
    {
        private string _titularConta;
        public int NumeroConta { get; private set; }
        public double SaldoConta { get; private set; }

        // Contrutores:
        public Conta(string titular, int numero) 
        {
            _titularConta = titular;
            NumeroConta = numero;
        }

        public Conta(string titular, int numero, double depositoInicial) : this(titular, numero)
        {
            Deposito(depositoInicial);
        }

        // properties:

        public string TitularConta
        {
            get { return _titularConta; }
            set 
            {
                if (value != null && value.Length > 1)
                {
                    _titularConta = value;
                }
            }
        }

        // Métodos:
        public void Deposito(double valor)
        {
            SaldoConta += valor;
        }

        public void Saque(double valor)
        {
            SaldoConta -= (valor + 5.00);
        }

        // Override
        public override string ToString()
        {
            return "Conta " 
                + NumeroConta
                + ", Titular: "
                + _titularConta
                + ", Saldo: $"
                + SaldoConta.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
