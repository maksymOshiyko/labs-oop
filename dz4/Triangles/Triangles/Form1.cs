using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double firstSide = Double.Parse(textBox1.Text);
            double secondSide = Double.Parse(textBox2.Text);
            double angle = Double.Parse(textBox3.Text);

            Triangle triangle;

            if (radioButton1.Checked)
            {
                triangle = new RightTriangle(firstSide, secondSide, angle);
            }
            else if (radioButton2.Checked)
            {
                triangle = new IsoscelesTriangle(firstSide, secondSide, angle);
            }
            else
            {
                MessageBox.Show("Оберiть тип трикутника.");
                return;
            }

            label3.Visible = true;
            label3.Text = $"Площа: {triangle.GetArea()}";
            label4.Visible = true;
            label4.Text = $"Периметр: {triangle.GetPerimeter()}";
        }
    }
}
