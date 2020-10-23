using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyExcel
{
    public class FileService
    {
        private string _fileName;

        public FileService(string fileName)
        {
            _fileName = fileName;
        }

        public void Open(DataGridView dataGridView)
        {
            using (StreamReader sr = new StreamReader(_fileName))
            {
                int gridColumnsCount = int.Parse(sr.ReadLine());
                int gridRowsCount = int.Parse(sr.ReadLine());

                Grid.setGrid(gridColumnsCount, gridRowsCount);

                dataGridView.ColumnCount = gridColumnsCount;
                for (int i = 0; i < gridColumnsCount; i++)
                {
                    string columnName = Converter26Sys.To26Sys(i);
                    dataGridView.Columns[i].Name = columnName;
                    dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                for (int i = 0; i < gridRowsCount; i++)
                {
                    dataGridView.Rows.Add("");
                    dataGridView.Rows[i].HeaderCell.Value = i.ToString();
                }

                for (int i = 0; i < gridColumnsCount; ++i)
                {
                    for(int j = 0; j < gridRowsCount; ++j)
                    {
                        string sys26Name = sr.ReadLine();
                        string expression = sr.ReadLine();
                        string value = sr.ReadLine();

                        int pointersCount = int.Parse(sr.ReadLine());
                        List<Cell> pointers = new List<Cell>();
                        for(int k = 0; k < pointersCount; ++k)
                        {
                            string pointer = sr.ReadLine();
                            Index indexOfPointer = Converter26Sys.From26Sys(pointer);
                            pointers.Add(Grid.table[indexOfPointer.column][indexOfPointer.row]);
                        }

                        int referencesCount = int.Parse(sr.ReadLine());
                        List<Cell> references = new List<Cell>();
                        for (int k = 0; k < referencesCount; ++k)
                        {
                            string reference = sr.ReadLine();
                            Index indexOfReference = Converter26Sys.From26Sys(reference);
                            references.Add(Grid.table[indexOfReference.column][indexOfReference.row]);
                        }

                        Cell cell = new Cell(i, j, expression, value, sys26Name, pointers, references);
                        Grid.table[i][j] = cell;
                        Grid.dictionary[cell.Sys26Name] = cell.Value;

                        if(cell.Value == "0" && cell.Expression == "")
                        {
                            dataGridView[i, j].Value = "";
                        }
                        else
                        {
                           dataGridView[i, j].Value = cell.Value;
                        }
                    }
                }
            }
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                sw.WriteLine(Grid.ColumnsCount);
                sw.WriteLine(Grid.RowsCount);
                foreach (List<Cell> list in Grid.table)
                {
                    foreach (Cell cell in list)
                    {
                        sw.WriteLine(cell.Sys26Name);
                        sw.WriteLine(cell.Expression);
                        sw.WriteLine(cell.Value);

                        if (cell.PointersToThis.Count == 0)
                        {
                            sw.WriteLine("0");
                        }
                        else
                        {
                            sw.WriteLine(cell.PointersToThis.Count);
                            foreach (Cell pointer in cell.PointersToThis)
                            {
                                sw.WriteLine(pointer.Sys26Name);
                            }
                        }

                        if (cell.ReferencesFromThis.Count == 0)
                        {
                            sw.WriteLine("0");
                        }
                        else
                        {
                            sw.WriteLine(cell.ReferencesFromThis.Count);
                            foreach (Cell reference in cell.ReferencesFromThis)
                            {
                                sw.WriteLine(reference.Sys26Name);
                            }
                        }
                    }
                }
            }
        }
    }
}
