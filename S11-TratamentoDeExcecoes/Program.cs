using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using S11_TratamentoDeExcecoes.Entities;
using S11_TratamentoDeExcecoes.Entities.Exceptions;

namespace S11_TratamentoDeExcecoes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Excecoes(); // Linha .
            EstruturaTryCatch(); // Linha .
            BlocoFinally(); // Linha .
        }

        static void Excecoes()
        {
            /*
            Uma exceção é qualquer condição de erro ou comportamento inesperado encontrado por um programa em execução.

            No .NET, uma exceção é um objeto herdado da classe System.Exception

            Quando lançada, uma exceção é propagada na pilha de chamadas de métodos em execução, até que seja capturada (tratada) ou o programa seja encerrado.

            A classe Exception possui 2 sub-classes principais, "SystemException" e "ApplicationException".

            SystemException são as exceções padrão da linguagem C#/.NET
            ApplicationException são exceções específicas da sua aplicação, que você mesmo cria.

            Por que exceções?

            O modelo de tratamento de exceção permite que erros sejam tratados de forma consistente e flexível, usando boas práticas.

            Vantagens:
            - Delega a lógica do erro para a classe/método responsável por conhecer as regras que podem ocasionar o erro.
            - Trata de forma organizada (inclusive hierárquica) exceções de tipos diferentes.
            - A exceção pode carregar dados quaisquer.
            */
        }

        static void EstruturaTryCatch()
        {
            /*
            - Bloco Try
              - Contém o código que representa a execução normal do trecho de código que pode acarretar em uma exceção.

            - Bloco Catch
              - Contém o código a ser executado caso um exceção ocorra.
              - Deve ser expecificado o tipo de exceção a ser tratada (upcasting é permitido).
            */

            try { 
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            int result = n1 / n2;
            Console.WriteLine(result);
            }
            catch(DivideByZeroException) {
                Console.WriteLine("Não é permitido a divisão por zero.");
            }
            catch(FormatException e)
            {
                Console.WriteLine("Erro no formato! " + e.Message);
            }
        }

        static void BlocoFinally()
        {
            /*
            - É um bloco que contém código a ser executado independentemente de ter ocorrido ou não uma exceção.

            - Exemplo clássico: Fechar um arquivo ou conexão de banco de dados ao final do processamento.
            */

            FileStream fs = null;
            try
            {
                fs = new FileStream(@"C:\temp\data.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado!");
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        static void ExcecoesPersonalizadas()
        {
            /*
            Fazer um programa para ler os dados de uma reserva de hotel (n° do quarto, data de entrada e data de saída) e mostrar os dados da reserva, inclusive sua duração em dias.
            Em seguida, ler novas datas de entrada e saída, atualizar a reserva, e mostrar novamente a reserva com os dados atualizados. 
            O programa não deve aceitar dados inválidos para a reserva, conforme as seguintes regras:

            - Alterações de reserva só podem ocorrer para datas futuras.
            - A data de saída deve ser maior que a data de entrada.
            */

            try 
            {
                Console.Write("Número do quarto: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Data do check-in (dd/MM/aaaa): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());

                Console.Write("Data do check-out (dd/MM/aaaa): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine("Reserva: " + reservation);

                Console.WriteLine();
                Console.WriteLine("Entre com os dados para atualização da reserva:");

                Console.Write("Data do check-in (dd/MM/aaaa): ");
                checkIn = DateTime.Parse(Console.ReadLine());

                Console.Write("Data do check-out (dd/MM/aaaa): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                reservation.UpdateDates(checkIn, checkOut);
                Console.WriteLine("Reserva: " + reservation);
            }
            catch(DomainException e)
            {
                Console.WriteLine("Erro na reserva: " + e.Message);
            }
        }
    }
}
