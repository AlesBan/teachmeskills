using TableDataTypes.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TableDataTypes.Person;
using System.Linq;

namespace TableDataTypes
{
    [Serializable]
    class Table<T, U, V>
    {
        public List<Line<T, U, V>> Lines = new List<Line<T, U, V>>();
        public List<List<Line<T, U, V>>> Pages { get; set; }
        public int ItemsOnPage { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public Table()
        {
            CurrentPage = 1;
            ItemsOnPage = 5;
            Count = 0;
        }
        public void FillPaginationList()
        {
            Pages = new List<List<Line<T, U, V>>>();
            int i = 1, index = 1;
            List<Line<T, U, V>> linesOnPage = new List<Line<T, U, V>>();
            foreach (Line<T, U, V> line in Lines)
            {
                line.Index = index;
                linesOnPage.Add(line);
                if (i != ItemsOnPage)
                {
                    i++;
                }
                else
                {
                    Pages.Add(linesOnPage);
                    linesOnPage = new List<Line<T, U, V>>();
                    i = 1;
                }
                index++;
            }
            if (linesOnPage.Count != 0)
            {
                Pages.Add(linesOnPage);
            }
        }
        public void AddNewLine(Line<T, U, V> line)
        {
            Lines.Add(line);
            Count++;
        }
        public void DeleteLine(int index)
        {
            Lines = Lines.Where(x => x.Index != index).ToList();
            Count--;
        }
        public void PrintTable()
        {
            PrintTopOfTable();

            foreach (List<Line<T, U, V>> lineList in Pages)
            {
                if (Pages.IndexOf(lineList) + 1 == CurrentPage)
                {
                    PrintPage(lineList);
                }
            }
            Console.WriteLine($"\nPage number: {CurrentPage}\tTotal pages: {Pages.Count}");
            Console.WriteLine($"Total items: {Count}");
        }
        public void PrintPage(List<Line<T, U, V>> lineList)
        {
            foreach (Line<T, U, V> line in lineList)
            {
                line.PrintLine(Count);
            }
        }
        public void PrintTopOfTable()
        {
            FindTheLongestStr();
            int indentation = 2;
            int countLength = Count.ToString().Length;
            Console.Write("№");
            Console.CursorLeft = Count.ToString().Length + indentation + countLength;
            Console.Write("Name");
            Console.CursorLeft = LongestColumnLenght.LongestLenghtTColumn + indentation * 2 + countLength;
            Console.Write("Age");
            Console.CursorLeft = LongestColumnLenght.LongestLenghtTColumn + LongestColumnLenght.LongestLenghtUColumn + indentation * 3 + countLength;
            Console.Write("Address" + "\n\n");
        }
        public void FindTheLongestStr()
        {
            int longestInTColumn = 4;
            int longestInUColumn = 3;
            int TypesVarLength;
            foreach (Line<T, U, V> line in Lines)
            {
                TypesVarLength = line.TTypeVar.ToString().Length;
                longestInTColumn = TypesVarLength > longestInTColumn ? TypesVarLength : longestInTColumn;

                TypesVarLength = line.UTypeVar.ToString().Length;
                longestInUColumn = TypesVarLength > longestInUColumn ? TypesVarLength : longestInUColumn;
            }
            LongestColumnLenght.LongestLenghtTColumn = longestInTColumn;
            LongestColumnLenght.LongestLenghtUColumn = longestInUColumn;
        }
    }
}
