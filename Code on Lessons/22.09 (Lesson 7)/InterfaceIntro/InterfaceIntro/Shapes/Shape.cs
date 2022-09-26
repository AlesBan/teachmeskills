using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    abstract class Shape
    {
        public char Symble { get; set; }
        public (int, int) StartIndex { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }

        protected Shape(int length, int height, char symble, (int, int) startIndex)
        {
            Length = length;
            Height = height;
            Symble = symble;
            StartIndex = startIndex;
        }
        protected Shape(int length, char symble, (int, int) startIndex)
        {
            Length = length;
            Symble = symble;
            StartIndex = startIndex;
        }
        public abstract void Print();

    }
}
