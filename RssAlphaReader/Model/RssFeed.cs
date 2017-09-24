using RssAlphaReader.Configuration;
using RssAlphaReader.Model.Interface;
using RssAlphaReader.Model.SubContent;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace RssAlphaReader.Model
{
    public class RssFeed : IModel
    {
        public RssPerson Author { get; set; }
        public RssText Description { get; set; }
        public RssCategory Category { get; set; }
        public RssText Content { get; set; }
        public RssText Copyright { get; set; }
        public List<RssExtension> Extensions { get; set; }
        public string Generator { get; set; }
        public RssGuid Guid { get; set; }
        public string Icon { get; set; }
        public RssImage Image { get; set; }
        public List<RssItem> Items { get; set; }
        public string Language { get; set; }
        public string LastBuildDate { get; set; }
        public List<RssLink> Link { get; set; }
        public RssLink Logo { get; set; }
        public RssPerson ManagingEditor { get; set; }
        public string PubDate { get; set; }
        public string Subtitle { get; set; }
        public RssText Title { get; set; }
        public string Ttl { get; set; }
        public RssPerson WebMaster { get; set; }

        public void Load(XmlReader xml)
        {
            try
            {
                var document = XDocument.Load(xml);
                var root = document.Root;

                Type formatter;
                string bootstrapper;

                var formatterAvailabe = GlobalConstants.SupportedFormatters.TryGetValue(root.Name.LocalName, out formatter);
                var boostrapperAvailable = GlobalConstants.BootstrapMethods.TryGetValue(root.Name.LocalName, out bootstrapper);

                if (!formatterAvailabe || !boostrapperAvailable)
                {
                    return;
                }

                var formatterObject = Activator.CreateInstance(formatter);

                formatter.GetMethod(bootstrapper)
                         .Invoke(formatterObject, new object[] { document, this });
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}