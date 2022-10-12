using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceIntro
{
    class HistoryRecord<T>
    {
        public T Shape { get; set; }
        public DateTime DateTime { get; set; }

        public HistoryRecord(T shape, DateTime dateTime)
        {
            Shape = shape;
            DateTime = dateTime;
        }
        public string GetShapeName(T Shape)
        {
            return Shape.GetType().Name;
        }
    }
}
