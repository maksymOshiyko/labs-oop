using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Xsl;
using XmlParser.Models;

namespace XmlParser
{
    public partial class Form1 : Form
    {
        private string _xmlFile;
        private readonly string _xslFile = @"E:\github\labs-oop\XmlParser\XmlParser\Converter.xslt";
        private readonly string _htmlFile = @"E:\github\labs-oop\XmlParser\XmlParser\Catalog.html";
        private XmlParserContext _xmlContext;
        private Catalog _fullCatalog;
        private Catalog _filteredCatalog;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2Clear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear all?\n" +
                "You should open XML file again.", "Warning", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            richTextBox1.Clear();

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();

            _fullCatalog = null;
            _filteredCatalog = null;
        }

        private void button4Open_Click(object sender, EventArgs e)
        {
            if(!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Please, choose the XML parse type firstly.", "Oops!");
                return;
            }

            IXmlParserStrategy xmlParser = null;

            if (radioButton1.Checked)
            {
                xmlParser = new DomXmlParser();
            }
            else if (radioButton2.Checked)
            {
                xmlParser = new SaxXmlParser();
            }
            else
            {
                xmlParser = new LinqToXmlParser();
            }

            _xmlContext = new XmlParserContext(xmlParser);

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "XML File|*.xml";
            openFileDialog.Title = "Xml file opening";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _xmlFile = openFileDialog.FileName;

                _fullCatalog = _xmlContext.Parse(_xmlFile, new CD());
                FillRichTextBox(_fullCatalog);
                FillComboBoxes(_fullCatalog);
            }
        }

        private void FillRichTextBox(Catalog catalog)
        {
            StringBuilder builder = new StringBuilder();
            foreach(CD cd in catalog.CDs)
            {
                builder.Append($"Title: {cd.Title}\n" +
                               $"Artist: {cd.Artist}\n" +
                               $"Country: {cd.Country}\n" +
                               $"Company: {cd.Company}\n" +
                               $"Price: {cd.Price}\n" +
                               $"Year: {cd.Year}\n\n");
            }
            richTextBox1.Text = builder.ToString();
        }

        private void FillComboBoxes(Catalog catalog)
        {
            foreach(CD cd in catalog.CDs)
            {
                if(!comboBox1.Items.Contains(cd.Title))
                    comboBox1.Items.Add(cd.Title);
                if(!comboBox2.Items.Contains(cd.Artist))
                    comboBox2.Items.Add(cd.Artist);
                if(!comboBox3.Items.Contains(cd.Country))
                    comboBox3.Items.Add(cd.Country);
                if(!comboBox4.Items.Contains(cd.Company))
                    comboBox4.Items.Add(cd.Company);
                if(!comboBox5.Items.Contains(cd.Price))
                    comboBox5.Items.Add(cd.Price);
                if(!comboBox6.Items.Contains(cd.Year))
                    comboBox6.Items.Add(cd.Year);
            }
        }

        private void button1Filter_Click_1(object sender, EventArgs e)
        {
            if (_fullCatalog == null)
            {
                MessageBox.Show("Please, open the XML file firstly", "Oops!");
                return;
            }

            IXmlParserStrategy xmlParser = null;

            if (radioButton1.Checked)
            {
                xmlParser = new DomXmlParser();
            }
            else if (radioButton2.Checked)
            {
                xmlParser = new SaxXmlParser();
            }
            else
            {
                xmlParser = new LinqToXmlParser();
            }

            _xmlContext = new XmlParserContext(xmlParser);

            CD cdParams = FindFilter();

            _filteredCatalog = _xmlContext.Parse(_xmlFile, cdParams);

            FillRichTextBox(_filteredCatalog);
        }




        private CD FindFilter()
        {
            CD cd = new CD();
            try
            {
                if (checkBox1.Checked)
                {
                    cd.Title = comboBox1.Text;
                }
                if (checkBox2.Checked)
                {
                    cd.Artist = comboBox2.Text;
                }
                if (checkBox3.Checked)
                {
                    cd.Country = comboBox3.Text;
                }
                if (checkBox4.Checked)
                {
                    cd.Company = comboBox4.Text;
                }
                if (checkBox5.Checked)
                {
                    cd.Price = comboBox5.Text;
                }
                if (checkBox6.Checked)
                {
                    cd.Year = comboBox6.Text;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("If you choose checkbox you should choose concrete name to filter.", "Error");
            }

            return cd;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure that you want to exit?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void button3HTML_Click(object sender, EventArgs e)
        {
            if (_fullCatalog == null)
            {
                MessageBox.Show("Please, open the XML file firstly", "Oops!");
                return;
            }

            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(_xslFile);
            xslt.Transform(_xmlFile, _htmlFile);

            MessageBox.Show("XML file was successfully transformed.", "Success");
        }
    }
}
