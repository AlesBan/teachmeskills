using System;

namespace InterfaceIntro
{
    public class ShapeColorAttribute : Attribute
    {
        public string Color { get; set; }
        public ShapeColorAttribute(string color)
        {
            Color = color;
        }
    }
}
