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
        }
    }
}
