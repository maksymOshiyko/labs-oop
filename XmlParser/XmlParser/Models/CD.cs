using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlParser.Models
{
    [Serializable]
    public class CD
    {
        public CD()
        {

        }

        public CD(string title, string artist, string country,
            string company, string price, string year)
        {
            this.Title = title;
            this.Artist = artist;
            this.Country = country;
            this.Company = company;
            this.Price = price;
            this.Year = year;
        }

        public string Title { get; set; } = "";
        public string Artist { get; set; } = "";
        public string Country { get; set; } = "";
        public string Company { get; set; } = "";
        public string Price { get; set; } = "";
        public string Year { get; set; } = "";
    }
}
