using System;
using static System.Console;

namespace Calculator
{
    static class Program
    {
        public readonly static string[] opers = new string[] { "+", "-", "*", "/", "%", "^", "Z" };
        public static void Main(string[] args)
        {
            Write("Приветствую тебя в нашем калькуляторе!");
            WriteLine("Доступные операции: +\n-\n*\n/\n%\n^\nВыйти - Z");
            CalculatorFoo();
        }
        public static void CalculatorFoo()
        {
            string oper = string.Empty;
            int firstNum, secondNum;
            while (oper != "Z")
            {
                WriteLine("Введите операцию");
                oper = ReadLine();
                if (Array.IndexOf(opers, oper) == -1)
                {
                    WriteLine("Некорректный ввод");
                    continue;
                }
                try
                {
                    WriteLine("Введите первое число");
                    firstNum = int.Parse(ReadLine());
                    WriteLine("Введите второе число");
                    secondNum = int.Parse(ReadLine());
                }
                catch
                {
                    WriteLine("!!!Вводите числа!!!");
                    continue;
                }

                switch (oper)
                {
                    case "+" :
                        {
                            WriteLine($"{firstNum} + {secondNum} = {firstNum + secondNum}");
                            break;
                        }
                    case "-":
                        {
                            WriteLine($"{firstNum} - {secondNum} = {firstNum - secondNum}");
                            break;
                        }
                    case "*":
                        {
                            WriteLine($"{firstNum} * {secondNum} = {firstNum * secondNum}");
                            break;
                        }
                    case "/":
                        {
                            WriteLine($"{firstNum} / {secondNum} = {firstNum / secondNum}");
                            break;
                        }
                    case "%":
                        {
                            WriteLine($"{firstNum} / {secondNum} = {firstNum / 100 * secondNum}");
                            break;
                        }
                    case "^":
                        {
                            WriteLine($"{firstNum} ^ {secondNum} = {Math.Pow(firstNum, secondNum)}");
                            break;
                        }
                }
            }
            WriteLine("Конец.");
        }
    }
}
