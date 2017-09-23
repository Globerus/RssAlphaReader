using RssSyndicationFeed.Configuration;
using RssSyndicationFeed.Model;
using RssSyndicationFeed.Model.SubContent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssSyndicationFeed.Controller
{
    public class Rss20Controller : BaseController
    {
        public Rss20Controller()
            :   base(new Rss20Constants())
        {

        }

        public RssSyndicationFeedContext Load(XDocument document)
        {
            var model = new RssSyndicationFeedContext();
            var channel = document.Root.Elements();

            foreach (var element in channel.Elements())
            {
                if (string.IsNullOrEmpty(element.Name.NamespaceName))
                {
                    model = DynamicElementLoad(element, model);
                }
                else
                {
                    model = DynamicExtensionLoad(element, model);
                }
            }

            return model;
        }
    }
}
