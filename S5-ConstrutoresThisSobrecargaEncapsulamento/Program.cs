using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace S5_ConstrutoresThisSobrecargaEncapsulamento
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Construtores(); // Linha .
            Sobrecarga(); // Linha .
            This(); // Linha . 
            Encapsulamento(); // Linha .
        }

        static void Construtores()
        {
            /*
            É uma operação especial da classe, que executa no momento da instanciação do objeto.

            Usos comuns:
            - Iniciar valores dos atributos.
            - Permitir ou obrigar que o objeto receba dados/dependências no momento de sua instanciação (injeção de dependência).

            Se um construtor customizado não for especificado, a classe disponibiliza o construtor padrão:
            -> produto p = new produto();

            É possível especificar mais de um construtor na mesma classe (sobrecarga).
            */

            /*
            Aplicação exemplo

            Proposta de melhoria:

            Quando executamos o comando de instanciação padrão, instanciamos um produto "p" com seus atributos "vazios":

            Produto p = new Produto(); -> Nome = null, Preco = 0.0, Quantidade = 0.

            Entretanto, faz sentido um produto que não tem nome? Faz sentido um produto que não tem preço?

            Com o intuito de evitar a existência de produtos sem nome e preço, é possível fazer com que seja "obrigatória" a iniciação desses valores?
            */

            Console.WriteLine("Entre os dados do produto:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantidade no estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto p = new Produto(nome, preco, quantidade); // A instanciação é feita após receber os dados do usuário, assim já obtendo os dados como parâmetros no construtor.

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

        static void Sobrecarga()
        {

            // É um recurso que uma classe possui de oferecer mais de uma operação com o mesmo nome, porém com diferentes listas de parâmetros.

            /*
            Proposta de melhoria:

            Vamos criar um construtor opcional, o qual recebe apenas nome e preço do produto.
            A quantidade em estoque deste novo produto, por padrão, deverá então ser iniciada com o valor zero.

            Nota: É possível também incluir um construtor padrão (sem parâmetros).
            */

            Console.WriteLine("Entre os dados do produto:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Produto p = new Produto(nome, preco); // Aqui utilizamos o construtor que possui 2 argumentos, mas o que possui 3 segue funcional.

            Produto P2 = new Produto(); // O Construtor padrão segue funcional.

            Produto P3 = new Produto() // Sintaxe alternativa do C# que nos permite declarar os valores diretamente na instanciação.
            {   // É funcional mesmo que não tenhamos criado nenhum construtor personalizado na classe. Porém é necessário ter o construtor padrão utilizável na classe em questão.
                /*
                Nome = "TV",
                Preco = 500.00,
                Quantidade = 20
                */
            };  // Deixei comentado pois definimos os atributos nome, preco e quantidade como "private" na classe "Produto", por isso não funcionaria.

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

        static void This()
        {
            /*
            A palavra This é uma referência para o próprio objeto.

            Usos comuns:
            - Diferenciar atributos de variáveis locais -> Não é comum no C# pois por padrão iniciamos atributos com letra Maiúsculas e variáveis locais com minúsculas.
            - Referenciar outro construtor em um construtor -> Exemplificado na classe "Produto.cs"
            - Passar o próprio objeto como argumento na chamada de um método ou construtor -> Veremos seu uso na prática mais adiante no curso.
            */
        }

        static void Encapsulamento()
        {
            /*
            É um princípio que consiste em esconder detalhes de implementação de um componente, 
            expondo apenas operações seguras e que o mantenha em um estado consistente.

            Regra de ouro: o objeto deve sempre estar em um estado consistente, e a própria classe deve garantir isso.

            Opção 1: Implementação manual

            Todo atributo é definido como private.

            Implementa-se métodos Get e Set para cada atributo, conforme regras de negócio.

            Nota: não é usual na plataforma C#.
            */

            Produto p = new Produto("TV", 500.00, 10);

            p.SetNome("TV 4K");

            Console.WriteLine(p.GetNome());
            Console.WriteLine(p.GetPreco());
            Console.WriteLine(p.GetQuantidade());
        }
    }
}
