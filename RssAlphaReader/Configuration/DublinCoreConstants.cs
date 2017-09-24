using RssAlphaReader.Configuration.Interface;
using RssAlphaReader.Model.SubContent;
using System;
using System.Collections.Generic;

namespace RssAlphaReader.Configuration
{
    public class DublinCoreConstants : IConstants
    {
        public Dictionary<string, Type> AttributeToType { get; set; } = new Dictionary<string, Type>
        {

        };

        public Dictionary<string, string> AttributeToProperty { get; set; } = new Dictionary<string, string>
        {

        };

        public Dictionary<string, string> AttributeValueToProperty { get; set; } = new Dictionary<string, string>
        {

        };

        public Dictionary<string, Type> ElementToType { get; set; } = new Dictionary<string, Type>
        {
            { "contributor", typeof(RssPerson) },
            { "coverage", typeof(string) },
            { "creator", typeof(RssPerson) },
            { "date", typeof(string) },
            { "description", typeof(RssText) },
            { "format", typeof(string) },
            { "identifier", typeof(RssGuid) },
            { "language", typeof(string) },
            { "publisher", typeof(RssPerson) },
            { "relation", typeof(string) },
            { "rights", typeof(RssText) },
            { "source", typeof(string) },
            { "subject", typeof(string) },
            { "title", typeof(RssText) },
            { "type", typeof(string) }
        };

        public Dictionary<string, string> ElementToProperty { get; set; } = new Dictionary<string, string>
        {
            { "contributor", "Contributor" },
            { "coverage", "Coverage" },
            { "creator", "Creator" },
            { "date", "Date" },
            { "description", "Description" },
            { "format", "Format" },
            { "identifier", "Identifier" },
            { "language", "Language" },
            { "publisher", "Publisher" },
            { "relation", "Relation" },
            { "rights", "Rights" },
            { "source", "Source" },
            { "subject", "Subject" },
            { "title", "Title" },
            { "type", "Type" }
        };

        public Dictionary<string, string> ElementValueToProperty { get; set; } = new Dictionary<string, string>
        {
            { "contributor", "Name" },
            { "creator", "Name" },
            { "description", "Text" },
            { "identifier", "Id" },
            { "publisher", "Name" },
            { "rights", "Text" },
            { "title", "Text" }
        };
    }
}
