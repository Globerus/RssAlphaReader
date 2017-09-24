using RssSyndicationFeed.Configuration;
using RssSyndicationFeed.Model;
using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace RssSyndicationFeed
{
    public class RssSyndicationFeedManager
    {
        public static RssSyndicationFeedContext Load(XmlReader xml)
        {
            var document = XDocument.Load(xml);
            var root = document.Root;

            Type formatter;

            if (!GlobalConstants.SupportedFormatters.TryGetValue(root.Name.LocalName, out formatter))
            {
                return null;
            }

            var formatterObject = Activator.CreateInstance(formatter);

            var bootstrapper = GlobalConstants.BootstrapMethods
                                              .Where(e => e.Key == root.Name.LocalName)
                                              .Select(e => e.Value)
                                              .FirstOrDefault();

            var feed = formatter.GetMethod(bootstrapper)
                                .Invoke(formatterObject, new[] { document });

            return feed as RssSyndicationFeedContext;
        }
    }
}
