using System;
using static System.Console;

namespace Calculator
{
    static class Program
    {
        public readonly static string[] opers = new string[] { "+", "-", "*", "/", "%", "^", "SR", "Z" };
        public static void Main(string[] args)
        {
            CalculatorFoo();
        }

        public static void CalculatorFoo()
        {
            Write("Приветствую тебя в нашем калькуляторе!");
            WriteLine("Доступные операции: +\n-\n*\n/\n%\n^\nSquere root - SR\nВыйти - Z");
            string oper = string.Empty;
            double firstNum, secondNum;
            while (oper != "Z")
            {
                WriteLine("Введите операцию");
                oper = ReadLine();
                if (Array.IndexOf(opers, oper) == -1)
                {
                    WriteLine("Некорректный ввод");
                    continue;
                }
                if (oper == "SR")
                {
                    try
                    {
                        WriteLine("Введите число");
                        firstNum = int.Parse(ReadLine());
                        WriteLine(SquareRootOper(firstNum));
                        continue;
                    }
                    catch
                    {
                        WriteLine("!!!Вводите числа!!!");
                        continue;
                    }
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
                Operations(oper, firstNum, secondNum);
            }
            WriteLine("Конец.");
        }
        public static void Operations(string oper, double firstNum, double secondNum)
        {
            double result = 0;
            switch (oper)
            {
                case "+":
                    {
                        result = PlusOper(firstNum, secondNum);
                    break;
                    }
                case "-":
                    {
                        result = MinusOper(firstNum, secondNum);
                        break;
                    }
                case "*":
                    {
                        result = MultiplyOper(firstNum, secondNum);
                        break;
                    }
                case "/":
                    {
                        result = DivideOper(firstNum, secondNum);
                        break;
                    }
                case "%":
                    {
                        result = PersentOper(firstNum, secondNum);
                        break;
                    }
                case "^":
                    {
                        result = DegreeOper(firstNum, secondNum);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            WriteLine($"{firstNum} {oper} {secondNum} = {result}");
        }
        //  +
        public static double PlusOper(double firstNum, double secondNum)
        {
            return firstNum + secondNum;
        }
        //  -
        public static double MinusOper(double firstNum, double secondNum)
        {
            return firstNum - secondNum;
        }
        //  *
        public static double MultiplyOper(double firstNum, double secondNum)
        {
            return firstNum * secondNum;
        }
        //  /
        public static double DivideOper(double firstNum, double secondNum)
        {
            return firstNum / secondNum;
        }
        //  %
        public static double PersentOper(double firstNum, double secondNum)
        {
            return firstNum / 100 * secondNum;
        }
        // ^
        public static double DegreeOper(double firstNum, double secondNum)
        {
            return Math.Pow(firstNum, secondNum);
        }

        // SR
        public static string SquareRootOper(double firstNum)
        {
            return $"Sqare root of {firstNum} = {Math.Sqrt(firstNum)}";
        }
    }
}
