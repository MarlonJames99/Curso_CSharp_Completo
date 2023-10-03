using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharpCompleto
{
    internal class TiposDeDados
    {
        static void Main(string[] args)
        {
            // Tipos de dados do C# - Não são todos, mas são os maios usados.

            sbyte x = 100; //Também pode ser SByte por ser a escrita usada no .Net Framework, incluido no "System". -128 a 127.
            byte n1 = 126; // não aceita número negativo. 0 a 255.
            int n2 = 1000;
            int n3 = 2147483647; // Valor máximo aceito no tipo int.
            long n4 = 2147483648L; // Permite números ainda maiores que o int, é recomendado colocar o L no final pra indicar que é do tipo long.
            bool completo = false;
            char genero = 'f'; // character deve ser colocado entre aspas simples.
            char letra = '\u0041'; // Usando código unicode podemos representar qualquer caracter existente.
            float n5 = 4.5f; // Float deve ter a letra f no final do número.
            double n6 = 4.6;
            string nome = "Maria"; // String requer uso de aspas duplas.
            object obj1 = "MJRC"; // Tipo genérico.

            // Podemos pegar o menor e o maior valor de um tipo de dado usando as propriedades MinValue e MaxValue.

            int n7 = int.MinValue;
            int n8 = int.MaxValue;
            sbyte n9 = sbyte.MinValue;
            decimal n10 = decimal.MaxValue;
        }
    }
}
