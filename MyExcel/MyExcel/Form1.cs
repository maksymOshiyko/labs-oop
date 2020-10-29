using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyExcel
{
    public partial class Form1 : Form
    {
        private static int _savesCount;

        public Form1()
        {
            InitializeComponent();

            int initColumns = 10;
            int initRows = 10;
            InitializeDataGridView(initColumns, initRows);
        }

        public void InitializeDataGridView(int columns, int rows)
        {
            dataGridView1.Width = 1880;
            dataGridView1.Height = 850;
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.RowHeadersVisible = true;
            dataGridView1.ColumnCount = columns;

            for (int i = 0; i < columns; i++)
            {
                string columnName = Converter26Sys.To26Sys(i);
                dataGridView1.Columns[i].Name = columnName;
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Rows.Add("");
                dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
            }
            dataGridView1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            dataGridView1.AllowUserToAddRows = false;

            Grid.setGrid(columns, rows);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int column = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;

            string expression = Grid.table[column][row].Expression;
            string value = Grid.table[column][row].Value;

            textBox.Text = expression;
            textBox.Focus();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            bool error = false;
            int column = dataGridView1.SelectedCells[0].ColumnIndex;
            int row = dataGridView1.SelectedCells[0].RowIndex;
            string expression = textBox.Text;

            if (expression == "")
            {
                return;
            }

            if (textBox.Text[0] == '=')
            {
                MessageBox.Show("You dont need to write '='. Check \"Help\" for more info.");
                return;
            }

            try
            {
                Grid.ChangeCellWithPointers(column, row, expression, dataGridView1);
            }
            catch (DivideByZeroException)
            {
                error = true;
                MessageBox.Show("Division by zero.", "Error");
            }
            catch (ArgumentException ex)
            {
                error = true;
                MessageBox.Show("Invalid expression.", "Error");
            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show(ex.Message, "Error");
            }

            if (error)
            {
                Grid.ChangeCellWithPointers(column, row, "", dataGridView1);
            }
            
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();

            if(dataGridView1.Columns.Count == 0)
            {
                MessageBox.Show("Add a column firstly.");
                return;
            }
            
            int i = dataGridView1.Rows.Add(row);
            dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
            Grid.AddRow();
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the last row?",
                "Row deleting", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }
            
            if (Grid.RowsCount == 1)
            {
                MessageBox.Show("You cant delete the last row.");
                return;
            }

            Tuple<bool, Cell> tuple = Grid.DeleteRow(); 

            if (!tuple.Item1)
            {
                Cell cell = tuple.Item2;
                StringBuilder buider = new StringBuilder();

                foreach (Cell pointer in cell.PointersToThis)
                {
                    buider.Append(pointer.Sys26Name + '\n');
                }

                MessageBox.Show($"You cant delete this row because other cells use cells in this row.\n" +
                    $"Cell that cause it: {cell.Sys26Name}\n" +
                    $"Fix these cells to delete row:" +
                    $"\n{buider.ToString()}");
                return;
            }
            else
            {
                DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
                dataGridView1.Rows.Remove(row);
            }
        }

        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();

            int i = dataGridView1.Columns.Add(column);
            dataGridView1.Columns[i].HeaderCell.Value = Converter26Sys.To26Sys(i);
            Grid.AddColumn();
        }

        private void buttonDeleteColumn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete the last column?",
                "Column deleting", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if (Grid.ColumnsCount == 1)
            {
                MessageBox.Show("You cant delete the last column.");
                return;
            }

            Tuple<bool, Cell> tuple = Grid.DeleteColumn();

            if (!tuple.Item1)
            {
                Cell cell = tuple.Item2;
                StringBuilder buider = new StringBuilder();

                foreach (Cell pointer in cell.PointersToThis)
                {
                    buider.Append(pointer.Sys26Name + '\n');
                }

                MessageBox.Show($"You cant delete this column because other cells use cells in this column.\n" +
                    $"Cell that cause it: {cell.Sys26Name}\n" +
                    $"Fix these cells to delete column:" +
                    $"\n{buider.ToString()}");
                return;
            }
            else
            {
                DataGridViewColumn column = dataGridView1.Columns[dataGridView1.Columns.Count - 1];
                dataGridView1.Columns.Remove(column);
            }

        }

        private void toolStripMenuHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello!\n" +
                "You can use my application to store your data.\n" +
                "The operations you can use with cells:\n" +
                "addition - +\n" +
                "subtruction - -\n" +
                "division - /\n" +
                "muptiplication - -\n" +
                "exponentiation - ^\n" +
                "find max of n numbers, where n >= 1 - MMAX(x1,x2,...,xn)\n" +
                "find min of n numbers, where n >= 1 - MMIN(x1,x2,...,xn)\n" +
                "P.S. You dont need to write '=' at the beginning of expression.", "Help");
        }

        private void toolStripMenuOpen_Click(object sender, EventArgs e)
        {
            if(_savesCount == 0)
            {
                DialogResult dialogResult = MessageBox.Show("You dont save your grid." +
                    "Are your sure you want to open another?(your data can be lost)",
                "Opening grid", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "TXT File|*.txt";
            openFileDialog.Title = "Grid opening";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;

                Grid.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                FileService service = new FileService(fileName);
                try
                {
                    service.Open(dataGridView1);
                }
                catch (Exception)
                {
                    Grid.Clear();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();
                    MessageBox.Show("Invalid file.", "Error");
                }
            }
            _savesCount = 0;
        }

        private void toolStripMenuSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "TXT File|*.txt";
            saveFileDialog.Title = "Grid saving";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                FileService service = new FileService(fileName);
                service.Save();
                _savesCount++;
                MessageBox.Show("Your grid was saved.", "Saving completed");
                _savesCount = 0;
            }
            else
                return;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure that you want to exit" + (_savesCount == 0 ? " without saving?" : "?"), 
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
