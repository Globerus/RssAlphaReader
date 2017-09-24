using RssAlphaReader.Configuration;
using RssAlphaReader.Model.SubContent;
using RssAlphaReader.Model.SubContent.Metadata.MediaRssContext;
using RssAlphaReader.Model.SubContent.Metadata.MediaRssContext.SubContent;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RssAlphaReader.Controller
{
    public class MediaRssController : BaseController
    {
        public MediaRssController()
            : base(new MediaRssConstants())
        {

        }

        public void LoadExtension(RssSyndicationExtension extension, XElement element)
        {
            if (extension.Context == null)
            {
                extension.Context = new MediaRssExtensionContext();
            }

            extension.Context = ProcessExtensionElement(element, extension.Context);
        }
    }
}
