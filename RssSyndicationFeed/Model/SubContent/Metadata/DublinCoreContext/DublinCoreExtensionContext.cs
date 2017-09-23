using RssSyndicationFeed.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssSyndicationFeed.Model.SubContent.Metadata.DublinCoreContext
{
    public class DublinCoreExtensionContext : IContext
    {
        public RssSyndicationPerson Contributor { get; set; }
        public string Coverage { get; set; }
        public RssSyndicationPerson Creator { get; set; }
        public string Date { get; set; }
        public RssSyndicationText Description { get; set; }
        public string Format { get; set; }
        public RssSyndicationGuid Identifier { get; set; }
        public string Language { get; set; }
        public RssSyndicationPerson Publisher { get; set; }
        public string Relation { get; set; }
        public RssSyndicationText Rights { get; set; }
        public string Source { get; set; }
        public string Subject { get; set; }
        public RssSyndicationText Title { get; set; }
        public string Type { get; set; }
    }
}
