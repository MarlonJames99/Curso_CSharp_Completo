﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_ClassesAtributosMetodos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            ProblemaExemplo(); // Linha .
            Classe(); // Linha .
            ProblemaExemplo2(); // Linha .

            // Primeiros exercícios de fixação
            
            Ex1(); // Linha .
            Ex2(); // Linha .
            Ex3(); // Linha .
            Ex4(); // Linha .
            Ex5(); // Linha .

            */
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
            f1.nome = Console.ReadLine();
            Console.Write("Salário: ");
            f1.salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Informe os dados do segundo funcionário:");
            Console.Write("Nome: ");
            f2.nome = Console.ReadLine();
            Console.Write("Salário: ");
            f2.salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double media = (f1.salario + f2.salario) / 2.0;

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
            - SalarioBruto: double
            - Imposto: double
            ----------------------------------
            + SalarioLiquido(): double
            + AumentarSalario(porcentagem: double): void
            */
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
        }
    }
}