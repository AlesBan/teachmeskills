using System;
using static System.Console;


namespace Calculator
{
    static class GetOperationResults
    {
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
            double result = firstNum / secondNum;
            try
            {
                return result;
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                return firstNum / secondNum;
            }
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
