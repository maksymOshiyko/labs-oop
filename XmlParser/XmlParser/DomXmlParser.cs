using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlParser.Models;

namespace XmlParser
{
    class DomXmlParser : IXmlParserStrategy
    {
        public Catalog Parse(string xmlFile, CD cd)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);
            XmlElement xmlRoot = xmlDoc.DocumentElement;

            List<CD> cds = new List<CD>();

            foreach (XmlNode xmlNode in xmlRoot)
            {
                string title = "";
                string artist = "";
                string country = "";
                string company = "";
                string price = "";
                string year = "";

                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    if (childNode.Name.ToLower() == "title" && (cd.Title == "" || childNode.InnerText == cd.Title))
                        title = childNode.InnerText;
                    else if (childNode.Name.ToLower() == "artist" && (cd.Artist == "" || childNode.InnerText == cd.Artist))
                        artist = childNode.InnerText;
                    else if (childNode.Name.ToLower() == "country" && (cd.Country == "" || childNode.InnerText == cd.Country))
                        country = childNode.InnerText;
                    else if (childNode.Name.ToLower() == "company" && (cd.Company == "" || childNode.InnerText == cd.Company))
                        company = childNode.InnerText;
                    else if (childNode.Name.ToLower() == "price" && (cd.Price == "" || childNode.InnerText == cd.Price))
                        price = childNode.InnerText;
                    else if (childNode.Name.ToLower() == "year" && (cd.Year == "" || childNode.InnerText == cd.Year))
                        year = childNode.InnerText;
                }

                if(title != "" && artist != "" && country != ""
                   && company != "" && price != "" && year != "")
                {
                    CD cd1 = new CD(title, artist, country, company, price, year);
                    cds.Add(cd1);
                }
            }
            
            Catalog catalog = new Catalog() { CDs = cds };
            return catalog;
        }
    }
}
