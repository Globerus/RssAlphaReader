using RssSyndicationFeed.Configuration;
using RssSyndicationFeed.Model;
using RssSyndicationFeed.Model.SubContent;
using System.Linq;
using System.Xml.Linq;

namespace RssSyndicationFeed.Controller
{
    public class Atom10Controller : BaseController
    {
        public Atom10Controller ()
            : base(new AtomConstants())
        {

        }

        public RssSyndicationFeedContext Load(XDocument document)
        {
            var model = new RssSyndicationFeedContext();

            model = StartLoading(document.Root, model);

            return model;
        }

        public void LoadExtension(RssSyndicationExtension extension, XElement element)
        {
            if(extension.Context == null)
            {
                extension.Context = new RssSyndicationFeedContext();
            }

            extension.Context = DynamicExtensionElementLoad(element, extension.Context);
        }
    }
}
