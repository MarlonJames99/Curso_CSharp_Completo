using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security.Cryptography;

namespace S7_TopicosEspeciaisEmCSharpPT1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Var(); // Linha 27.
            SwitchCase(); // Linha 42.
            ExpressaoCondicionalTernaria(); // Linha 127.
            FuncoesInteressantesStrings(); // Linha 164.
            FuncaoDateTime(); // Linha 210.
            FuncaoTimeSpan(); // Linha 274.
            PropriedadesEOperacoesComDateTime(); // Linha 317.
            PropriedadesEOperacoesComTimeSpan(); // Linha 391.
            DateTimeKindEPadraoISO8601(); // Linha 434.
        }

        static void Var()
        {
            // Podemos usar a palavra "var" para inicializar uma variável, e o tipo dela será inferido quando você iniciar a variável.
            // o Var é uma comodidade que facilita muitas tarefas durante o desenvolvimento,
            // porém devemos ter cuidado já que ao não declarar o tipo de uma variável de forma explícita, deixamos um possível brecha para erros.

            var X = 10; // A linguagem infere que esta variável é do tipo "int"
            var Y = 20.0; // Nesta caso ela infere que a variável é do tipo "double"
            var Z = "Maria";

            Console.WriteLine(X);
            Console.WriteLine(Y);
            Console.WriteLine(Z);
        }

        static void SwitchCase()
        {
            // Estrutura opcional a vários if-else encadeados, quando a condição envolve o teste do valor de uma variável.

            /*
            Problema exemplo:

            Criar um programa para receber um valor X e informar o dia da semana baseado neste número.
            */

            Console.Write("Informe o número do dia da semana de 1 a 7: ");
            int x = int.Parse(Console.ReadLine());

            string dia;

            // Solução utilizando if-else.

            if (x == 1)
            {
                dia = "domingo";
            }
            else if (x == 2)
            {
                dia = "Segunda-feira";
            }
            else if (x == 3)
            {
                dia = "Terça-feira";
            }
            else if (x == 4)
            {
                dia = "Quarta-feira";
            }
            else if (x == 5)
            {
                dia = "Quinta-feira";
            }
            else if (x == 6)
            {
                dia = "Sexta-feira";
            }
            else if (x == 7)
            {
                dia = "Sábado";
            }
            else
            {
                dia = "Valor inválido";
            }

            Console.WriteLine("Dia: " + dia);

            // Solução usando switch-case

            switch (x)
            {
                case 1:
                    dia = "Domingo";
                    break;
                case 2:
                    dia = "Segunda-feira";
                    break;
                case 3:
                    dia = "Terça-feira";
                    break;
                case 4:
                    dia = "Quarta-feira";
                    break;
                case 5:
                    dia = "Quinta-feira";
                    break;
                case 6:
                    dia = "Sexta-feira";
                    break;
                case 7:
                    dia = "Sábado";
                    break;
                default:
                    dia = "Valor inválido";
                    break;
            }

            Console.WriteLine("Dia: " + dia);
        }

        static void ExpressaoCondicionalTernaria()
        {
            // Extrutura opcional ao if-else quando se deseja decidir um VALOR com base em uma condição.

            /*
            Sintaxe:
            ( CONDIÇÂO ) ? Valor_Se-True : Valor_Se_False

            Exemplos: 
            ( 2 > 4 ) ? 50 : 80 -> 80
            (10 != 3) ? "Maria" : "Alex" -> Maria
            */

            // Exemplo calculando o valor de desconto com base em uma condição.

            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double desconto;

            // solução com if-else

            if (preco < 20)
            {
                desconto = preco * 0.1;
            }
            else
            {
                desconto = preco * 0.05;
            }

            Console.WriteLine(desconto);

            // Solução com expressão condicional ternária.

            double desc = (preco < 20.0) ? preco * 0.1 : preco * 0.05;
            Console.WriteLine(desc);
        }

        static void FuncoesInteressantesStrings()
        {
            // Funções que podemos utilizar com strings.

            string original = "abcde FGHIJ ABC abc DEFG     ";

            string s1 = original.ToUpper(); // Converte toda a string para maíusculas.
            string s2 = original.ToLower(); // Converte toda a string para minúsculas.
            string s3 = original.Trim(); // Apaga espaços vazios tanto antes quanto depois da string.

            int n1 = original.IndexOf("bc"); // Busca o index de onde inicia a primeira ocorrência do trecho citado dentro da string em questão.
            int n2 = original.LastIndexOf("bc"); // Busca o index de onde inicia a última ocorrência do trecho citado dentro da string em questão.

            string s4 = original.Substring(3); // Recorta a string a partir do index informado, nesse caso, a partir do index 3.
                                               // Também podemos informar o tamanho que queremos que ele recorte.

            string s5 = original.Substring(3, 5); // Recorta a partir do index 3, apenas 5 elementos.

            string s6 = original.Replace('a', 'x'); // Substitui o primeiro elemento pelo segundo, nesse caso, todo caracter 'a' por 'x'.
            string s7 = original.Replace("abc", "xy"); // Mostra que o substituto não precisa necessariamente ter o mesmo tamanho.

            bool b1 = string.IsNullOrEmpty(original); // Testa se o conteúdo é vazio ou nulo.
            bool b2 = string.IsNullOrWhiteSpace(original); // Testa se o conteúdo é nulo ou vários espaços em branco.

            Console.WriteLine("Original: - " + original + "-");
            Console.WriteLine("ToUpper: - " + s1 + "-");
            Console.WriteLine("ToLower: - " + s2 + "-");
            Console.WriteLine("Trim: - " + s3 + "-");
            Console.WriteLine("IndexOf ('bc'): - " + n1 + "-");
            Console.WriteLine("LastIndexOf ('bc'): - " + n2 + "-");
            Console.WriteLine("Substring(3): -" + s4 + "-");
            Console.WriteLine("Substring(3, 5): -" + s5 + "-");
            Console.WriteLine("Replace('a', 'x'): -" + s6 + "-");
            Console.WriteLine("Replace('abc', 'xy'): -" + s7 + "-");
            Console.WriteLine("IsNullOrEmpty: " + b1);
            Console.WriteLine("IsNullOrWhiteSpace: " + b2);

            /*
            Além das mencionadas acima, temos outras que já vimos no decorrer do curso, como:

            - str.Split
            - int x = int.Parse(str)
            - str = x.ToString("F2")
            */
        }

        static void FuncaoDateTime()
        {
            /*
            Representa um instante.
            É um tipo valor (struct).

            Representação Interna
            - Um objeto DateTime internamente armazena:
              * O número de "ticks" (100 nanosegundos) desde a meia noite do dia 1 de janeiro do ano 1 da era comum.
            */

            DateTime d1 = DateTime.Now; // Pega o horário atual do sistema.

            Console.WriteLine(d1);
            Console.WriteLine(d1.Ticks); // Quantidade de ticks que passaram até o momento atual.

            /*
            Instanciação

            Construtores:
            - DateTime(ano, mes, dia)
            - DateTime(ano, mes, dia, hora, minuto, segundo)
            - DateTime(ano, mes, dia, hora, minuto, segundo, milissegundo)


            Builders:
            - DateTime.Now
            - DateTime.UtcNow
            - DateTime.Today
            - DateTime.Parse(string)
            - DateTime.ParseExact(string, string)
            */

            DateTime d2 = new DateTime(2018, 11, 25); // Instanciamos um DateTime do dia 25/11/2018 às 00:00.
            DateTime d3 = new DateTime(2018, 11, 25, 20, 45, 03); // Instanciamos um DateTime do dia 25/11/2018 às 20:45:03.
            DateTime d4 = new DateTime(2018, 11, 25, 20, 45, 03, 500); // Instanciamos um DateTime do dia 25/11/2018 às 20:45:03 (os milissegundos não são mostrados na formatação padrão).

            DateTime d5 = DateTime.Now; // Horário atual do sistema.
            DateTime d6 = DateTime.Today; // Data de hoje às 00:00.
            DateTime d7 = DateTime.UtcNow; // Igual ao .Now porém pegando o horário padrão GMT (de Greenwich).

            DateTime d8 = DateTime.Parse("2000-08-15"); // Converte uma string para data.
            DateTime d9 = DateTime.Parse("2000-08-15 13:05:58"); // Converte uma string para data.

            DateTime d10 = DateTime.Parse("15-08-2000"); // No formato do Brasil.
            DateTime d11 = DateTime.Parse("15-08-2000 13:05:58"); // No formato do Brasil.

            DateTime d12 = DateTime.ParseExact("2000-08-15", "yyyy-mm-dd", CultureInfo.InvariantCulture); // Este nos permite escolher qual formato exatamente nós queremos utilizar.
            DateTime d13 = DateTime.ParseExact("15/08/2000 13:05:58", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture); // Testando em outro formato.

            Console.WriteLine(d2);
            Console.WriteLine(d3);
            Console.WriteLine(d4);
            Console.WriteLine(d5);
            Console.WriteLine(d6);
            Console.WriteLine(d7);
            Console.WriteLine(d8);
            Console.WriteLine(d9);
            Console.WriteLine(d10);
            Console.WriteLine(d11);
            Console.WriteLine(d12);
            Console.WriteLine(d13);
        }

        static void FuncaoTimeSpan()
        {
            /*
            TimeSpan representa uma duração, ou seja, o intervalo entre dois instantes.
            É um tipo valor (scruct)

            Representação Interna:

            - Um objeto TimeSpan internamente armazena uma duração na forma de ticks (100 nanosegundos).

            TimeSpan t1 = new TimeSpan(0, 1, 30); (hora, minuto, segundo)
            Console.WriteLine(t1);
            Console.WriteLine(t1.Ticks);
            */

            TimeSpan t1 = new TimeSpan(); // Construtor vazio (padrão) 
            TimeSpan t2 = new TimeSpan(900000000L); // Construtor indicando uma quantidade de ticks.
            TimeSpan t3 = new TimeSpan(2, 11, 30); // Construtor passando hora, minuto e segundo.
            TimeSpan t4 = new TimeSpan(1, 2, 11, 21); // Passando dia, horas, minutos e segundos.
            TimeSpan t5 = new TimeSpan(1, 2, 11, 21, 321); // Passando também os milissegundos.

            TimeSpan t6 = TimeSpan.FromDays(1.5); // Instancia um TimeSpan equivalente a 1.5 dias.
            TimeSpan t7 = TimeSpan.FromHours(1.5); // Neste caso utilizamos a unidade "horas".
            TimeSpan t8 = TimeSpan.FromMinutes(1.5); // Aqui usando a unidade "minutos".
            TimeSpan t9 = TimeSpan.FromSeconds(1.5); // Segundos.
            TimeSpan t10 = TimeSpan.FromMilliseconds(1.5); // Milissegundos.
            TimeSpan t11 = TimeSpan.FromTicks(900000000L); // Ticks.

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3);
            Console.WriteLine(t3.Ticks);
            Console.WriteLine(t4);
            Console.WriteLine(t5);

            Console.WriteLine(t6);
            Console.WriteLine(t7);
            Console.WriteLine(t8);
            Console.WriteLine(t9);
            Console.WriteLine(t10);
            Console.WriteLine(t11);
        }

        static void PropriedadesEOperacoesComDateTime()
        {
            /*
            Propriedades:

            - Date (DateTime)
            - Day (int)
            - DayOfWeek (DayOfWeek)
            - DayOfYear (int)
            - Hour (int)
            - Kind (DateTimeKind)
            - Millisecond (int)
            - Minute (int)
            - Month (int) 
            - Second (int)
            - Ticks (long)
            - TimeOfDay (TimeSpan)
            - Year (int)
            */

            DateTime d1 = new DateTime(2001, 8, 15, 13, 45, 58, 275);

            Console.WriteLine(d1);
            Console.WriteLine("1) Date: " + d1.Date); // Traz somente a data, zerando o horário.
            Console.WriteLine("2) Day: " + d1.Day); // Traz somente o dia.
            Console.WriteLine("3) DayOfWeek: " + d1.DayOfWeek);
            Console.WriteLine("4) DayOfYear: " + d1.DayOfYear);
            Console.WriteLine("5) Hour: " + d1.Hour);
            Console.WriteLine("6) Kind: " + d1.Kind); // Local ou universal, por padrão é local, porém ele nos retorna como não específicado.
            Console.WriteLine("7) Millisecond: " + d1.Millisecond);
            Console.WriteLine("8) Minute: " + d1.Minute);
            Console.WriteLine("9) Month: " + d1.Month);
            Console.WriteLine("10) Second: " + d1.Second);
            Console.WriteLine("11) Ticks: " + d1.Ticks);
            Console.WriteLine("12) TimeOfDay: " + d1.TimeOfDay);
            Console.WriteLine("13) Year: " + d1.Year);

            // Formatação

            DateTime d2 = new DateTime(2001, 8, 15, 13, 45, 58);

            string s1 = d2.ToLongDateString(); // Formata a data para uma forma mais longa (Pega o padrão do computador), converte também para o tipo string.
            string s2 = d2.ToLongTimeString();
            string s3 = d2.ToShortDateString(); // Formata em forma resumida.
            string s4 = d2.ToShortTimeString();

            string s5 = d2.ToString();

            string s6 = d2.ToString("yyyy-MM-dd HH:mm:ss");
            string s7 = d2.ToString("yyyy-MM-dd HH:mm:ss.fff");

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);
            Console.WriteLine(s6);
            Console.WriteLine(s7);

            // Operações com DateTime

            DateTime d3 = d1.AddHours(2); // Acrescenta 2 horas na data original.
            DateTime d4 = d1.AddMinutes(3);

            Console.WriteLine(d1);
            Console.WriteLine(d3);
            Console.WriteLine(d4);

            DateTime d5 = new DateTime(2000, 10, 15);

            TimeSpan t = d5.Subtract(d1); // Calcula a diferença entre as datas "d1" e "d5".
            Console.WriteLine(t);
        }

        static void PropriedadesEOperacoesComTimeSpan()
        {
            // Propriedades:

            TimeSpan t1 = TimeSpan.MaxValue; // Pega a duração máxima possível de ser armazenada em um TimeSpan.
            TimeSpan t2 = TimeSpan.MinValue;
            TimeSpan t3 = TimeSpan.Zero;

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3);

            TimeSpan T = new TimeSpan(2, 3, 5, 7, 11);

            Console.WriteLine(T);

            Console.WriteLine("Days: " + T.Days); // Mostra a quantidade de dias nesse TimeSpan.
            Console.WriteLine("Hours: " + T.Hours);
            Console.WriteLine("Minutes: " + T.Minutes);
            Console.WriteLine("Milliseconds: " + T.Milliseconds);
            Console.WriteLine("Seconds: " + T.Seconds);
            Console.WriteLine("Ticks: " + T.Ticks);

            Console.WriteLine("TotalDays: " + T.TotalDays);
            Console.WriteLine("TotalHours: " + T.TotalHours);
            Console.WriteLine("TotalMinutes: " + T.TotalMinutes);
            Console.WriteLine("TotalSeconds: " + T.TotalSeconds);
            Console.WriteLine("TotalMilliseconds: " + T.TotalMilliseconds);

            // Operações:

            TimeSpan T2 = new TimeSpan(1, 30, 10);
            TimeSpan T3 = new TimeSpan(0, 30, 5);

            TimeSpan sum = T2.Add(T3);
            TimeSpan dif = T2.Subtract(T3);
            // TimeSpan mult = T2.Multiply(2.0); // Por alguma razão o C# não está encontrando a operação "Multiply".
            // TimeSpan div = T2.Divide(2.0); // Por alguma razão o C# não está encontrando a operação "Divide".

            Console.WriteLine(sum);
            Console.WriteLine(dif);
        }

        static void DateTimeKindEPadraoISO8601()
        {
            /*
            DateTimeKind

            Tipo enumerado especial que define três valores possíveis para a localidade da data:

            - Local (Fuso horário do sistema)
            - Utc (Fuso horário GTM [Greenwich Mean Time])
            - Unspecified

            Boa Prática:
            - Armazenar em formato UTC
            - Instanciar e mostrar em formato local

            Para converter um DateTime para Local ou UTC, você deve usar:
            - myDate.ToLocalTime()
            - myDate.ToUniversalTime()
            */

            DateTime d1 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Local);
            DateTime d2 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Utc);
            DateTime d3 = new DateTime(2000, 8, 15, 13, 5, 58);

            Console.WriteLine("d1: " + d1);
            Console.WriteLine("d1 Kind: " + d1.Kind);
            Console.WriteLine("d1 to Local: " + d1.ToLocalTime());
            Console.WriteLine("d1 to Universal: " + d1.ToUniversalTime());
            Console.WriteLine();

            Console.WriteLine("d2: " + d2);
            Console.WriteLine("d2 Kind: " + d2.Kind);
            Console.WriteLine("d2 to Local: " + d2.ToLocalTime());
            Console.WriteLine("d2 to Universal: " + d2.ToUniversalTime());
            Console.WriteLine();

            Console.WriteLine("d3: " + d3);
            Console.WriteLine("d3 Kind: " + d3.Kind);
            Console.WriteLine("d3 to Local: " + d3.ToLocalTime()); // Como o C# não sabe o kind neste caso, ele irá subtrair 3 horas para trazer à horário local.
            Console.WriteLine("d3 to Universal: " + d3.ToUniversalTime()); // Como o C# não sabe o kind neste caso, ele irá somar 3 horas para trazer à horário UTC.

            // Padrão ISO 8601

            /*
            Formato:
            - yyyy-MM-ddThh:mm:ssZ
            O "Z" no final indica que essa data está armazenada em formato String no padrão UTC.
            */

            DateTime d4 = DateTime.Parse("2000-08-15 13:05:58");
            DateTime d5 = DateTime.Parse("2000-08-15T13:05:58Z");

            Console.WriteLine("d4: " + d4);
            Console.WriteLine("d4 Kind: " + d4.Kind);
            Console.WriteLine("d4 to Local: " + d4.ToLocalTime());
            Console.WriteLine("d4 to Universal: " + d4.ToUniversalTime());
            Console.WriteLine();

            Console.WriteLine("d5: " + d5);
            Console.WriteLine("d5 Kind: " + d5.Kind);
            Console.WriteLine("d5 to Local: " + d5.ToLocalTime());
            Console.WriteLine("d5 to Universal: " + d5.ToUniversalTime());
            Console.WriteLine();

            Console.WriteLine(d5.ToString("yyyy-MM-ddTHH:mm:ssZ")); // Cuidado!, isto pode gerar problemas. 
            Console.WriteLine(d5.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")); // O ideal é primeiro garantir que ela está em formato universal, e depois fazer o "ToString".
        }
    }
}
