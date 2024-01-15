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
        private int _quantidade; 

        // O construtor é uma função que deve conter o mesmo nome da classe.

        public Produto() // Sobrecarga com o construtor padrão para que se possa utilizar também o construtor padrão da linguagem.
        {
            _quantidade = 0; // Esta linha é dispensável, pois por padrão os parâmetros numéricos são iniciados com o valor 0.
        }

        public Produto(string nome, double preco) : this() // Aqui o diz aponta para o construtor acima, adicionando seu "Quantidade = 0" neste construtor sem precisar repetir.
        {
            _nome = nome;
            _preco = preco;
        }

        public Produto(string nome, double preco, int quantidade) : this(nome, preco) // Da mesma forma aqui usamos o this para apontar para o outro construtor e reutilizar seu código.
        {
            _quantidade = quantidade;
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

        public int GetQuantidade()
        {
            return _quantidade;
        }

        public void SetNome(string nome)
        {
            if (nome != null && nome.Length > 1) // Podemos criar regras para controlar a manipulação dos dados.
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

        // O atributo quantidade só poderá ser modificado pelos métodos AdicionarProdutos e RemoverProdutos, por isso não definiremos um Set para ele.

        public double ValorTotalEmEstoque()
        {
            return _preco * _quantidade;
        }

        public void AdicionarProdutos(int quantidade)
        {
            _quantidade += quantidade;
        }

        public void RemoverProdutos(int quantidade)
        {
            _quantidade -= quantidade;
        }

        public override string ToString()
        {
            return _nome
                + ", $"
                + _preco.ToString("F2", CultureInfo.InvariantCulture)
                + ", "
                + _quantidade
                + " unidades, Total: $"
                + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
