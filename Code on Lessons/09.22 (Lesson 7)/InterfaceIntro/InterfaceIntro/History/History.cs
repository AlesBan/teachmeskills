using System;
using System.Collections.Generic;

namespace InterfaceIntro
{
    class History
    {
        protected History()
        {

        }

        public static readonly List<HistoryRecord<IPrintTable>> historyRecords = new List<HistoryRecord<IPrintTable>>();

        public static void AddInHistory(IPrintTable printTable)
        {
            historyRecords.Add(new HistoryRecord<IPrintTable>(printTable, DateTime.Now));
        }
        public static void ShowAllHistoty(PrinterConsole printerConsole)
        {
            foreach (var el in historyRecords)
            {
                printerConsole.WriteLine($"Figure: {el.GetShapeName(el.Shape)}\t Print time: {el.DateTime}");
            }
        }
    }
}
