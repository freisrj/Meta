using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Teste.Fernando._03.Areas.Brackets
{

    /// 
    /// <summary>
    /// @author matheusCosta
    /// 
    /// </summary>
    public class BalancedBrackts
    {

        public static void Main(string[] args)
        {
            string resultado = String.Empty;

            Console.WriteLine("Para String \"(){()}{}\" = " + balanced("(){()}{}"));
            Console.WriteLine("Para String \"{()\" = " + balanced("{()"));
            Console.WriteLine("Para String \"A(8/){[0-9]/A-Z}\" = " + balanced("A(8/){[0-9]/A-Z}"));
            Console.WriteLine("Para String \"(){)}{}\" = " + balanced("(){)}{}"));
            Console.ReadLine();

        }

        /// <summary>
        /// Metodo que verifica se a expressao esta dentro do pradrao.
        /// Ao receber a String, cria um array de String cada caracter sera um indice.
        /// Percorre todo o array e mapea as aberturas do padrao.
        /// Se o caracter for um dos fechametos do padrao, valida se ele fecha a ultima abetura.
        /// Se nao fecha retorna um false, no final do processo verifica e retorna se a lista de aberturas esta vazia. </summary>
        /// <param name="expression">
        /// @return </param>
        private static bool balanced(string expression)
        {
            Stack<string> stack = new Stack<string>();

            string[] splitExpression = new string[expression.Length];

            for (int i = 0; i < splitExpression.Length; i++)
            {
                splitExpression[i] = expression[i].ToString();    
            }

            if (String.IsNullOrEmpty(expression))
            {
                return false;
            }

            for (int i = 0; i < splitExpression.Length; i++)
            {
                string caracter = splitExpression[i];
                if (caracter.Equals("(") || caracter.Equals("{") || caracter.Equals("["))
                {
                    stack.Push(caracter);
                    continue;
                }

                string lastCaracter = null;
                switch (caracter)
                {
                    case ")":
                        lastCaracter = (stack.Count > 0 ? stack.Pop() : null);
                        if (String.IsNullOrEmpty(lastCaracter) || lastCaracter.Equals("{") || lastCaracter.Equals("["))
                        {
                            return false;
                        }
                        break;

                    case "}":
                        lastCaracter = (stack.Count > 0 ? stack.Pop() : null);
                        if (String.IsNullOrEmpty(lastCaracter) || lastCaracter.Equals("(") || lastCaracter.Equals("["))
                        {
                            return false;
                        }
                        break;

                    case "]":
                        lastCaracter = (stack.Count > 0 ? stack.Pop() : null);
                        if (String.IsNullOrEmpty(lastCaracter) || lastCaracter.Equals("{") || lastCaracter.Equals("("))
                        {
                            return false;
                        }
                        break;
                    default :
                        return true;
                }
            }

            return stack.Count == 0;
        }
    }
}