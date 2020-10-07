using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Figure f;

            if (radioButton1.Checked)
            {
                f = new Triangle(Double.Parse(textBox1.Text),
                    Double.Parse(textBox2.Text), Double.Parse(textBox3.Text));
            }
            else if (radioButton2.Checked)
            {
                f = new Square(Double.Parse(textBox1.Text));
            }
            else if (radioButton3.Checked)
            {
                f = new Rectangle(Double.Parse(textBox1.Text),
                                            Double.Parse(textBox2.Text));
            }
            else if (radioButton4.Checked)
            {
                f = new Circle(Double.Parse(textBox1.Text));  
            }
            else 
            {
                f = new Rhombus(Double.Parse(textBox1.Text),
                    Double.Parse(textBox2.Text));
            }
            label3.Visible = true;
            label4.Visible = true;
            label3.Text = $"Площа: {Math.Round(f.GetArea(), 2)}";
            label4.Text = $"Периметр: {Math.Round(f.GetPerimeter(), 2)}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                TriangleChecked();
            } 
            else if (radioButton2.Checked)
            {
                SquareChecked();
            } 
            else if (radioButton3.Checked)
            {
                RectangleChecked();
            }
            else if (radioButton4.Checked)
            {
                CircleChecked();
            }
            else if (radioButton5.Checked)
            {
                RhombusChecked();
            }
            else
            {
                MessageBox.Show("Не обрана фiгура.");
            }
                
        }

        private void TriangleChecked()
        {
            label2.Text = "Введiть необхiднi данi(3 сторони): ";
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
        }

        private void SquareChecked()
        {
            label2.Text = "Введiть необхiднi данi(сторону): ";
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = true;
        }

        private void RectangleChecked()
        {
            label2.Text = "Введiть необхiднi данi(2 сторони): ";
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            button1.Visible = true;   
        }

        private void CircleChecked()
        {
            label2.Text = "Введiть необхiднi данi(радiус): ";
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = true;
        }

        private void RhombusChecked()
        {
            label2.Text = "Введiть необхiднi данi(2 дiагоналi): ";
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            button1.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
