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
            
            Construtores(); // Linha 30.
            Sobrecarga(); // Linha 91.
            This(); // Linha 146. 
            Encapsulamento(); // Linha 158.
            Properties(); // Linha 184.
            AutoProperties(); // Linha 203.
            ModificadoresDeAcesso(); // Linha 222.

            // Exercício de fixação
            
            Ex1(); // Linha 261.

            Console.ReadLine();
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
            p.SetPreco(450.00);

            Console.WriteLine(p.GetNome());
            Console.WriteLine(p.GetPreco());
        }

        static void Properties()
        {
            /*
            São definições de métodos encapsulados, porém expondo uma sintaxe similar à de atributos e não de métodos.

            - Uma propriedade é um membro que oferece um mecanismo flexível para ler, gravar ou calcular o valor de um campo particular.
            As propriedades podem ser usadas como se fossem atributos públicos, mas na verdade elas são métodos especiais chamados "acessadores". 
            Isso permite que os dados sejam acessados facilmente e ainda ajuda a promover a segurança e a flexibilidade dos métodos.
            */

            Produto p = new Produto("TV", 500.00, 10);

            p.Nome = "TV 4K";
            p.Preco = 450.00;

            Console.WriteLine(p.Nome);
            Console.WriteLine(p.Preco);
        }

        static void AutoProperties()
        {
            /*
            Propriedades autoimplementadas:

            É uma forma simplificada de se declarar propriedades que não necessitam lógicas particulares para as operações de get e set.

            EX: public double Preco { get; private set; }
            */

            Produto p = new Produto("TV", 500.00, 10);

            p.AdicionarProdutos(5);
            Console.WriteLine(p.Quantidade);

            p.RemoverProdutos(3);
            Console.WriteLine(p.Quantidade);
        }

        static void ModificadoresDeAcesso()
        {
            /*
            Apenas para ter como referência, já que por enquanto apenas trabalharemos com "public" e "private".

                                                       Modificadores para membros de uma classe:
            ------------------------------------------------------------------------------------------------------------------------------------------------
            |                     | própria classe | subclasses no assembly | classes do assembly | subclasses fora do assembly | classes fora do assembly |
            ------------------------------------------------------------------------------------------------------------------------------------------------
            | public              |        X       |            X           |          X          |              X              |            X             |
            ------------------------------------------------------------------------------------------------------------------------------------------------
            | protected internal  |        X       |            X           |          X          |              X              |                          |
            ------------------------------------------------------------------------------------------------------------------------------------------------
            | internal            |        X       |            X           |          X          |                             |                          |
            ------------------------------------------------------------------------------------------------------------------------------------------------
            | protected           |        X       |            X           |                     |              X              |                          |
            ------------------------------------------------------------------------------------------------------------------------------------------------
            | private protected   |        X       |            X           |                     |                             |                          |
            ------------------------------------------------------------------------------------------------------------------------------------------------
            | private             |        X       |                        |                     |                             |                          |
            ------------------------------------------------------------------------------------------------------------------------------------------------

            Modificadores para Classes:

            - Acesso por qualquer classe 
              - public class Product

            - Acesso somente dentro do assembly
              - internal class product
              - class Product

            - Acesso somente pela classe-mãe
              - private class product
              - nota: classe aninhada, por padrão, é private.
            */
        }

        // Exercício de fixação:

        static void Ex1()
        {
            /*
            Em um banco, para se cadastrar uma conta bancária, é necessário informar o número da conta, o nome do titular da conta,
            e o valor que o titular depositou ao abrir a conta.
            Este valor de depósito inicial, entretanto, é opcional, ou seja: se o titular não tiver dinheiro a depositar no momento de abrir sua conta,
            o depósito inicial não será feito e o saldo inicial da conta será, natualmente, zero.

            Importante: uma vez que uma conta bancária foi aberta, o número da conta nunca poderá ser alterado. 
            Já o nome do titular pode ser alterado (pois uma pessoa pode mudar de nome por ocasião de casamento, por exemplo).

            Por fim, o saldo da conta não pode ser alterado livremente. É preciso haver um mecânismo para proteger isso.
            O saldo só aumenta por meio de depósitos, e só diminui por meio de saques. Para cada saque realizado, o banco cobra uma taxa de $5.00.
            Nota: a conta pode ficar com saldo negativo se o saldo não for suficiente para realizar o saque e/ou pagar a taxa.

            Você deve fazer um programa que realize o cadastro de uma conta, dando opção para que seja ou não informado o valor de depósito inicial.
            Em seguida, realizar um depósito e depois um saque, sempre mostrando os dados da conta após cada operação.

                                Conta
            ----------------------------------------------
            - Numero : Integer
            - Titular : String
            - Saldo : Double
            ----------------------------------------------
            + Deposito(valor : double) : void
            + Saque(valor : double) : void
            ----------------------------------------------
            */

            Conta c;

            Console.Write("Entre com o número da conta: ");
            int numero = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Entre com o titular da conta: ");
            string nome = Console.ReadLine();

            Console.Write("Haverá depósito inicial (s/n)? ");
            string resposta = Console.ReadLine();

            if (resposta == "s" || resposta == "S")
            {
                Console.Write("Entre com o valor de depósito inicial: ");
                double valorInicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                c = new Conta(nome, numero, valorInicial);
            }
            else
            {
                c = new Conta(nome, numero);
            }

            Console.WriteLine();
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(c);

            Console.WriteLine();
            Console.Write("Entre com um valor para depósito: ");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            c.Deposito(valor);

            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(c);

            Console.WriteLine();
            Console.Write("Entre com um valor para saque: ");
            valor = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            c.Saque(valor);

            Console.WriteLine("Dados da conta atualizados:");
            Console.WriteLine(c);
        }
    }
}
