using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_ClassesAtributosMetodos
{
    internal class Program
    {

        static double Pi = 3.14;

        static void Main(string[] args)
        {

            ProblemaExemplo(); // Linha 47.
            Classe(); // Linha 86.
            ProblemaExemplo2(); // Linha 141.
            MembrosEstaticos(); // Linha 194.
            Versao1(); // Linha 220.
            Circunferencia(3.0); // Linha 236.
            Volume(3.0); // Linha 241.
            Versao2(); // Linha 246.
            Versao3(); // Linha 263.

            // Primeiros exercícios de fixação
            
            Ex1(); // Linha 279.
            Ex2(); // Linha 309.

            // Exercícios de classes, atributos e métodos

            Ex3(); // Linha 334.
            Ex4(); // Linha 365.
            Ex5(); // Linha 409.

            // Exercício de membros estáticos

            Ex6(); // Linha 451.
            
            Console.ReadLine();
        }

        // Resolveremos um problema primeiro sem usar orientação à objetos e logo resolveremos o mesmo problema com a orientação à objetos.
        static void ProblemaExemplo()
        {
            /*
            Fazer um programa para ler as medidas dos lados de dois triângulos X e Y (suponha medidas válidas). 
            Em seguida, mostrar o valor das áreas dos dois triângulos e dizer qual dos dois triângulos possui a maior área.
            */

            double xA, xB, xC, yA, yB, yC;

            Console.WriteLine("Entre com as medidas do triângulo X:");
            xA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            xB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            xC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Entre com as medidas do triângulo Y:");
            yA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            yB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            yC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double p = (xA + xB + xC) / 2.0;
            double areaX = Math.Sqrt(p * (p - xA) * (p - xB) * (p - xC));

            p = (yA + yB + yC) / 2.0;
            double areaY = Math.Sqrt(p * (p - yA) * (p - yB) * (p - yC));

            Console.WriteLine("Área de X = " + areaX.ToString("F4", CultureInfo.InvariantCulture));
            Console.WriteLine("Área de Y = " + areaY.ToString("F4", CultureInfo.InvariantCulture));

            if (areaX > areaY)
            {
                Console.WriteLine("Maior área: X");
            }
            else
            {
                Console.WriteLine("Maior área: Y");
            }
        }

        // Aplicando orientação à objetos para resolver o mesmo problema.
        static void Classe()
        {
            /*
            É um tipo estruturado que pode conter membros:
            - Atributos (dados / Campos)
            - Métodos (funções / operações)

            A classe também pode prover muitos outros recursos, tais como:
            - Construtores
            - Sobrecarga
            - Encapsulamento
            - Herança
            - Polimorfismo

            Exemplos:
            - Entidades: Produto, Cliente, Triângulo
            - Serviçoes: ProdutoService, ClienteService, EmailService, StorageService
            - Controladores: ProdutoController, ClienteController
            - Utilitários: Calculadora, Compactador
            - Outros (views, repositórios, gerenciadores, etc.)

            Por padrão, nomes de classes e atributos devem começar com letra maiúscula.
            */

            Triangulo x, y;
            x = new Triangulo();
            y = new Triangulo();

            Console.WriteLine("Entre com as medidas do triângulo X:");
            x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Entre com as medidas do triângulo Y:");
            y.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double areaX = x.Area();

            double areaY = y.Area();

            Console.WriteLine("Área de X = " + areaX.ToString("F4", CultureInfo.InvariantCulture));
            Console.WriteLine("Área de Y = " + areaY.ToString("F4", CultureInfo.InvariantCulture));

            if (areaX > areaY)
            {
                Console.WriteLine("Maior área: X");
            }
            else
            {
                Console.WriteLine("Maior área: Y");
            }
        }

        static void ProblemaExemplo2()
        {
            /*
            Fazer um programa para ler os dados de um produto em estoque (nome, preço e quantidade no estoque). Em seguida:
            - Mostrar os dados do produto (nome, preço, quantidade no estoque, valor total no estoque).
            - Realizar uma entrada no estoque e mostrar novamente os dados do produto.
            - Realizar uma saída no estoque e mostrar novamente os dados do produto.

            Para resolver o problema devemos criar uma classe conforme abaixo:

                        Produto
            ----------------------------------
            - Nome: string
            - Preco: double
            - Quantidade: int
            ----------------------------------
            + ValorTotalEmEstoque(): double
            + AdicionarProdutos(quantity: int): void
            + RemoverProdutos(quantity: int): void
            */

            Produto p = new Produto();

            Console.WriteLine("Entre os dados do produto:");
            Console.Write("Nome: ");
            p.Nome = Console.ReadLine();

            Console.Write("Preço: ");
            p.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantidade no estoque: ");
            p.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Dados do produto: " + p);

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int qte = int.Parse(Console.ReadLine());
            p.AdicionarProdutos(qte);

            Console.WriteLine();
            Console.WriteLine("Dados atualizados: " + p);

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            qte = int.Parse(Console.ReadLine());
            p.RemoverProdutos(qte);

            Console.WriteLine();
            Console.WriteLine("Dados atualizados: " + p);
        }

        static void MembrosEstaticos()
        {
            /*
            Também são chamados de membros de classe. 
            Em oposição a membros e instância.

            São membros que fazem sentido independentemente de objetos. Não precisam de objeto para serem chamados.
            São chamados a partir do próprio nome da classe.

            Aplicações comuns:
            - Classes utilitárias
            - Declaração de constantes

            Uma classe que possui somente membros estáticos, pode ser uma classe estática também. 
            Esta classe não poderá ser instanciada.

            Problema exemplo:

            Fazer um programa para ler um valor numérico qualquer, 
            e daí mostrar quanto seria o valor de uma circunferência e do volume de uma esfera para um raio daquele valor.
            Informar também o valor de PI com duas casas decimais.

            Faremos em 3 versões diferentes.
            */
        }

        static void Versao1()
        {
            // Versão 1: Métodos na própria classe do programa
            // Nota: Dentro de um método estático você não pode chamar membros de instância da mesma classe.

            Console.Write("Entre o valor do raio: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double circ = Circunferencia(raio);
            double volume = Volume(raio);

            Console.WriteLine("Circunferência: " + circ.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Volume: " + volume.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Valor de PI: " + Pi.ToString("F2", CultureInfo.InvariantCulture));
        }

        static double Circunferencia(double r)
        {
            return 2.0 * Pi * r;
        }

        static double Volume(double r)
        {
            return 4.0 / 3.0 * Pi * Math.Pow(r, 3.0);
        }

        static void Versao2()
        {
            // Versão 2: Classe Calculadora com membros de instância.

            Calculadora calc = new Calculadora();

            Console.Write("Entre o valor do raio: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double circ = calc.Circunferencia(raio);
            double volume = calc.Volume(raio);

            Console.WriteLine("Circunferência: " + circ.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Volume: " + volume.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Valor de PI: " + calc.Pi.ToString("F2", CultureInfo.InvariantCulture));
        }

        static void Versao3()
        {
            // Versão 3: Classe Calculadora com método estático.

            Console.Write("Entre o valor do raio: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double circ = CalculadoraEstatica.Circunferencia(raio);
            double volume = CalculadoraEstatica.Volume(raio);

            Console.WriteLine("Circunferência: " + circ.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Volume: " + volume.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Valor de PI: " + CalculadoraEstatica.Pi.ToString("F2", CultureInfo.InvariantCulture));
        }

        // PDF de primeiros exercícios de fixação.
        static void Ex1()
        {
            // Fazer um programa para ler os dados de duas pessoas, depois mostrar o nome da pessoa mais velha.

            Pessoa p1, p2;
            p1 = new Pessoa();
            p2 = new Pessoa();

            Console.WriteLine("Informe os dados da primeira pessoa:");
            Console.Write("Nome: ");
            p1.nome = Console.ReadLine();
            Console.Write("Idade: ");
            p1.idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe os dados da segunda pessoa:");
            Console.Write("Nome: ");
            p2.nome = Console.ReadLine();
            Console.Write("Idade: ");
            p2.idade = int.Parse(Console.ReadLine());

            if (p1.idade > p2.idade)
            {
                Console.WriteLine("Pessoa mais velha: " + p1.nome);
            }
            else
            {
                Console.WriteLine("Pessoa mais velha: " + p2.nome);
            }
        }

        static void Ex2()
        {
            // Fazer um programa para ler nome e salário de dois funcionários. Depois, mostrar o salário médio dos funcionários.

            Funcionario f1 = new Funcionario(); 
            Funcionario f2 = new Funcionario();

            Console.WriteLine("Informe os dados do primeiro funcionário:");
            Console.Write("Nome: ");
            f1.Nome = Console.ReadLine();
            Console.Write("Salário: ");
            f1.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Informe os dados do segundo funcionário:");
            Console.Write("Nome: ");
            f2.Nome = Console.ReadLine();
            Console.Write("Salário: ");
            f2.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double media = (f1.Salario + f2.Salario) / 2.0;

            Console.WriteLine("Salário médio = " + media.ToString("F2", CultureInfo.InvariantCulture));
        }

        // PDF de exercícios de fixação de classes, atributos e métodos.
        static void Ex3()
        {
            /*
            Fazer um programa para ler os valores da largura e altura de um retângulo. Em seguida, mostrar na tela o valor de sua área, perímetro e diagonal.
            Usar uma classe como mostrado no projeto abaixo:

                        Retangulo
            ----------------------------------
            - Largura: double
            - Altura: double
            ----------------------------------
            + Area(): double
            + Perimetro(): double
            + Diagonal(): double

            */

            Retangulo r = new Retangulo();

            Console.WriteLine("Informe a largura e altura do retângulo: ");
            Console.Write("Largura: ");
            r.Largura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Altura: ");
            r.Altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            Console.WriteLine("Area = " + r.Area().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Perímetro = " + r.Perimetro().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Diagonal = " + r.Diagonal().ToString("F2", CultureInfo.InvariantCulture));
        }

        static void Ex4()
        {
            /*
            Fazer um programa para ler os dados de um funcionário (nome, salário bruto e imposto). 
            Em seguida, mostrar os dados do funcionário (nome e salário líquido).
            Em seguida, aumentar o salário do funcionário com base em uma porcentagem dada (somente o salário bruto é afetado pela porcentagem)
            e mostrar novamente os dados do funcionário. Use a classe projetada abaixo:

                        Funcionario
            ----------------------------------
            - Nome: string
            - Salario: double
            - Imposto: double
            ----------------------------------
            + SalarioLiquido(): double
            + AumentarSalario(porcentagem: double): void

            */

            Funcionario f = new Funcionario();

            Console.WriteLine("Entre com os dados do funcionário");

            Console.Write("Nome: ");
            f.Nome = Console.ReadLine();

            Console.Write("Salário bruto: ");
            f.Salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Valor do imposto: ");
            f.Imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            Console.WriteLine("Funcionário: " + f);

            Console.WriteLine();
            Console.Write("Digite a porcentagem para aumentar o salário: ");
            double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            f.AumentarSalario(porcentagem);

            Console.WriteLine();
            Console.WriteLine("Dados atualizados: " + f);
        }

        static void Ex5()
        {
            /*
            Fazer um programa para ler o nome de um aluno e as três notas que ele obteve nos três trimestres do ano 
            (primeiro trimestre vale 30 e o segundo e terceiro valem 35 cada). Ao final, mostrar qual a nota final do aluno no ano.
            Dizer também se o aluno está aprovado ou reprovado e, 
            em caso negativo, quantos pontos faltam para o aluno obter o mínimo para ser aprovado (que é 60 pontos).
            Você deve criar uma classe Aluno para resolver este problema.
            */

            Aluno a = new Aluno();

            Console.Write("Nome do aluno: ");
            a.Nome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite as três notas do aluno: ");
            a.Nota1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            a.Nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            a.Nota3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine();
            Console.WriteLine("Nota Final = " + a.NotaFinal().ToString("F2", CultureInfo.InvariantCulture));

            // Minha Solução:
            // a.Aprovacao(); 

            // Solução do professor:
            if (a.Aprovacao())
            {
                Console.WriteLine("Aprovado!");
            }
            else
            {
                Console.WriteLine("Reprovado!");
                Console.WriteLine("Faltaram "
                    + a.NotaRestante().ToString("F2", CultureInfo.InvariantCulture)
                    + " Pontos.");
            }
        }

        // Exercício de fixação - Membros estáticos.
        static void Ex6()
        {
            /*
            Faça um programa para ler a cotação do dólar, e depois um valor em dólares a ser comprado por uma pessoa em reais.
            Informar quantos reais a pessoa vai pagar pelos dólares, considerando ainda que a pessoa terá que pagar 6% de IOF sobre o valor em dólar.
            Criar uma classe ConversorDeMoeda para ser responsável pelos cálculos.
            */

            Console.Write("Qual é a cotação do dólar? ");
            ConversorDeMoeda.Cotacao = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quando dólares você vai comprar? ");
            ConversorDeMoeda.QuantidadeDolares = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double total = ConversorDeMoeda.ValorConvertido();

            Console.WriteLine();
            Console.WriteLine("Valor a ser pago em reais = R$" + total.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
