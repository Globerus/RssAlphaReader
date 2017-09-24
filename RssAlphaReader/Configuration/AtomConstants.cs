using RssAlphaReader.Configuration.Interface;
using RssAlphaReader.Controller;
using RssAlphaReader.Model.SubContent;
using System;
using System.Collections.Generic;

namespace RssAlphaReader.Configuration
{
    public class AtomConstants : IConstants
    {
        public Dictionary<string, Type> AttributeToType { get; set; } = new Dictionary<string, Type>
        {
            { "href", typeof(string) },
            { "label", typeof(string) },
            { "length", typeof(string) },
            { "rel", typeof(string) },
            { "scheme", typeof(string) },
            { "src", typeof(string) },
            { "term", typeof(string) },
            { "title", typeof(RssText) },
            { "type", typeof(string) }
        };

        public Dictionary<string, string> AttributeToProperty { get; set; } = new Dictionary<string, string>
        {
            { "href", "Href" },
            { "label", "Label" },
            { "length", "Length" },
            { "rel", "Rel" },
            { "scheme", "Scheme" },
            { "src", "Src" },
            { "term", "Term" },
            { "title", "Title" },
            { "type", "Type" }
        };

        public Dictionary<string, string> AttributeValueToProperty { get; set; } = new Dictionary<string, string>
        {
            { "title", "Text" }
        };

        public Dictionary<string, Type> ElementToType { get; set; } = new Dictionary<string, Type>
        {
            { "author", typeof(RssPerson) },
            { "category", typeof(RssCategory) },
            { "contributor", typeof(RssPerson) },
            { "email", typeof(string) },
            { "entry", typeof(RssItem) },
            { "id", typeof(RssGuid) },
            { "icon", typeof(string) },
            { "link", typeof(RssLink) },
            { "logo", typeof(RssLink) },
            { "name", typeof(string) },
            { "published", typeof(string) },
            { "rights", typeof(RssText) },
            { "subtitle", typeof(string) },
            { "summary", typeof(RssText) },
            { "title", typeof(RssText) },
            { "updated", typeof(string) },
            { "uri", typeof(RssLink) }
        };

        public Dictionary<string, string> ElementToProperty { get; set; } = new Dictionary<string, string>
        {
            { "author", "Author" },
            { "category", "Category" },
            { "contributor", "ManagingEditor" },
            { "email", "Email" },
            { "entry", "Items" },
            { "id", "Guid" },
            { "icon", "Icon" },
            { "link", "Link" },
            { "logo", "Logo" },
            { "name", "Name" },
            { "published", "PubDate" },
            { "rights", "Copyright" },
            { "subtitle", "Subtitle" },
            { "summary", "Description" },
            { "title", "Title" },
            { "updated", "LastBuildDate" },
            { "uri", "Url" }
        };

        public Dictionary<string, string> ElementValueToProperty { get; set; } = new Dictionary<string, string>
        {
            //{ "email", "" },
            { "id", "Id" },
            //{ "icon", "" },
            { "logo", "Href" },
            //{ "name", "" },
            //{ "published", "" },
            { "rights", "Text" },
            //{ "subtitle", "" },
            { "summary", "Text" },
            { "title", "Text" },
            //{ "updated", "" },
            { "uri", "Href" }
        };
    }
}
