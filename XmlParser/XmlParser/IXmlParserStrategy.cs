using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser.Models;

namespace XmlParser
{
    interface IXmlParserStrategy
    {
        Catalog Parse(string xmlFile, CD cd);
    }
}
