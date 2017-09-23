using RssSyndicationFeed.Configuration.Interface;
using RssSyndicationFeed.Controller;
using RssSyndicationFeed.Model.SubContent;
using System;
using System.Collections.Generic;

namespace RssSyndicationFeed.Configuration
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
            { "contributor", typeof(RssSyndicationPerson) },
            { "coverage", typeof(string) },
            { "creator", typeof(RssSyndicationPerson) },
            { "date", typeof(string) },
            { "description", typeof(RssSyndicationText) },
            { "format", typeof(string) },
            { "identifier", typeof(RssSyndicationGuid) },
            { "language", typeof(string) },
            { "publisher", typeof(RssSyndicationPerson) },
            { "relation", typeof(string) },
            { "rights", typeof(RssSyndicationText) },
            { "source", typeof(string) },
            { "subject", typeof(string) },
            { "title", typeof(RssSyndicationText) },
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
            { "coverage", "" },
            { "creator", "Name" },
            { "date", "" },
            { "description", "Text" },
            { "format", "" },
            { "identifier", "Id" },
            { "language", "" },
            { "publisher", "Name" },
            { "relation", "" },
            { "rights", "Text" },
            { "source", "" },
            { "subject", "" },
            { "title", "Text" },
            { "type", "" }
        };
    }
}
