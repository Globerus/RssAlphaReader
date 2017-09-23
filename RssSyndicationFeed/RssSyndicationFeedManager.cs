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
            RssSyndicationFeedContext rssSyndicationFeed = new RssSyndicationFeedContext();

            var document = XDocument.Load(xml);
            var root = document.Root;

            var formatter = GlobalConstants.SupportedFormatters
                                           .Where(e => e.Key == root.Name.LocalName)
                                           .Select(e => e.Value)
                                           .FirstOrDefault();
            if (formatter != null)
            {
                var formatterObject = Activator.CreateInstance(formatter);

                var bootstrapper = GlobalConstants.BootstrapMethods
                                                  .Where(e => e.Key == root.Name.LocalName)
                                                  .Select(e => e.Value)
                                                  .FirstOrDefault();

                rssSyndicationFeed = formatter.GetMethod(bootstrapper)
                                              .Invoke(formatterObject, new[] { document }) as RssSyndicationFeedContext;
            }

            return rssSyndicationFeed;
        }
    }
}
