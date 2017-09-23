using RssSyndicationFeed.Configuration.Interface;
using RssSyndicationFeed.Controller;
using RssSyndicationFeed.Model.SubContent;
using RssSyndicationFeed.Model.SubContent.Metadata.MediaRssContext.SubContent;
using System;
using System.Collections.Generic;

namespace RssSyndicationFeed.Configuration
{
    public class MediaRssConstants : IConstants
    {
        public Dictionary<string, Type> AttributeToType { get; set; } = new Dictionary<string, Type>
        {
            { "algo", typeof(string) },
            { "bitrate", typeof(string) },
            { "channels", typeof(string) },
            { "duration", typeof(string) },
            { "end", typeof(string) },
            { "expression", typeof(string) },
            { "fileSize", typeof(string) },
            { "framerate", typeof(string) },
            { "height", typeof(string) },
            { "isDefault", typeof(string) },
            { "lang", typeof(string) },
            { "medium", typeof(string) },
            { "role", typeof(string) },
            { "samplingRate", typeof(string) },
            { "scheme", typeof(string) },
            { "start", typeof(string) },
            { "time", typeof(string) },
            { "type", typeof(string) },
            { "url", typeof(RssSyndicationLink) },
            { "width", typeof(string) }
        };

        public Dictionary<string, string> AttributeToProperty { get; set; } = new Dictionary<string, string>
        {
            //media:content
            { "bitrate", "Bitrate" },
            { "channels", "Channels" },
            { "duration", "Duration" },
            { "expression", "Expression" },
            { "fileSize", "FileSize" },
            { "framerate", "Framerate" },
            { "height", "Height" },     //media:thumbnails, media:player
            { "isDefault", "IsDefault" },
            { "lang", "Language" },     //media:text
            { "medium", "Medium" },
            { "samplingrate", "Samplingrate" },
            { "url", "Url" },   //media:thumbnails, media:player, media:copyright
            { "type", "Type" },     //media:title, media:description, media:text
            { "width", "Width" },   //media:thumbnails, media:player
            //media:rating
            { "scheme", "Scheme" },     //media:category, media:credit
            //media:thumbnails
            { "time", "Time" },
            //media:category
            { "label", "Label" },
            //media:hash
            { "algo", "Algo" },
            //media:credit
            { "role", "Role" },
            //media:text
            { "end", "End" },
            { "start", "Start" }
        };

        public Dictionary<string, string> AttributeValueToProperty { get; set; } = new Dictionary<string, string>
        {
            { "algo", "" },
            { "bitrate", "" },
            { "channels", "" },
            { "duration", "" },
            { "end", "" },
            { "expression", "" },
            { "fileSize", "" },
            { "framerate", "" },
            { "height", "" },
            { "isDefault", "" },
            { "lang", "" },
            { "medium", "" },
            { "role", "" },
            { "samplingRate", "" },
            { "scheme", "" },
            { "start", "" },
            { "time", "" },
            { "type", "" },
            { "url", "Href" },
            { "width", "" }
        };

        public Dictionary<string, Type> ElementToType { get; set; } = new Dictionary<string, Type>
        {
            { "category", typeof(RssSyndicationCategory) },
            { "content", typeof(MediaRssContent) },
            { "copyright", typeof(MediaRssCopyright) },
            { "credit", typeof(MediaRssCredit) },
            { "description", typeof(RssSyndicationText) },
            { "hash", typeof(MediaRssHash) },
            { "keywords", typeof(string) },
            { "player", typeof(MediaRssPlayer) },
            { "rating", typeof(MediaRssRating) },
            { "text", typeof(MediaRssText) },
            { "thumbnails", typeof(MediaRssThumbnails) },
            { "title", typeof(RssSyndicationText) }
        };

        public Dictionary<string, string> ElementToProperty { get; set; } = new Dictionary<string, string>
        {
            { "category", "Category" },
            { "content", "Group" },
            { "copyright", "Copyright" },
            { "credit", "Credit" },
            { "description", "Description" },
            { "group", "Group" },
            { "hash", "Hash" },
            { "keywords", "Keywords" },
            { "player", "Player" },
            { "rating", "Rating" },
            { "text", "Text" },
            { "title", "Title" },
            { "thumbnails", "Thumbnails" }
        };

        public Dictionary<string, string> ElementValueToProperty { get; set; } = new Dictionary<string, string>
        {
            { "category", "Label" },
            { "copyright", "Text" },
            { "credit", "Text" },
            { "description", "Text" },
            { "hash", "Text" },
            { "keywords", "" },
            { "rating", "Text" },
            { "text", "Text" },
            { "title", "Text" }
        };
    }
}
