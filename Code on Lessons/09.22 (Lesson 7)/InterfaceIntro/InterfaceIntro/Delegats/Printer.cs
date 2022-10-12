using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro
{
    public class PrinterConsole
    {
        public Action<string> WriteLine { get; set; } = (str) => Console.WriteLine(str);
        public Action<char> WriteChar { get; set; } = (str) => Console.Write(str);
        public Action<string> WriteStr { get; set; } = (str) => Console.Write(str);
        public Func<string> ReadLine { get; set; } = () => Console.ReadLine();
        public Action Clear { get; set; } = () => Console.Clear();
        public Action<int> SetCursorTop { get; set; } = (num) => Console.CursorTop = num;
        public Action<int> SetCursorLeft { get; set; } = (num) => Console.CursorLeft = num;
        public Func<int> CursorTop { get; set; } = () => Console.CursorTop; 
        public Func<int> CursorLeft { get; set; } = () => Console.CursorLeft;
        public Action<ConsoleColor> Color { get; set; } = (color) => Console.ForegroundColor = color;
    }
}
