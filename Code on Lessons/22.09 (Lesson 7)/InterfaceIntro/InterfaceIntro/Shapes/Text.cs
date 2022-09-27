using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro.Shapes
{
    class Text : IPrintTable
    {
        public string InputText { get; set; }
        public (int, int) StartIndex { get; set; }
        public Text(string inputText, (int, int) stsrtIndex)
        {
            InputText = inputText;
            StartIndex = stsrtIndex;
        }
        public void Print()
        {
            var (left, top) = StartIndex;
            Console.CursorTop = top;
            Console.CursorLeft = left;
            Console.Write(InputText);
        }
    }
}
