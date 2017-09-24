using RssAlphaReader.Configuration;
using RssAlphaReader.Model.SubContent;
using RssAlphaReader.Model.SubContent.Metadata.DublinCoreContext;
using System.Xml.Linq;

namespace RssAlphaReader.Controller
{
    public class DublinCoreController : BaseController
    {
        public DublinCoreController()
            : base (new DublinCoreConstants())
        {

        }

        public void LoadExtension(RssSyndicationExtension extension, XElement element)
        {
            if (extension.Context == null)
            {
                extension.Context = new DublinCoreExtensionContext();
            }

            extension.Context = ProcessExtensionElement(element, extension.Context);
        }
    }
}
