using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro
{
    class PrinterOutPut
    {
        Action<string> ActionAn = (str) => Console.WriteLine(str);
    }
}
