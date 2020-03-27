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
                string[] argus = Console.ReadLine()?.Split(" ");
                string[] arg = InficsMines(argus);
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
        static string[] InficsMines(string[] arg)
        {
            for(int i = 0; i<arg.Length-1; i++)
            {
                if (arg[i] == "-")
                {
                    int res;
                    if (Int32.TryParse(arg[i+1], out res)) //якщо наступне число
                    {
                        arg[i+1] = (Convert.ToInt32(arg[i + 1]) * (-1)).ToString();
                        arg[i] = "+";
                    }
                    else //якщо після "-" дужка
                    {
                        arg[i] =  "+";
                        int n = i + 2; //позиція закритої дужки
                        while (arg[n]!=")")
                        {
                            n++;
                        }      
                        if (Int32.TryParse(arg[i + 2], out res)) 
                            arg[i + 2] = (Convert.ToInt32(arg[i + 2]) * (-1)).ToString();
                        for (int j = i+2; j < n - 1; j++) //змінюємо знаки в дужках на протилежні
                        {
                            switch (arg[j]) {
                                case "+":
                                    arg[j] = "-";
                                    break;
                                case "-":
                                    arg[j] = "+";
                                    break;
                            }         
                        }
                    }
                }
            }
            for(int i =0; i < arg.Length-1; i++) //видаляємо повтори знаків, що виникли за умови зміни "-" на "+"
            {
                if (arg[i] == "+" && arg[i + 1] == "+")
                {
                    int n = arg.Length - 1;
                    string[] arg_new = new string[n];
                    for(int j = 0; j < i; j++)
                    {
                        arg_new[j] = arg[j];
                    }
                    for (int j = i + 1; j < n + 1; j++)
                    {
                        arg_new[j - 1] = arg[j];
                    }
                    arg = new string[n];
                    arg = arg_new;
                }
                if (arg[i] == "(" && arg[i + 1] == "+")
                {
                    int n = arg.Length - 1;
                    string[] arg_new = new string[n];
                    for (int j = 0; j < i + 1; j++)
                    {
                        arg_new[j] = arg[j];
                    }
                    for (int j = i + 2; j < n + 1; j++)
                    {
                        arg_new[j - 1] = arg[j];
                    }
                    arg = new string[n];
                    arg = arg_new;
                }
            }
            return arg;
        }
    }
}
