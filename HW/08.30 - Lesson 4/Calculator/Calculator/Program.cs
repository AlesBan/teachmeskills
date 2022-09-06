using System;
using System.Text;
using static System.Console;

namespace Calculator
{
    static class Program
    {
        public readonly static string[] allOperations = new string[] { "+", "-", "*", "/", "%", "^", "КК", $"{ExitOper}" };
        public readonly static string[] opersWithTwoNums = new string[] { "+", "-", "*", "/", "%", "^"};
        public readonly static string[] opersWithOneNum = new string[] { "КК" };
        public readonly static string availableOperations = $"Доступные операции: \n{string.Join(" ", allOperations)}\nКК - Square root";
        public const string ExitOper = "Z";
        public readonly static string[] wordsYes = new string[] { "ДА","Да","да","lf","LF","Lf" };
        public readonly static string[] wordsNo = new string[] { "YTN", "Ytn", "ytn", "нет", "Нет", "НЕТ" };
        public static void Main(string[] args)
        {
            CalculatorGreed();
        }
        public static void CalculatorGreed()
        {
            WriteLine("Приветствую тебя в нашем калькуляторе!");
            CalculatorMain();
            WriteLine("Пока.");
        }
        public static void CalculatorMain()
        {
            WriteLine($"{availableOperations}\nТакже можете вводить пример сразу\n{ExitOper} - Выход");
            string oper = GetOperation();

            while (oper != ExitOper)
            {
                if (oper.Length == 1)
                {
                    if (Array.IndexOf(allOperations, oper) == -1)
                    {
                        WriteLine("Некорректный ввод");
                        GetOperation();
                    }
                    Calculate_ExampleInParts(oper);
                }
                else
                {
                    Calculate_WholeExample(oper);
                }
                oper = AskForContinue();
            }
        }
        public static string GetOperation()
        {
            WriteLine("Введите пример или операцию");
            string oper = ReadLine();
            return oper;
        }
        public static void Calculate_WholeExample(string oper)
        {
            string[] ExampleParts = oper.Split(" ");
            try
            {
                WriteLine(CaclResult(ExampleParts[1], int.Parse(ExampleParts[0]), int.Parse(ExampleParts[2])));
            }
            catch
            {
                WriteLine("Некорректный ввод");
                CalculatorMain();
            }
        }
        public static void Calculate_ExampleInParts(string oper)
        {
            try
            {
                if (Array.IndexOf(opersWithTwoNums, oper) != -1)
                {
                    InputTwoNums_Calculate(oper);
                }
                else if (Array.IndexOf(opersWithOneNum, oper) != -1)
                {
                    InputOneNum_Calculate(oper);
                }
                else
                {
                    WriteLine("!!!Вводите операции корректно!!!");
                }
            }
            catch
            {
                WriteLine("!!!Вводите числа!!!");
            }
        }
        public static void InputTwoNums_Calculate(string oper)
        {
            WriteLine("Введите первое число");
            double firstNum = int.Parse(ReadLine());
            WriteLine("Введите второе число");
            double secondNum = int.Parse(ReadLine());
            WriteLine(CaclResult(oper, firstNum, secondNum));
        }
        public static void InputOneNum_Calculate(string oper)
        {
            WriteLine("Введите число");
            double firstNum = int.Parse(ReadLine());
            WriteLine(CaclResult(oper, firstNum, (int)default));
        }
        public static string CaclResult(string oper, double firstNum, double secondNum)
        {
            double result;
            switch (oper)
            {
                case "+": result = PlusOper(firstNum, secondNum); break;

                case "-": result = MinusOper(firstNum, secondNum); break;

                case "*": result = MultiplyOper(firstNum, secondNum); break;

                case "/": result = DivideOper(firstNum, secondNum); break;

                case "%": result = PersentOper(firstNum, secondNum); break;

                case "^": result = DegreeOper(firstNum, secondNum); break;

                case "SR": return SquareRootOper(firstNum);

                default:
                    {
                        return "Такую операцию наш калькулятор не поддерживает!";
                        break;
                    }
            }
            return $"{firstNum} {oper} {secondNum} = {result}";
        }
        public static string AskForContinue()
        {
            WriteLine("Желаете продолжить? Да/Нет");
            string choise = ReadLine();
            if (Array.IndexOf(wordsYes, choise) != -1)
            {
                return GetOperation();
            }
            else if (Array.IndexOf(wordsNo, choise) != -1)
            {
                return ExitOper;
            }
            else
            {
                WriteLine("Некоррекный ввод");
                return AskForContinue();
            }
        }
        public static double PlusOper(double firstNum, double secondNum)
        {
            return firstNum + secondNum;
        }
        public static double MinusOper(double firstNum, double secondNum)
        {
            return firstNum - secondNum;
        }
        public static double MultiplyOper(double firstNum, double secondNum)
        {
            return firstNum * secondNum;
        }
        public static double DivideOper(double firstNum, double secondNum)
        {
            return firstNum / secondNum;
        }
        public static double PersentOper(double firstNum, double secondNum)
        {
            return firstNum / 100 * secondNum;
        }
        public static double DegreeOper(double firstNum, double secondNum)
        {
            return Math.Pow(firstNum, secondNum);
        }
        public static string SquareRootOper(double firstNum)
        {
            return $"Square root of {firstNum} = {Math.Sqrt(firstNum)}";
        }
    }
}
