using RssAlphaReader.Model.SubContent;
using System.Collections.Generic;

namespace RssAlphaReader.Model.SubContent
{
    public class RssSyndicationItem
    {
        public RssSyndicationPerson Author { get; set; }
        public RssSyndicationCategory Category { get; set; }
        public RssSyndicationLink Comments { get; set; }
        public RssSyndicationText Description { get; set; }
        public RssSyndicationEnclosure Enclosure { get; set; }
        public List<RssSyndicationExtension> Extensions { get; set; }
        public RssSyndicationGuid Guid { get; set; }
        public string LastBuildDate { get; set; }
        public List<RssSyndicationLink> Link { get; set; }
        public string PubDate { get; set; }
        public RssSyndicationText Source { get; set; }
        public RssSyndicationText Title { get; set; }
    }
}