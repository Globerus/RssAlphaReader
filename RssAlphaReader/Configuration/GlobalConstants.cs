using RssAlphaReader.Controller;
using RssAlphaReader.Model.SubContent;
using System;
using System.Collections.Generic;

namespace RssAlphaReader.Configuration
{
    public class GlobalConstants
    {
        public static Dictionary<string, Type> SupportedFormatters { get; set; } = new Dictionary<string, Type>
        {
            { "rss", typeof(Rss20Controller) },
            { "feed", typeof(Atom10Controller) },
            { "atom10", typeof(Atom10Controller) },
            { "atom", typeof(Atom10Controller) },
            { "dc",  typeof(DublinCoreController) },
            { "media",  typeof(MediaRssController) }
        };

        public static Dictionary<string, string> BootstrapMethods { get; set; } = new Dictionary<string, string>
        {
            { "rss", "Load" },
            { "feed", "Load" },
            { "atom10", "LoadExtension" },
            { "atom", "LoadExtension" },
            { "dc", "LoadExtension" },
            { "media", "LoadExtension" }
        };
    }
}
