using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser.Models;

namespace XmlParser
{
    class XmlParserContext
    {
        public IXmlParserStrategy Context { get; set; }

        public XmlParserContext(IXmlParserStrategy strategy)
        {
            Context = strategy;
        }

        public Catalog Parse(string xmlFile, CD cd)
        {
           return Context.Parse(xmlFile, cd);
        }
    }
}
