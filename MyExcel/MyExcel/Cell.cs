using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyExcel
{
    public class Cell
    {
        public string Expression { get; set; }
        public string Value { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Sys26Name { get; set; }

        public List<Cell> PointersToThis { get; set; } = new List<Cell>(); // cells that use this cell
        public List<Cell> ReferencesFromThis { get; set; } = new List<Cell>(); // cells that are in expr

        public Cell(int col, int row)
        {
            this.Row = row;
            this.Column = col;
            this.Sys26Name = Converter26Sys.To26Sys(col) + row.ToString();
            this.Value = "0";
            this.Expression = "";
        }

        public Cell(int col, int row, string exp, string value, 
            string sys26Name, List<Cell> pointers, List<Cell> references)
        {
            this.Column = col;
            this.Row = row;
            this.Expression = exp;
            this.Value = value;
            this.Sys26Name = sys26Name;
            this.PointersToThis = pointers;
            this.ReferencesFromThis = references;
        }

        public void SetCell(string expression)
        {
            this.Expression = expression;
            if (!this.CheckExpression())
            {
                throw new NonExistentCellException();
            }
            this.Value = Calculator.Evaluate(expression);
            SetPointersAndReferences(expression);
            Grid.dictionary[this.Sys26Name] = this.Value;
        }

        public bool CheckForLoop(List<Cell> references) // if there is loop in expr return true;
        {
            if(references.Count == 0)
            {
                return false;
            }

            foreach(Cell reference in references)
            {
                if (this.Sys26Name == reference.Sys26Name)
                    return true;
            }

            foreach(Cell pointer in this.PointersToThis)
            {
                foreach(Cell reference in references)
                {
                    if(pointer.Sys26Name == reference.Sys26Name)
                    {
                        return true;
                    }
                }
                if (pointer.CheckForLoop(references))
                    return true;
            }

            return false;
        }

        private bool CheckExpression() // if exp good return true;
        {
            Regex regex = new Regex("[A-Z]+[0-9]");
            MatchCollection collection = regex.Matches(this.Expression);
            foreach (Match match in collection)
            {
                if (!Grid.dictionary.ContainsKey(match.Value))
                {
                    return false;
                }
            }
            return true;
        }

        public void SetPointersAndReferences(string expression)
        {
            Regex regex = new Regex("[A-Z]+[0-9]");
            MatchCollection collection = regex.Matches(this.Expression);
            List<Cell> temp = new List<Cell>();

            foreach(Cell cell in this.ReferencesFromThis)
            {
                if(cell.PointersToThis.Contains(this))
                    cell.PointersToThis.Remove(this);
            }

            this.ReferencesFromThis.Clear();

            foreach (Match match in collection)
            {
                if (Grid.dictionary.ContainsKey(match.Value))
                {
                    Index i = Converter26Sys.From26Sys(match.Value);
                    this.ReferencesFromThis.Add(Grid.table[i.column][i.row]);
                    Grid.table[i.column][i.row].PointersToThis.Add(this);
                    temp.Add(Grid.table[i.column][i.row]);
                }
                else
                {
                    this.ReferencesFromThis.Clear();
                    foreach(Cell cell in temp)
                    {
                        if (cell.PointersToThis.Contains(this))
                            cell.PointersToThis.Remove(this);
                    }
                    throw new NonExistentCellException();
                }
            }
        }
    }
}
