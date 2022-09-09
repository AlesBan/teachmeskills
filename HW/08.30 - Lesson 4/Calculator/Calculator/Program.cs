using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Calculator
{
    static class Program
    {
        public static void Main(string[] args)
        {
            CalculatorGreed();
        }
        public static void CalculatorGreed()
        {
            WriteLine("Приветствую тебя в нашем калькуляторе!");
            WriteLine($"{Constans.availableOperations}\nТакже можете вводить пример сразу\n{Constans.ExitOper} - Выход");
            CalculatorMain();
            WriteLine("Пока.");
        }
        public static void CalculatorMain()
        {
            string oper = GetOperation();

            while (oper != Constans.ExitOper)
            {
                if (oper.Length == 1)
                {
                    if (Array.IndexOf(Constans.allOperations, oper) == -1)
                    {
                        Constans.IncorrectInput_Message();
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

            foreach (string op in Constans.opersWithOneNum.Where(x => example.Contains(x)))
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
                foreach (string oper in Constans.allMathOperations.Where(x => example.Contains(x)))
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
                    Constans.IncorrectInput_Message();
                    CalculatorMain();
                }
            }
        }
        public static void Calculate_ExampleInParts(string oper)
        {
            if (Array.IndexOf(Constans.opersWithTwoNums, oper) != -1)
            {
                InputTwoNums_Calculate(oper);
            }
            else if (Array.IndexOf(Constans.opersWithOneNum, oper) != -1)
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
            int decimalPointFirstNum = MathMethods.GetDecimalPoint(firstNum);
            int decimalPointSecondNum = MathMethods.GetDecimalPoint(secondNum);
            int totalDecimalPoint = decimalPointFirstNum > decimalPointSecondNum ? decimalPointFirstNum : decimalPointSecondNum;
            switch (oper)
            {
                case "+": result = GetOperationResults.PlusOper(firstNum, secondNum); break;

                case "-": result = GetOperationResults.MinusOper(firstNum, secondNum); break;

                case "*": result = GetOperationResults.MultiplyOper(firstNum, secondNum); break;

                case "/": result = GetOperationResults.DivideOper(firstNum, secondNum); break;

                case "%": result = GetOperationResults.PersentOper(firstNum, secondNum); break;

                case "^": result = GetOperationResults.DegreeOper(firstNum, secondNum); break;

                case "Sqrt": return GetOperationResults.SquareRootOper(firstNum);

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
            WriteLine($"Также можете вводить пример сразу\n{Constans.availableOperations}\n");
            string choise = ReadLine();
            if (Array.IndexOf(Constans.wordsYes, choise) != -1)
            {
                return GetOperation();
            }
            else if (Array.IndexOf(Constans.wordsNo, choise) != -1)
            {
                return Constans.ExitOper;
            }
            else if (choise == Constans.ExitOper)
            {
                return Constans.ExitOper;
            }
            if (choise.Length > 2)
            {
                foreach (string oper in Constans.allMathOperations)
                {
                    if (choise.Where(x => x.ToString() == oper) != null)
                    {
                        return choise;
                    }
                }
                Constans.IncorrectInput_Message();
                return AskForContinue();
            }
            else
            {
                Constans.IncorrectInput_Message();
                return AskForContinue();
            }
        }
    }
}
