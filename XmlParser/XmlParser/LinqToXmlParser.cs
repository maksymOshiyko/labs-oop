using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlParser.Models;

namespace XmlParser
{
    class LinqToXmlParser : IXmlParserStrategy 
    {
        public Catalog Parse(string xmlFile, CD cd)
        {
           
            List<CD> cds = new List<CD>();

            XDocument xdoc = XDocument.Load(xmlFile);
            foreach (XElement cdElement in xdoc.Element("CATALOG").Elements("CD"))
            {
                string title = "";
                string artist = "";
                string country = "";
                string company = "";
                string price = "";
                string year = "";

                XElement titleElement = cdElement.Element("TITLE");
                XElement artistElement = cdElement.Element("ARTIST");
                XElement countryElement = cdElement.Element("COUNTRY");
                XElement companyElement = cdElement.Element("COMPANY");
                XElement priceElement = cdElement.Element("PRICE");
                XElement yearElement = cdElement.Element("YEAR");

                if (titleElement != null && (titleElement.Value == cd.Title || cd.Title == ""))
                    title = titleElement.Value;
                if (artistElement != null && (artistElement.Value == cd.Artist || cd.Artist == ""))
                    artist = artistElement.Value;
                if (countryElement != null && (countryElement.Value == cd.Country || cd.Country == ""))
                    country = countryElement.Value;
                if (companyElement != null && (companyElement.Value == cd.Company || cd.Company == ""))
                    company = companyElement.Value;
                if (priceElement != null && (priceElement.Value == cd.Price || cd.Price == ""))
                    price = priceElement.Value;
                if (yearElement != null && (yearElement.Value == cd.Year || cd.Year == ""))
                    year = yearElement.Value;

                if (title != "" && artist != "" && country != ""
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
