using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3
{
    class ReversePolishNotation
    {
        public Queue<string> RemainingChain { get; }

        /*public static string[] ParseToRPN(string[] arg)
        {
            string[] elements = new string[0];
            string str = String.Join("", arg);

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '^':
                    case '(':
                    case ')':
                        if (IsNumber)
                        {
                            int m1 = elements.Length;
                            Array.Resize(ref elements, m1 + 2);
                            elements[m1] = str.Substring(pos, j - pos);
                            elements[m1 + 1] = str[i].ToString();
                            pos = i + 1;
                            IsNumber = false;
                        }
                        else
                        {
                            int m2 = elements.Length;
                            Array.Resize(ref elements, m2 + 1);
                            elements[m2] = str[i].ToString();

                        }
                        break;

                    default:
                        if (i == str.Length - 1)
                        {
                            int m2 = elements.Length;
                            Array.Resize(ref elements, m2 + 1);
                            elements[m2] = str.Substring(pos, i - pos + 1);
                        }
                        else
                        {
                            if (!IsNumber)
                            {
                                IsNumber = true;
                                pos = i;
                            }
                        }
                        break;
                }
            }

            return elements;
        }*/

        public ReversePolishNotation(string[] arg)
        {
            string str = String.Join("", arg);
            Stack<string> stack = new Stack<string>();
            Queue<string> output = new Queue<string>();

            for (int i = 0; i < str.Length; i++)
            {
                string temp = "";
                //проверка на отрицательность значения(если перед знаком нет числа или он в начале строки)
                if (str[i] == '-' && ((i > 0 && !Char.IsDigit(str[i - 1])) || i == 0))
                {
                    i++;
                    temp += "-";   //в переменную для чисел добавляется знак "-"
                }
                //если найдено число то оно добавляет оставшиеся цифры в темп и потом добавляет темп
                if (Char.IsDigit(str[i]))
                {
                    while (i < str.Length && (Char.IsDigit(str[i]) || str[i] == '.'))
                        temp += str[i++].ToString();
                    i--;
                    output.Enqueue(temp);
                }
                //при записывание + или - переводим все операции из стека в выходную строку
                if (str[i] == '+' || str[i] == '-')
                {
                    check:
                    if (stack.Count != 0)
                    {
                        if (stack.Peek() == "(")
                            stack.Push(str[i].ToString());
                        else
                        {
                            output.Enqueue(stack.Pop());
                            goto check;        //возврат на проверку находится ли на вершине стека еще какая либо операция
                        }
                    }

                    else
                        stack.Push(str[i].ToString());
                }
                
                if (str[i] == '*' || str[i] == '/')
                {
                    if (stack.Count != 0)
                    {
                        if (stack.Peek() != "*" && stack.Peek() != "/")
                            stack.Push(str[i].ToString());
                        // если в стеке находиться * или / то она заменяется так как приоритеты операций одинаковые
                        else
                        {
                            output.Enqueue(stack.Pop());
                            stack.Push(str[i].ToString());
                        }
                    }
                    else 
                        stack.Push(str[i].ToString());
                }
                // добавляем в стек скобку
                if (str[i] == '(')
                    stack.Push(str[i].ToString());
                // выносим из стека все до открывающей скобки и удаляем её
                if (str[i] == ')')
                    while (stack.Peek() != "(")
                    {
                        output.Enqueue(stack.Pop());
                        if (stack.Peek() == "(")
                        {
                            stack.Pop();
                            break;
                        }
                    }
                // так как приоритетность операций у вознесений в степень найбольшая, то банально добавляем в стек
                if (str[i] == '^')
                    stack.Push(str[i].ToString());
            }

            while (stack.Count != 0)
                output.Enqueue(stack.Pop());

            RemainingChain = output;
        }
        public double Solution()
        {
            Stack<double> stack = new Stack<double>();
            while (!RemainingChain.IsEmpty)
            {
                switch (RemainingChain.First())
                {
                    case "+":
                        RemainingChain.Dequeue();
                        double element2 = stack.Pop();
                        double element1 = stack.Pop();
                        stack.Push( element1 + element2);
                        break;
                    case "-":
                        RemainingChain.Dequeue();
                        element2 = stack.Pop();
                        element1 = stack.Pop();
                        stack.Push(element1 - element2);
                        break;
                    case "*":
                        RemainingChain.Dequeue();
                        element2 = stack.Pop();
                        element1 = stack.Pop();
                        stack.Push(element1 * element2);
                        break;
                    case "/":
                        RemainingChain.Dequeue();
                        element2 = stack.Pop();
                        element1 = stack.Pop();
                        stack.Push(element1 / element2);
                        break;
                    case "^":
                        RemainingChain.Dequeue();
                        element2 = stack.Pop();
                        element1 = stack.Pop();
                        stack.Push(Math.Pow(element1, element2));
                        break;
                    default:
                        stack.Push(Convert.ToDouble(RemainingChain.Dequeue()));
                        break;
                }
            }
            return stack.Peek();
        }
    }
}
