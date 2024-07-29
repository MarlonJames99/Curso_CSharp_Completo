using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S10_HerancaEPolimorfismo.Entities;

namespace S10_HerancaEPolimorfismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Heranca(); // Linha .
            UpcastingEDowncasting(); // Linha .
            Sobreposicao(); // Linha .
            ClasseEMetodosSelados(); // Linha .
            Polimorfismo(); // Linha .

            Console.ReadLine();
        }

        static void Heranca()
        {
            /*
            - É um tipo de associação que permite que uma classe herde dados e comportamentos de outra.

            Definições importantes:
              - Relação "é-um"
              - Generalização/especialização
              - Superclasse (classe base) / subclasse (classe derivada)
              - Herança / extensão
              - Herança é uma associação entre classes (e não entre objetos)

            Vantagens: 
              - Reuso
              - Polimorfismo

            Sintaxe:
              - : (estende)
              - base (referência para a superclasse)
            */

            /*
            Exemplo:
            
            Suponha um negócio de banco que possui uma conta comum e uma conta para empresas, sendo que a conta para empresas possui todos os membros da conta comum,
            mais um limite de empréstimo e uma operação de realizar empréstimo.
            */

            BusinessAccount account = new BusinessAccount(8010, "Marlon James", 100.0, 500);

            Console.WriteLine(account.Balance);
        }

        static void UpcastingEDowncasting()
        {
            /*
            Upcasting:
              - Casting da subclasse para a superclasse
              - uso comum: Polimorfismo

            Downcasting:
              - Casting da superclasse para a subclasse
              - Palavra as
              - Palavra is
              - Uso comum: Métodos que recebem parâmetros genéricos (ex: Equals)
            */

            Account acc = new Account(1001, "Alex", 0);
            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

            // UPCASTING

            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0);
            Account acc3 = new SavingsAccount(1004, "Ana", 0.0, 0.01);

            // DOWNCASTING

            BusinessAccount acc4 = (BusinessAccount)acc2;
            acc4.Loan(100.0);

            // BusinessAccount acc5 = (BusinessAccount)acc3; // Aqui, apesar do compilador não detectar um erro,
                                                          // ao executar o código, dará um erro por estar convertendo um conteúdo do tipo "Savings Account" para "Business Account".

            // Testando previamente se o conteúdo é ou não do tipo que você deseja:

            if(acc3 is BusinessAccount)
            {
                BusinessAccount acc5 = (BusinessAccount)acc3;
                acc5.Loan(200.0);
                Console.WriteLine("Loan!");
            }

            if(acc3 is SavingsAccount)
            {
                SavingsAccount acc5 = acc3 as SavingsAccount; // Sintaxe alternativa de fazer o Downcasting, usando "as".
                acc5.UpdateBalance();
                Console.WriteLine("Update!");
            }
        }

        static void Sobreposicao()
        {
            /*
            É a implementação de um método de uma superclasse na subclasse

            Para que um método comum (não abstrato) possa ser sobreposto, deve ser incluído nele o prefixo "virtual"

            Ao sobrescrever um método, devemos incluir nele o prefixo "Override".

            Palavra "base"

            É possível chamar a implementação da superclase usando a palavra base.

            Exemplo:

            Suponha as seguintes regras para saque:
              - Conta comum: é cobrada uma taxa no valor de 5.00
              - Conta poupança: realizar o saque normalmente da superclasse (Account), e depois descontar mais 7.0.

            Como resolver isso?

            Resposta: Sobrescrevendo o método withdraw na subclasse SavingsAccount.
            */

            Account acc1 = new Account(1001, "Alex", 500.0);
            Account acc2 = new SavingsAccount(1002, "Maria", 500.0, 0.01);

            acc1.Withdraw(10.0);
            acc2.Withdraw(10.0);

            Console.WriteLine(acc1.Balance);
            Console.WriteLine(acc2.Balance);
        }

        static void ClasseEMetodosSelados()
        {
            /*
            Classes e Métodos selados

            Palavra chave: sealed

            - Classe: Evita que a classe seja herdada
              - Nota: Ainda é possível extender a funcionalidade de uma classe selada usando "extension methods".

            - Método: Evita que um método sobreposto possa ser sobreposto novamente
              - Só pode ser aplicado a métodos sobrepostos.

            Aplicados na classe "SavingsAccount" selando tanto a classe para não poder ser herdada, 
            como selando o método já sobreposto "Withdraw" para não ter como ser novamente sobreposto.

            Pra quê?

            - Segurança: dependendo das regras do negócio, as vezes é desejável garantir que uma classe não seja herdada, ou que um método não seja sobreposto.
              - Geralmente convém selar métodos sobrepostos, pois sobreposições múltiplas podem ser uma porta de entrada para incosistências.

            - Performance: atributos de tipo de uma classe selada são analisados de forma mais rápida em tempo de execução.
              - Exemplo clássico: string
            */
        }

        static void Polimorfismo()
        {
            /*
            Em programação Orientada à objetos, polimorfismo é um recurso que permite que variáveis de um mesmo tipo mais genérico,
            possam apontar para objetos de tipos específicos diferentes, tendo assim comportamentos diferentes conforme cada tipo específico.

            Importante entender:

            - A associação do tipo específico com o tipo genérico é feita em tempo de execução (upcasting).

            - O compilador não sabe para qual tipo específico a chamada do método Withdraw está sendo feita (ele só sabe que são duas variáveis tipo Account).
            */

            Account acc1 = new Account(1001, "Alex", 500.0);
            Account acc2 = new SavingsAccount(1002, "Anna", 500.0, 0.01);

            acc1.Withdraw(10.0);
            acc2.Withdraw(10.0);

            Console.WriteLine(acc1.Balance);
            Console.WriteLine(acc2.Balance);
        }
    }
}
