using RssAlphaReader.Configuration;
using RssAlphaReader.Model.SubContent;
using RssAlphaReader.Model.SubContent.Metadata.MediaRssContext;
using System.Xml.Linq;

namespace RssAlphaReader.Controller
{
    public class MediaRssController : BaseController
    {
        public MediaRssController()
            : base(new MediaRssConstants())
        {

        }

        public void LoadExtension(RssExtension extension, XElement element)
        {
            if (extension.Model == null)
            {
                extension.Model = new MediaRssExtension();
            }

            extension.Model = ProcessExtensionElement(element, extension.Model);
        }
    }
}
