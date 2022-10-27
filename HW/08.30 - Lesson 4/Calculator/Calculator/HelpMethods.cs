using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator
{
    class HelpMethods
    {
        public static List<Operation> SortOperations(List<Operation> operationsForSorting)
        {
            List<Operation> newOperations = operationsForSorting.OrderBy(b => b.placeIndex_inEntered).ToList();
            return newOperations;
        }
    }
}
