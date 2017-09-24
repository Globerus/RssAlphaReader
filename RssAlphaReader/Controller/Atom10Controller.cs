using RssAlphaReader.Configuration;
using RssAlphaReader.Model;
using RssAlphaReader.Model.SubContent;
using System.Linq;
using System.Xml.Linq;

namespace RssAlphaReader.Controller
{
    public class Atom10Controller : BaseController
    {
        public Atom10Controller ()
            : base(new AtomConstants())
        {

        }

        public RssFeed Load(XDocument document, RssFeed model)
        {
            return ProcessChildrenElements(document.Root, model);
        }

        public void LoadExtension(RssExtension extension, XElement element)
        {
            if(extension.Model == null)
            {
                extension.Model = new RssFeed();
            }

            extension.Model = ProcessExtensionElement(element, extension.Model);
        }
    }
}
