using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5_ConstrutoresThisSobrecargaEncapsulamento
{
    internal class Produto
    {
        private string _nome; // Definido como privado, por isso não poderá ter seu valor modificado em outro arquivo.
        private double _preco; // Por convenção no C#, escrevemos o novo dos atributos com _ e primeira letra minúscula.
        public int Quantidade { get; private set; } // Declarado com autoproperties.

        // O construtor é uma função que deve conter o mesmo nome da classe.

        public Produto() // Sobrecarga com o construtor padrão para que se possa utilizar também o construtor padrão da linguagem.
        {
            Quantidade = 0; // Esta linha é dispensável, pois por padrão os parâmetros numéricos são iniciados com o valor 0.
        }

        public Produto(string nome, double preco) : this() // Aqui o diz aponta para o construtor acima, adicionando seu "Quantidade = 0" neste construtor sem precisar repetir.
        {
            _nome = nome;
            _preco = preco;
        }

        public Produto(string nome, double preco, int quantidade) : this(nome, preco) // Da mesma forma aqui usamos o this para apontar para o outro construtor e reutilizar seu código.
        {
            Quantidade = quantidade;
        }

        // Para utilizar os atributos definidos como "private" em nosso programa principal, precisamos criar os métodos "Get" e "Set".
        public string GetNome()
        {
            return _nome;
        }

        public double GetPreco()
        {
            return _preco;
        }

        public void SetNome(string nome)
        {
            if (nome != null && nome.Length > 1)  // Podemos criar regras para controlar a manipulação dos dados pelo programa principal.
            {
                _nome = nome;
            }
        }

        public void SetPreco(double preco)
        {
            if (preco > 0 ) 
            {
                _preco = preco;
            }
        }

        // O atributo "Quantidade" já foi declarado com o uso de autoproperties, e por isso não precisamos implementar um get e set para ele.

        // Properties:
        public string Nome
        {
            get { return _nome; }
            set 
            {
                if (value != null && value.Length > 1) // Dentro das properties, utilizamos a palavra "value" para nos referirmos ao parâmetro recebido pelo Set.
                {
                    _nome = value;
                }
            }
        }

        public double Preco
        {
            get { return _preco; }
            set 
            {
                if (value > 0)
                {
                    _preco = value;
                }
            }
        }

        // Métodos:
        public double ValorTotalEmEstoque()
        {
            return _preco * Quantidade;
        }

        public void AdicionarProdutos(int quantidade)
        {
            Quantidade += quantidade;
        }

        public void RemoverProdutos(int quantidade)
        {
            Quantidade -= quantidade;
        }

        // ToString customizado:
        public override string ToString()
        {
            return _nome
                + ", $"
                + _preco.ToString("F2", CultureInfo.InvariantCulture)
                + ", "
                + Quantidade
                + " unidades, Total: $"
                + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
