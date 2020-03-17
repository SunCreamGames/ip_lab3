using System;

//C:\Users\Ann\labs_IP\lab3\lab3
//"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\Roslyn\csc.exe"

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arg = { "2+", "1-", "13+5234" };
            Parse(arg);
            //Console.WriteLine(args[0] + args[2]);
        }
        static void Parse(string[] arg)
        {
            int n = arg.Length;
            string[] elements = new string[0];
            for (int i = 0; i < n; i++)
            {
                string str = arg[i];
                int pos = 0; //current position
                bool IsNumber = false; //is previous number
                

                for (int j = 0; j < str.Length; j++)
                {
                    switch (str[j])
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            if (IsNumber)
                            {
                                int m1 = elements.Length;
                                Array.Resize(ref elements, m1 + 2);
                                elements[m1] = str.Substring(pos, j);
                                elements[m1 + 1] = str[j].ToString();
                                pos = j+1;
                            }
                            else
                            {
                                int m2 = elements.Length;
                                Array.Resize(ref elements, m2 + 1);
                                elements[m2] = str[j].ToString();
                                
                            }
                            break;
                        default:
                            if (j == str.Length - 1)
                            {
                                int m2 = elements.Length;
                                Array.Resize(ref elements, m2 + 1);                                
                                elements[m2] = str.Substring(pos, j-pos+1);
                                
                            }
                            else
                            {
                                if (!IsNumber)
                                {
                                    IsNumber = true;
                                    pos = j;
                                }
                                
                            }
                            break;
                    }
                }
            }
        }
    }
}
