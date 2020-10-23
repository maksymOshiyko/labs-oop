using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyExcel
{
    public static class Grid
    {
        public static int ColumnsCount { get; set; }
        public static int RowsCount { get; set; }

        public static List<List<Cell>> table = new List<List<Cell>>();

        public static Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public static void setGrid(int cols, int rows)
        {
            if(cols < 0 || rows < 0)
            {
                throw new ArgumentException();
            }

            Clear();

            ColumnsCount = cols;
            RowsCount = rows;

            for(int i  = 0; i < cols; ++i)
            {
                List<Cell> column = new List<Cell>();

                for(int j = 0; j < rows; ++j)
                {
                    Cell c = new Cell(i, j);
                    column.Add(c);
                    dictionary.Add(c.Sys26Name, "");
                }
                table.Add(column);
            }
        }

        public static void Clear()
        {
            foreach(List<Cell> list in table)
            {
                list.Clear();
            }
            table.Clear();
            dictionary.Clear();
            ColumnsCount = 0;
            RowsCount = 0;
        }

        public static void ChangeCellWithPointers(int column, int row, string expression, 
            DataGridView dataGridView)
        {
            Cell cell = Grid.table[column][row];
            cell.SetCell(expression);
            if (cell.CheckForLoop(cell.ReferencesFromThis))
            {
                throw new LoopException();
            }
            if (cell.PointersToThis.Count != 0)
            {
                var list = cell.PointersToThis.ToList();
                foreach (Cell pointer in list)
                {
                    ChangeCellWithPointers(pointer.Column, pointer.Row, pointer.Expression, dataGridView);
                    dataGridView[pointer.Column, pointer.Row].Value = pointer.Value;
                }
            }
            dataGridView[column, row].Value = cell.Value;
        }

        public static void AddRow()
        {
            int row = Grid.RowsCount;

            for (int i = 0; i < Grid.ColumnsCount; ++i)
            {
                Cell cell = new Cell(i, row);
                Grid.table[i].Add(cell);
                Grid.dictionary.Add(cell.Sys26Name, "");
            }

            Grid.RowsCount++;
        }

        public static void AddColumn()
        {
            int column = Grid.ColumnsCount;

            List<Cell> list = new List<Cell>();

            for(int i = 0; i < Grid.RowsCount; ++i)
            {
                Cell cell = new Cell(column, i);
                list.Add(cell);
                Grid.dictionary.Add(cell.Sys26Name, "");
            }

            Grid.table.Add(list);
            Grid.ColumnsCount++;
        }

        public static Tuple<bool, Cell> DeleteRow() // return false if row is not deleted and cell that cause it
        {
            int row = Grid.RowsCount - 1;

            for (int i = 0; i < Grid.ColumnsCount; ++i)
            {
                Cell cell = Grid.table[i][row];
                if(cell.PointersToThis.Count != 0)
                {
                    return new Tuple<bool, Cell>(false, cell);
                }
                else
                {
                    foreach(Cell reference in cell.ReferencesFromThis)
                    {
                        reference.PointersToThis.Remove(cell);
                    }
                    Grid.dictionary.Remove(cell.Sys26Name);
                    Grid.table[i].Remove(cell);
                }
            }

            Grid.RowsCount--;

            return new Tuple<bool, Cell>(true, new Cell(0, 0));
        }

        public static Tuple<bool, Cell> DeleteColumn() // return false if row is not deleted and cell that cause it
        {
            int column = Grid.ColumnsCount - 1;

            for (int i = 0; i < Grid.RowsCount; ++i)
            {
                Cell cell = Grid.table[column][i];
                if (cell.PointersToThis.Count != 0)
                {
                    return new Tuple<bool, Cell>(false, cell);
                }
                else
                {
                    foreach (Cell reference in cell.ReferencesFromThis)
                    {
                        reference.PointersToThis.Remove(cell);
                    }
                    Grid.dictionary.Remove(cell.Sys26Name);
                }
            }

            Grid.table.Remove(Grid.table[column]);
            Grid.ColumnsCount--;

            return new Tuple<bool, Cell>(true, new Cell(0, 0));
        }
    }
}

