using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlParser.Models;

namespace XmlParser
{
    class SaxXmlParser : IXmlParserStrategy
    {
        public Catalog Parse(string xmlFile, CD cd)
        {
            var xmlReader = new XmlTextReader(xmlFile);
            xmlReader.WhitespaceHandling = WhitespaceHandling.None;

            List<CD> cds = new List<CD>();
            int elementsCount = 6;
            string title = "";
            string artist = "";
            string country = "";
            string company = "";
            string price = "";
            string year = "";

            while (xmlReader.Read())
            {
                string name;
                string value;
                int i = 0;

                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xmlReader.Name.ToLower() == "cd")
                        {
                            while (i < elementsCount)
                            {
                                xmlReader.Read();
                                name = xmlReader.Name.ToLower();

                                xmlReader.Read();
                                value = xmlReader.Value;
                                xmlReader.Read();

                                if (name == "title" && (cd.Title == "" || cd.Title == value))
                                    title = value;
                                else if (name == "artist" && (cd.Artist == "" || cd.Artist == value))
                                    artist = value;
                                else if (name == "country" && (cd.Country == "" || cd.Country == value))
                                    country = value;
                                else if (name == "company" && (cd.Company == "" || cd.Company == value))
                                    company = value;
                                else if (name == "price" && (cd.Price == "" || cd.Price == value))
                                    price = value;
                                else if (name == "year" && (cd.Year == "" || cd.Year == value))
                                    year = value;

                                i++;
                            }
                        }
                        break;
                    case XmlNodeType.EndElement:
                        if(xmlReader.Name.ToLower() == "cd")
                        {
                            if (title != "" && artist != "" && country != ""
                                && company != "" && price != "" && year != "")
                            {
                                CD cd1 = new CD(title, artist, country, company, price, year);
                                cds.Add(cd1);
                            }

                            title = "";
                            artist = "";
                            country = "";
                            company = "";
                            price = "";
                            year = "";
                        }
                        break;
                }
            }
            xmlReader.Close();

            Catalog catalog = new Catalog() { CDs = cds };
            return catalog;
        }
    }
}












//while (xmlReader.Read())
//{
//    if (xmlReader.HasAttributes)
//    {
//        while (xmlReader.MoveToNextAttribute())
//        {
//            string title = "";
//            string artist = "";
//            string country = "";
//            string company = "";
//            string price = "";
//            string year = "";

//            if (xmlReader.Name.ToLower() == "title" && (cd.Title == "" || xmlReader.Value == cd.Title))
//            {
//                title = xmlReader.Value;

//                xmlReader.MoveToNextAttribute();

//                if (xmlReader.Name.ToLower() == "artist" && (cd.Artist == "" || xmlReader.Value == cd.Artist))
//                {
//                    artist = xmlReader.Value;

//                    xmlReader.MoveToNextAttribute();

//                    if (xmlReader.Name.ToLower() == "country" && (cd.Country == "" || xmlReader.Value == cd.Country))
//                    {
//                        country = xmlReader.Value;

//                        xmlReader.MoveToNextAttribute();

//                        if (xmlReader.Name.ToLower() == "company" && (cd.Company == "" || xmlReader.Value == cd.Company))
//                        {
//                            company = xmlReader.Value;

//                            xmlReader.MoveToNextAttribute();

//                            if (xmlReader.Name.ToLower() == "price" && (cd.Price == "" || xmlReader.Value == cd.Price))
//                            {
//                                price = xmlReader.Value;

//                                xmlReader.MoveToNextAttribute();

//                                if (xmlReader.Name.ToLower() == "year" && (cd.Year == "" || xmlReader.Value == cd.Year))
//                                {
//                                    year = xmlReader.Value;
//                                }
//                            }
//                        }
//                    }
//                }
//            }

//            if (title != "" && artist != "" && country != ""
//            && company != "" && price != "" && year != "")
//            {
//                CD cd1 = new CD(title, artist, country, company, price, year);
//                cds.Add(cd1);
//            }
//        }
//    }
//}