using InterfaceIntro.Interfaces;
using System;

namespace InterfaceIntro.Shapes
{
    [ShapeColor("Cyan")]
    class Text : IPrintTable, IGetNewShape
    {
        public string InputText { get; set; }
        public (int, int) StartIndex { get; set; }
        public Text()
        {

        }
        public Text(string inputText, (int, int) stsrtIndex)
        {
            InputText = inputText;
            StartIndex = stsrtIndex;
        }
        public int PrintAndReturnMaxHeight(Printer printer)
        {
            ShapeColorAttribute shapeColor = (ShapeColorAttribute)Attribute.GetCustomAttribute(typeof(Text), typeof(ShapeColorAttribute));
            foreach (var color in Interaction.colors)
            {
                if (color.ToString() == shapeColor.Color)
                {
                    ConsoleColor BorderColor = color;
                    printer.Color(BorderColor);
                }
            }
            var (left, top) = StartIndex;
            printer.SetCursorTop(top);
            printer.SetCursorLeft(left);
            printer.WriteStr(InputText);
            return printer.CursorTop();
        }
        public IPrintTable GetNewShape(Printer printer)
        {
            string text = string.Empty;
            (int, int) startIndex;

            while (text == string.Empty)
            {
                printer.WriteLine("Enter some text (not empty str)");
                text = printer.ReadLine();
            }
            printer.WriteLine("Enter startIndexes");
            startIndex = GetShapeValues.GetCenterOrStartPosition(printer);
            return new Text(text, startIndex);
        }
    }
}
