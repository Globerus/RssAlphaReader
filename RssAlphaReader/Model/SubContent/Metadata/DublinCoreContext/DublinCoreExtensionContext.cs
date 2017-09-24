using RssAlphaReader.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssAlphaReader.Model.SubContent.Metadata.DublinCoreContext
{
    public class DublinCoreExtension : IModel
    {
        public RssPerson Contributor { get; set; }
        public string Coverage { get; set; }
        public RssPerson Creator { get; set; }
        public string Date { get; set; }
        public RssText Description { get; set; }
        public string Format { get; set; }
        public RssGuid Identifier { get; set; }
        public string Language { get; set; }
        public RssPerson Publisher { get; set; }
        public string Relation { get; set; }
        public RssText Rights { get; set; }
        public string Source { get; set; }
        public string Subject { get; set; }
        public RssText Title { get; set; }
        public string Type { get; set; }
    }
}
