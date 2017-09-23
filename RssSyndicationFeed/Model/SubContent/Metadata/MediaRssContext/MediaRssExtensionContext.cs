using RssSyndicationFeed.Model.Interface;
using RssSyndicationFeed.Model.SubContent.Metadata.MediaRssContext.SubContent;
using System.Collections.Generic;

namespace RssSyndicationFeed.Model.SubContent.Metadata.MediaRssContext
{
    public class MediaRssExtensionContext : IContext
    {
        public RssSyndicationCategory Category { get; set; }
        public MediaRssCopyright Copyright { get; set; }
        public MediaRssCredit Credit { get; set; }
        public RssSyndicationText Description { get; set; }
        public List<MediaRssContent> Group { get; set; }
        public MediaRssHash Hash { get; set; }
        public string Keywords { get; set; }
        public MediaRssPlayer Player { get; set; }
        public MediaRssRating Rating { get; set; }
        public MediaRssText Text { get; set; }
        public MediaRssThumbnails Thumbnails { get; set; }
        public RssSyndicationText Title { get; set; }
    }
}
