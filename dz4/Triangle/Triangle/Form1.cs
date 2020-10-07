using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double firstSide = Double.Parse(textBox1.Text);
            double secondSide = Double.Parse(textBox2.Text);
            double thirdSide = Double.Parse(textBox3.Text);

            Triangle triangle;

            if(firstSide == secondSide && secondSide == thirdSide)
            {
                triangle = new EquilateralTriangle(firstSide);
            }
            else
            {
                triangle = new Triangle(firstSide, secondSide, thirdSide);
            }

            label2.Text = $"Площа: {triangle.Area}\n\nКут 1: {triangle.FirstAngle}\n\n" +
                          $"Кут 2: {triangle.SecondAngle}\n\nКут 3: {triangle.ThirdAngle}";


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
