using RssSyndicationFeed.Model.Interface;
using RssSyndicationFeed.Model.SubContent;
using System.Collections.Generic;

namespace RssSyndicationFeed.Model
{
    public class RssSyndicationFeedContext : IContext
    {
        public RssSyndicationPerson Author { get; set; }
        public RssSyndicationText Description { get; set; }
        public RssSyndicationCategory Category { get; set; }
        public RssSyndicationText Content { get; set; }
        public RssSyndicationText Copyright { get; set; }
        public List<RssSyndicationExtension> Extensions { get; set; }
        public string Generator { get; set; }
        public RssSyndicationGuid Guid { get; set; }
        public string Icon { get; set; }
        public RssSyndicationImage Image { get; set; }
        public List<RssSyndicationItem> Items { get; set; }
        public string Language { get; set; }
        public string LastBuildDate { get; set; }
        public List<RssSyndicationLink> Link { get; set; }
        public RssSyndicationLink Logo { get; set; }
        public RssSyndicationPerson ManagingEditor { get; set; }
        public string PubDate { get; set; }
        public string Subtitle { get; set; }
        public RssSyndicationText Title { get; set; }
        public string Ttl { get; set; }
        public RssSyndicationPerson WebMaster { get; set; }
    }
}