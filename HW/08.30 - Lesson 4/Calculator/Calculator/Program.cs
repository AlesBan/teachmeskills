using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace Calculator
{
    static class Program
    {
        public static List<Operation> operations;
        public static List<Number> numbers;
        public static List<Expression> expressions;

        public static void Main(string[] args)
        {
            CalculatorGreet();
        }
        public static void CalculatorGreet()
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
                    Calculate_ExpressionInParts(oper);
                }
                else
                {
                    Calculate_WholeExpression(oper);
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
        public static void FindAllOperators(string expressionEntered)
        {
            operations = new List<Operation>();
            StringBuilder sbExpression = new StringBuilder(expressionEntered);
            int operationPriority = 1;

            foreach (string oper in Constans.allMathOperations)
            {
                while (sbExpression.ToString().Contains(oper))
                {
                    Operation operation = new Operation
                    {
                        operation_str = oper,
                        placeIndex_inEntered = expressionEntered.IndexOf(oper),
                        placeIndex_inEnteredSB = sbExpression.ToString().IndexOf(oper),
                        priopity = operationPriority,
                        length = oper.Length,
                    };
                    operation.childrenStr = new List<string>
                    {
                        expressionEntered[..operation.placeIndex_inEntered],
                        expressionEntered[operation.placeIndex_inEntered..]
                    };
                    operations.Add(operation);
                    operationPriority++;
                    sbExpression.Remove(operation.placeIndex_inEnteredSB, operation.length);
                }
            }
        }
        public static void FindAllNumbers(string expressionEntered)
        {
            numbers = new List<Number>();
            for (int i = 0; i < operations.Count; i++)
            {
                if (i == 0 && expressionEntered[..operations[i].placeIndex_inEntered].Length != 0)
                {
                    numbers.Add(new Number { num = double.Parse(expressionEntered[..operations[i].placeIndex_inEntered]) });
                }
                else if (i < operations.Count - 1 && expressionEntered[operations[i - 1].placeIndex_inEntered..operations[i].placeIndex_inEntered].Length != 0)
                {
                    numbers.Add(new Number { num = double.Parse(expressionEntered[(operations[i - 1].placeIndex_inEntered + 1)..operations[i].placeIndex_inEntered]) });
                }
                else if (i == operations.Count - 1 && expressionEntered[operations[i].placeIndex_inEntered..].Length != 0) 
                {
                    numbers.Add(new Number { num = double.Parse(expressionEntered[(operations[i - 1].placeIndex_inEntered + 1)..operations[i].placeIndex_inEntered]) });
                    numbers.Add(new Number { num = double.Parse(expressionEntered[(operations[i].placeIndex_inEntered + 1)..]) });
                }
            }
        }
        public static void Calculate_WholeExpression(string expressionEntered)
        {
            bool oneNum = false;
            bool expHasOperators = true;
            string operatorEx = string.Empty;
            Expression expression = new Expression
            {
                expression_str = expressionEntered.ToString()
            };
            FindAllOperators(expressionEntered);
            operations = HelpMethods.SortOperations(operations);
            FindAllNumbers(expressionEntered);

            //while (expHasOperators)
            //{

            //}
            //foreach (string op in Constans.opersWithOneNum.Where(x => example.Contains(x)))
            //{
            //    oneNum = true;
            //    operatorEx = op;
            //}
            //if (oneNum)
            //{
            //    WriteLine(CaclResult(operatorEx, double.Parse(example.Replace(operatorEx,"").Trim()), default));
            //}
            //else
            //{
            //    foreach (string oper in Constans.allMathOperations.Where(x => example.Contains(x)))
            //    {
            //        operatorEx = oper;
            //    }
            //    List<string> ExampleNums = new List<string>
            //    {
            //        example[..example.IndexOf(operatorEx)].Trim(),
            //        example[(example.IndexOf(operatorEx)+1)..].Trim()
            //    };
            //    foreach (string str in ExampleNums)
            //    {
            //        WriteLine(str + "\n");
            //    }
            //    try
            //    {
            //        WriteLine(CaclResult(operatorEx, double.Parse(ExampleNums[0]), double.Parse(ExampleNums[1])));
            //    }
            //    catch
            //    {
            //        Constans.IncorrectInput_Message();
            //        CalculatorMain();
            //    }
            //}
        }
        public static void Calculate_ExpressionInParts(string oper)
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

                case "sqrt": return GetOperationResults.SquareRootOper(firstNum);

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
