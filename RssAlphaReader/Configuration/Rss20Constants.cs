using RssAlphaReader.Configuration.Interface;
using RssAlphaReader.Controller;
using RssAlphaReader.Model.SubContent;
using System;
using System.Collections.Generic;

namespace RssAlphaReader.Configuration
{
    public class Rss20Constants : IConstants
    {
        public Dictionary<string, Type> AttributeToType { get; set; } = new Dictionary<string, Type>
        {
            { "domain", typeof(string) },
            { "length", typeof(string) },
            { "type", typeof(string) },
            { "url", typeof(RssSyndicationLink) },
            { "isPermaLink", typeof(string) }
        };

        public Dictionary<string, string> AttributeToProperty { get; set; } = new Dictionary<string, string>
        {
            //enclosure
            { "domain", "Scheme" },
            { "length", "Length" },
            { "type", "Type" },
            { "url", "Url" },       //source
            { "isPermaLink", "IsPermaLink" }
        };

        public Dictionary<string, string> AttributeValueToProperty { get; set; } = new Dictionary<string, string>
        {
            { "url", "Href" }
        };

        public Dictionary<string, Type> ElementToType { get; set; } = new Dictionary<string, Type>
        {
            { "author", typeof(RssSyndicationPerson) },
            { "category", typeof(RssSyndicationCategory) },
            { "comments", typeof(RssSyndicationLink) },
            { "copyright", typeof(RssSyndicationText) },
            { "description", typeof(RssSyndicationText) },
            { "enclosure", typeof(RssSyndicationEnclosure) },
            { "generator", typeof(string) },
            { "guid", typeof(RssSyndicationGuid) },
            { "height", typeof(string) },
            { "image", typeof(RssSyndicationImage) },
            { "item", typeof(RssSyndicationItem) },
            { "language", typeof(string) },
            { "lastBuildDate", typeof(string) },
            { "link", typeof(RssSyndicationLink) },
            { "managingEditor", typeof(RssSyndicationPerson) },
            { "pubDate", typeof(string) },
            { "source", typeof(RssSyndicationText) },
            { "title", typeof(RssSyndicationText) },
            { "ttl", typeof(string) },
            { "url", typeof(RssSyndicationLink) },
            { "webMaster", typeof(RssSyndicationPerson) },
            { "width", typeof(string) }
        };

        public Dictionary<string, string> ElementToProperty { get; set; } = new Dictionary<string, string>
        {
            { "author", "Author" },
            { "category", "Category" },
            { "comments", "Comments" },
            { "copyright", "Copyright" },
            { "description", "Description" },
            { "enclosure", "Enclosure" },
            { "generator", "Generator" },
            { "guid", "Guid" },
            { "height", "Height" },
            { "image", "Image" },
            { "item", "Items" },
            { "language", "Language" },
            { "lastBuildDate", "LastBuildDate" },
            { "link", "Link" },
            { "managingEditor", "ManagingEditor" },
            { "pubDate", "PubDate" },
            { "source", "Source" },
            { "title", "Title" },
            { "ttl", "Ttl" },
            { "url", "Url" },
            { "webMaster", "WebMaster" },
            { "width", "Width" }
        };

        public Dictionary<string, string> ElementValueToProperty { get; set; } = new Dictionary<string, string>
        {
            { "author", "Email" },
            { "category", "Label" },
            { "comments", "Href" },
            { "copyright", "Text" },
            { "description", "Text" },
            { "guid", "Id" },
            { "link", "Href" },
            { "managingEditor", "Email" },
            { "source", "Text" },
            { "title", "Text" },
            { "url", "Href" },
            { "webMaster", "Email" }
        };
    }
}
