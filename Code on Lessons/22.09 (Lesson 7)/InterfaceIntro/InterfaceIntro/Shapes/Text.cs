using InterfaceIntro.Interfaces;
using System;

namespace InterfaceIntro.Shapes
{
    [ShapeColor("Cyan")]
    class Text : IPrintTable, IGetNewShape
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
            ShapeColorAttribute shapeColor = (ShapeColorAttribute)Attribute.GetCustomAttribute(typeof(Text), typeof(ShapeColorAttribute));
            foreach (var color in Interaction.colors)
            {
                if (color.ToString() == shapeColor.Color)
                {
                    ConsoleColor BorderColor = color;
                    Console.ForegroundColor = BorderColor;
                }
            }
            var (left, top) = StartIndex;
            Console.CursorTop = top;
            Console.CursorLeft = left;
            Console.Write(InputText);
            return Console.CursorTop;
        }
        public IPrintTable GetNewShape()
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
