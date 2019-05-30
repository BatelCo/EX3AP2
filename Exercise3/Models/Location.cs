using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Exercise3.Models
{
    public class Location
    {
        public string Xcordinate { get; set; }
        public string Ycordinate { get; set; }

        // write the location to xml
        public void ToXml(XmlWriter writer)
        {
            writer.WriteStartElement("Location");
            writer.WriteElementString("Xcordinate", this.Xcordinate);
            writer.WriteElementString("Ycordinate", this.Ycordinate);
            writer.WriteEndElement();
            
        }
    }
}