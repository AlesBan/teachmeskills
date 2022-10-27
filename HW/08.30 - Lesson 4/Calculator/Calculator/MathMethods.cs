using System;

namespace Calculator
{
    static class MathMethods
    {
        public static int GetDecimalPoint(double num)
        {
            int i = 1;
            while (num * Math.Pow(10, 1 + i) % 10 != 0)
            {
                i++;
            }
            return i;
        }
    }
}
