using RssAlphaReader.Model.SubContent;
using System.Collections.Generic;

namespace RssAlphaReader.Model.SubContent
{
    public class RssItem
    {
        public RssPerson Author { get; set; }
        public RssCategory Category { get; set; }
        public RssLink Comments { get; set; }
        public RssText Description { get; set; }
        public RssEnclosure Enclosure { get; set; }
        public List<RssExtension> Extensions { get; set; }
        public RssGuid Guid { get; set; }
        public string LastBuildDate { get; set; }
        public List<RssLink> Link { get; set; }
        public string PubDate { get; set; }
        public RssText Source { get; set; }
        public RssText Title { get; set; }
    }
}