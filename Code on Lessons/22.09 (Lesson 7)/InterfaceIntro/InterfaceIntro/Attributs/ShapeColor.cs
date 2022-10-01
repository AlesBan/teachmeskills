using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro
{
    class ShapeColorAttribute : Attribute
    {
        public string Color { get; set; }
        public ShapeColorAttribute(string color)
        {
            Color = color;
        }
    }
}
