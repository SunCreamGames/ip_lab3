using System;

//C:\Users\Ann\labs_IP\lab3\lab3
//"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\Roslyn\csc.exe"

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                //string[] arg = { "(8 + 2.15 * 5) / (1 + 3 * 2 - 4)" };
                string[] arg = Console.ReadLine()?.Split(" ");
                ReversePolishNotation argInRPN = new ReversePolishNotation(arg);

                double solution = argInRPN.Solution();
                Console.WriteLine(solution);
            }
            else
            {
                ReversePolishNotation argsInRPN = new ReversePolishNotation(args);

                double solution = argsInRPN.Solution();
                Console.WriteLine(solution);
            }
            Console.ReadKey();
        }
    }
}
