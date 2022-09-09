using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;


namespace Calculator
{
    class Constans
    {
        public readonly static string[] allOperations = new string[] { "+", "-", "*", "/", "%", "^", "Sqrt", $"{ExitOper}" };
        public readonly static string[] allMathOperations = new string[] { "+", "-", "*", "/", "%", "^", "Sqrt" };
        public readonly static string[] opersWithTwoNums = new string[] { "+", "-", "*", "/", "%", "^" };
        public readonly static string[] opersWithOneNum = new string[] { "Sqrt" };
        public readonly static string availableOperations = $"Доступные операции: \n{string.Join(" ", allOperations)}\nSqrt - Квадратный корень\n{ExitOper} - Выход";
        public const string ExitOper = "Z";
        public readonly static string[] wordsYes = new string[] { "ДА", "Да", "да", "lf", "LF", "Lf" };
        public readonly static string[] wordsNo = new string[] { "YTN", "Ytn", "ytn", "нет", "Нет", "НЕТ" };
        public static void IncorrectInput_Message()
        {
            WriteLine("Некоррекный ввод");
        }
    }
}
