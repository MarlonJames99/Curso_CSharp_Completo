﻿using S11_TratamentoDeExcecoes.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S11_TratamentoDeExcecoes.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account() { }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw (double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("O valor ultrapassa o limite de saque da conta.");
            }

            if (amount > Balance)
            {
                throw new DomainException("Saldo insuficiente.");
            }

            Balance -= amount;
        }
    }
}
