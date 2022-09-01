using System;
using static System.Console;

namespace Calculator
{
    static class Program
    {
        public readonly static string[] opers = new string[] { "+", "-", "*", "/", "%", "^", "SR", "Z" };
        public static string oper = string.Empty;
        public static void Main(string[] args)
        {
            CalculatorFoo();
        }

        public static void CalculatorFoo()
        {
            Write("Приветствую тебя в нашем калькуляторе!");
            WriteLine("Доступные операции: \n+\n-\n*\n/\n%\n^\nSquere root - SR\nВыйти - Z");
            StartCalculation();
            WriteLine("Конец.");
        }
        public static void StartCalculation()
        {
           
            while (true)
            {
                oper = GetOper();
                if (oper == "Z")
                {
                    break;
                }
                if (oper == "SR")
                {
                    SquareRootOper();
                    continue;
                }
                try
                {
                    InputNums_Calculate(oper);
                }
                catch
                {
                    WriteLine("!!!Вводите числа!!!");
                }
            }
        }
        public static string GetOper()
        {
            WriteLine("Введите операцию");
            oper = ReadLine();
            if (Array.IndexOf(opers, oper) == -1)
            {
                WriteLine("Некорректный ввод");
                GetOper();
            }
            return oper;

        }
        public static void InputNums_Calculate(string oper)
        {
            WriteLine("Введите первое число");
            double firstNum = int.Parse(ReadLine());
            WriteLine("Введите второе число");
            double secondNum = int.Parse(ReadLine());
            WriteLine(CaclResult(oper, firstNum, secondNum));
        }
        public static string CaclResult(string oper, double firstNum, double secondNum)
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
            return $"{firstNum} {oper} {secondNum} = {result}";
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
        public static void SquareRootOper()
        {
            try
            {
                WriteLine("Введите число");
                double firstNum = int.Parse(ReadLine());
                WriteLine($"Sqare root of {firstNum} = {Math.Sqrt(firstNum)}");
            }
            catch
            {
                WriteLine("!!!Вводите числа!!!");
            }
        }
    }
}
