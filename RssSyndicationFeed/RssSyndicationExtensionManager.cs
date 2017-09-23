using RssSyndicationFeed.Configuration;
using RssSyndicationFeed.Model.SubContent;
using System;
using System.Linq;
using System.Xml.Linq;

namespace RssSyndicationFeed
{
    public class RssSyndicationExtensionManager
    {
        public static RssSyndicationExtension Create(XElement element)
        {
            var rssSyndicationExtension = new RssSyndicationExtension();

            rssSyndicationExtension.Namespace = element.Name.NamespaceName;
            rssSyndicationExtension.Name = element.GetPrefixOfNamespace(rssSyndicationExtension.Namespace);

            return rssSyndicationExtension;
        }

        public static void AddMetadata(RssSyndicationExtension extension, XElement element)
        {
            var formatter = GlobalConstants.SupportedFormatters
                                           .Where(e => e.Key == extension.Name)
                                           .Select(e => e.Value)
                                           .FirstOrDefault();

            if(formatter != null)
            {
                var formatterObject = Activator.CreateInstance(formatter);

                var bootstrapper = GlobalConstants.BootstrapMethods
                                                  .Where(e => e.Key == extension.Name)
                                                  .Select(e => e.Value)
                                                  .FirstOrDefault();

                formatter.GetMethod(bootstrapper)
                         .Invoke(formatterObject, new object[] { extension, element });
            }

            extension.Description = element.ToString();

        }
    }
}
