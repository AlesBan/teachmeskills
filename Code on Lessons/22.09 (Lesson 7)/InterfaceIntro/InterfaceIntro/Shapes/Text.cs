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
        public int PrintAndReturnMaxHeight()
        {
            var (left, top) = StartIndex;
            Console.CursorTop = top;
            Console.CursorLeft = left;
            Console.Write(InputText);
            return Console.CursorTop;
        }
        public static Text GetNewText()
        {
            string text = string.Empty;
            (int, int) startIndex;

            while (text == string.Empty)
            {
                Console.WriteLine("Enter some text (not empty str)");
                text = Console.ReadLine();
            }
            Console.WriteLine("Enter startIndexes");
            startIndex = GetShapeValues.GetCenterOrStartPosition();
            return new Text(text, startIndex);
        }
    }
}
