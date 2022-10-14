﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TableDataTypes
{
    class Table<T, U, V>
    {
        public List<Line<T, U, V>> Lines = new List<Line<T, U, V>>();

        public Table()
        {

        }
        public void AddNewLine(Line<T, U, V> line)
        {
            Lines.Add(line);
        }
        public void PrintAllTable()
        {
            FindTheLongestStr();
            foreach (Line<T, U, V> line in Lines)
            {
                line.PrintLine();
            }
        }
        public void FindTheLongestStr()
        {
            int longestInTColumn = default;
            int longestInUColumn = default;
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