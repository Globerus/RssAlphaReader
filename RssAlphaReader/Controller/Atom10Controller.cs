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

        public RssAlphaReaderContext Load(XDocument document)
        {
            var model = new RssAlphaReaderContext();

            model = ProcessChildrenElements(document.Root, model);

            return model;
        }

        public void LoadExtension(RssSyndicationExtension extension, XElement element)
        {
            if(extension.Context == null)
            {
                extension.Context = new RssAlphaReaderContext();
            }

            extension.Context = ProcessExtensionElement(element, extension.Context);
        }
    }
}
