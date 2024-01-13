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
    }
}
