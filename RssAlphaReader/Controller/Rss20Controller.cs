using RssAlphaReader.Configuration;
using RssAlphaReader.Model;
using RssAlphaReader.Model.SubContent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RssAlphaReader.Controller
{
    public class Rss20Controller : BaseController
    {
        public Rss20Controller()
            :   base(new Rss20Constants())
        {

        }

        public RssFeed Load(XDocument document, RssFeed model)
        {
            return ProcessChildrenElements(document.Root.Element("channel"), model);
        }
    }
}
