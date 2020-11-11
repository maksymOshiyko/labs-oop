using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XmlParser.Models
{
    class Catalog
    {
        [XmlAttribute("CD")]
        public List<CD> CDs { get; set; }

        public Catalog()
        {
            CDs = new List<CD>();
        }

        public Catalog(List<CD> cds)
        {
            CDs = cds;
        }
    }
}
