using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Calculator
{
    static class Program
    {
        public readonly static string[] allOperations = new string[] { "+", "-", "*", "/", "%", "^", "Sqrt", $"{ExitOper}" };
        public readonly static string[] allMathOperations = new string[] { "+", "-", "*", "/", "%", "^", "Sqrt"};
        public readonly static string[] opersWithTwoNums = new string[] { "+", "-", "*", "/", "%", "^"};
        public readonly static string[] opersWithOneNum = new string[] { "Sqrt" };
        public readonly static string availableOperations = $"Доступные операции: \n{string.Join(" ", allOperations)}\nSqrt - Квадратный корень\n{ExitOper} - Выход";
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
            WriteLine($"{availableOperations}\nТакже можете вводить пример сразу\n{ExitOper} - Выход");
            CalculatorMain();
            WriteLine("Пока.");
        }
        public static void CalculatorMain()
        {
            string oper = GetOperation();

            while (oper != ExitOper)
            {
                if (oper.Length == 1)
                {
                    if (Array.IndexOf(allOperations, oper) == -1)
                    {
                        IncorrectInput_Message();
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
        public static void Calculate_WholeExample(string example)
        {
            bool oneNum = false;
            string operatorEx = string.Empty;

            foreach (string op in opersWithOneNum.Where(x => example.Contains(x)))
            {
                oneNum = true;
                operatorEx = op;
            }
            if (oneNum)
            {
                WriteLine(CaclResult(operatorEx, double.Parse(example.Replace(operatorEx,"").Trim()), default));
            }
            else
            {
                foreach (string oper in allMathOperations.Where(x => example.Contains(x)))
                {
                    operatorEx = oper;
                }
                List<string> ExampleNums = new List<string>
                {
                    example[..example.IndexOf(operatorEx)].Trim(),
                    example[(example.IndexOf(operatorEx)+1)..].Trim()
                };
                foreach (string str in ExampleNums)
                {
                    WriteLine(str + "\n");
                }
                try
                {
                    WriteLine(CaclResult(operatorEx, double.Parse(ExampleNums[0]), double.Parse(ExampleNums[1])));
                }
                catch
                {
                    IncorrectInput_Message();
                    CalculatorMain();
                }
            }
        }
        public static void Calculate_ExampleInParts(string oper)
        {
            if (Array.IndexOf(opersWithTwoNums, oper) != -1)
            {
                InputTwoNums_Calculate(oper);
            }
            else if (Array.IndexOf(opersWithOneNum, oper) != -1)
            {
                InputOneNum_Calculate(oper);
            }
        }
        public static void InputTwoNums_Calculate(string oper)
        {
            WriteLine("Введите первое число");
            double firstNum = double.Parse(ReadLine());
            WriteLine("Введите второе число");
            double secondNum = double.Parse(ReadLine());
            WriteLine(CaclResult(oper, firstNum, secondNum));
        }
        public static void InputOneNum_Calculate(string oper)
        {
            WriteLine("Введите число");
            double firstNum = double.Parse(ReadLine());
            WriteLine(CaclResult(oper, firstNum, (int)default));
        }
        public static string CaclResult(string oper, double firstNum, double secondNum)
        {
            double result;
            int decimalPointFirstNum = 1, decimalPointSecondNum = 1;
            while (firstNum * Math.Pow(10, 1 + decimalPointFirstNum) % 10 != 0) { decimalPointFirstNum++; }
            while (secondNum * Math.Pow(10, 1 + decimalPointSecondNum) % 10 != 0) { decimalPointSecondNum++; }
            int totalDecimalPoint = decimalPointFirstNum > decimalPointSecondNum ? decimalPointFirstNum : decimalPointSecondNum;
            switch (oper)
            {
                case "+": result = PlusOper(firstNum, secondNum); break;

                case "-": result = MinusOper(firstNum, secondNum); break;

                case "*": result = MultiplyOper(firstNum, secondNum); break;

                case "/": result = DivideOper(firstNum, secondNum); break;

                case "%": result = PersentOper(firstNum, secondNum); break;

                case "^": result = DegreeOper(firstNum, secondNum); break;

                case "Sqrt": return SquareRootOper(firstNum);

                default:
                    {
                        return "Такую операцию наш калькулятор не поддерживает!";
                    }
            }
            return $"{firstNum} {oper} {secondNum} = {Math.Round(result, totalDecimalPoint)}";
        }
        public static string AskForContinue()
        {
            WriteLine("\nЖелаете продолжить? Да/Нет");
            WriteLine($"Также можете вводить пример сразу\n{availableOperations}\n");
            string choise = ReadLine();
            if (Array.IndexOf(wordsYes, choise) != -1)
            {
                return GetOperation();
            }
            else if (Array.IndexOf(wordsNo, choise) != -1)
            {
                return ExitOper;
            }
            else if (choise == ExitOper)
            {
                return ExitOper;
            }
            if (choise.Length > 2)
            {
                foreach (string oper in allMathOperations)
                {
                    if (choise.Where(x => x.ToString() == oper) != null)
                    {
                        return choise;
                    }
                }
                IncorrectInput_Message();
                return AskForContinue();
            }
            else
            {
                IncorrectInput_Message();
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
        public static void IncorrectInput_Message()
        {
            WriteLine("Некоррекный ввод");
        }
    }
}
