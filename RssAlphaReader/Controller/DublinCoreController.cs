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

        public void LoadExtension(RssExtension extension, XElement element)
        {
            if (extension.Model == null)
            {
                extension.Model = new DublinCoreExtension();
            }

            extension.Model = ProcessExtensionElement(element, extension.Model);
        }
    }
}
