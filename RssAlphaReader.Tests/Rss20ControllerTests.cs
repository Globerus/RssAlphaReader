using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RssAlphaReader.Controller;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Net;
using System.Linq;
using RssAlphaReader.Model.SubContent;
using RssAlphaReader.Model.SubContent.Metadata.MediaRssContext;
using RssAlphaReader.Model;

namespace RssAlphaReader.Tests
{
    [TestClass]
    public class Rss20ControllerTests
    {
        private Rss20Controller rss20Controller = new Rss20Controller();

        [TestMethod]
        public void ProcessAuthor_IsCorrect()
        {
            string xml = "<author>Мирела Веселинова</author>";
            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("Мирела Веселинова", rss.Author.Email);
        }

        [TestMethod]
        public void ProcessDescription_IsCorrect()
        {
            string xml = "<description>Hello, World Description</description>";
            
            var document = GenerateDocumentFromXML(xml);

            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("Hello, World Description", rss.Description.Text);
        }

        [TestMethod]
        public void ProcessCategory_IsCorrect()
        {
            var xml = "<category domain='http://www.fool.com/cusips'>MSFT</category>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("http://www.fool.com/cusips", rss.Category.Scheme);
            Assert.AreEqual("MSFT", rss.Category.Label);
        }

        [TestMethod]
        public void ProcessGenerator_IsCorrect()
        {
            var xml = "<generator>MightyInHouse Content System v2.3</generator>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("MightyInHouse Content System v2.3", rss.Generator);
        }

        [TestMethod]
        public void ProcessGuid_IsCorrect()
        {
            var xml = "<guid isPermaLink='true'>http://inessential.com/2002/09/01.php#a2</guid>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("true", rss.Guid.IsPermaLink);
            Assert.AreEqual("http://inessential.com/2002/09/01.php#a2", rss.Guid.Id);
        }

        [TestMethod]
        public void ProcessImage_IsCorrect()
        {
            var xml = @"<image>
                            <url>http://85.14.28.164/d/images/rss_logo.png</url>
                            <title>DNES.BG</title>
                            <link>http://www.dnes.bg</link>
                            <width>600</width>
                            <height>400</height>
                            <description>Dnes.BG</description>
                        </image>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("Dnes.BG", rss.Image.Description.Text);
            Assert.AreEqual("400", rss.Image.Height);
            Assert.AreEqual("600", rss.Image.Width);
            Assert.AreEqual("http://www.dnes.bg", rss.Image.Link.Href);
            Assert.AreEqual("http://85.14.28.164/d/images/rss_logo.png", rss.Image.Url.Href);
            Assert.AreEqual("DNES.BG", rss.Image.Title.Text);
        }

        [TestMethod]
        public void ProcessHeight_IsCorrect()
        {
            string xml = "<height>400</height>";

            var document = GenerateDocumentFromXML(xml);
            var image = new RssImage();
            image = rss20Controller.ProcessElement(document, image);

            Assert.AreEqual("400", image.Height);
        }

        [TestMethod]
        public void ProcessLastBuildDate_IsCorrect()
        {
            string xml = "<lastBuildDate>Sat, 16 Sep 2017 14:37:46 GMT</lastBuildDate>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("Sat, 16 Sep 2017 14:37:46 GMT", rss.LastBuildDate);
        }

        [TestMethod]
        public void ProcessLink_IsCorrect()
        {
            string xml = "<link>http://www.cnn.com/app-international-edition/index.html</link>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("http://www.cnn.com/app-international-edition/index.html", rss.Link.FirstOrDefault()?.Href);
        }

        [TestMethod]
        public void ProcessManagingEditor_IsCorrect()
        {
            string xml = "<managingEditor>geo@herald.com (George Matesky)</managingEditor>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("geo@herald.com (George Matesky)", rss.ManagingEditor.Email);
        }

        [TestMethod]
        public void ProcessPubDate_IsCorrect()
        {
            string xml = "<pubDate>Sat, 07 Sep 2002 00:00:01 GMT</pubDate>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("Sat, 07 Sep 2002 00:00:01 GMT", rss.PubDate);
        }

        [TestMethod]
        public void ProcessTitle_IsCorrect()
        {
            string xml = "<title>Hello, World</title>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("Hello, World", rss.Title.Text);
        }

        [TestMethod]
        public void ProcessComments_IsCorrect()
        {
            string xml = "<comments>www.yahoo.com</comments>";

            var document = GenerateDocumentFromXML(xml);
            var item = new RssItem();
            item = rss20Controller.ProcessElement(document, item);

            Assert.AreEqual("www.yahoo.com", item.Comments.Href);
        }

        [TestMethod]
        public void ProcessEnclosure_IsCorrect()
        {
            string xml = "<enclosure url='http://www.scripting.com/mp3s/weatherReportSuite.mp3' length='12216320' type='audio/mpeg' />";

            var document = GenerateDocumentFromXML(xml);
            var item = new RssItem();
            item = rss20Controller.ProcessElement(document, item);

            Assert.AreEqual("http://www.scripting.com/mp3s/weatherReportSuite.mp3", item.Enclosure.Url.Href);
            Assert.AreEqual("audio/mpeg", item.Enclosure.Type);
            Assert.AreEqual("12216320", item.Enclosure.Length);
        }

        [TestMethod]
        public void ProcessSource_IsCorrect()
        {
            string xml = "<source url='http://www.tomalak.org/links2.xml'>Tomalak's Realm</source>";

            var document = GenerateDocumentFromXML(xml);
            var item = new RssItem();
            item = rss20Controller.ProcessElement(document, item);

            Assert.AreEqual("Tomalak's Realm", item.Source.Text);
            Assert.AreEqual("http://www.tomalak.org/links2.xml", item.Source.Url.Href);
        }

        [TestMethod]
        public void ProcessWidth_IsCorrect()
        {
            string xml = "<width>222</width>";

            var document = GenerateDocumentFromXML(xml);
            var image = new RssImage();
            image = rss20Controller.ProcessElement(document, image);

            Assert.AreEqual("222", image.Width);
        }

        [TestMethod]
        public void ProcessCopyright_IsCorrect()
        {
            string xml = "<copyright>Copyright 2002, Spartanburg Herald-Journal</copyright>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("Copyright 2002, Spartanburg Herald-Journal", rss.Copyright.Text);
        }

        [TestMethod]
        public void ProcessItem_IsCorrect()
        {
            string xml = @"<item>
                                <title>Hello, World</title>
                                <link>http://www.cnn.com/app-international-edition/index.html</link>
                                <description>Hello, World Description</description>
                                <author>Мирела Веселинова</author>
                                <category domain='http://www.fool.com/cusips'>MSFT</category>
                                <comments>www.yahoo.com</comments>
                                <enclosure url='http://www.scripting.com/mp3s/weatherReportSuite.mp3' length='12216320' type='audio/mpeg' />
                                <guid isPermaLink='true'>http://inessential.com/2002/09/01.php#a2</guid>
                                <pubDate>Sat, 07 Sep 2002 00:00:01 GMT</pubDate>
                                <source url='http://www.tomalak.org/links2.xml'>Tomalak's Realm</source>
                                <media:group xmlns:media='http://search.yahoo.com/mrss/'>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-super-169.jpg' height='619' width='1100'/>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-large-11.jpg' height='300' width='300'/>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-vertical-large-gallery.jpg' height='552' width='414'/>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-video-synd-2.jpg' height='480' width='640'/>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-live-video.jpg' height='324' width='576' />
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-t1-main.jpg' height='250' width='250'/>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-vertical-gallery.jpg' height='360' width='270'/>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-story-body.jpg' height='169' width = '300'/>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-t1-main.jpg' height='250' width='250'/>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-assign.jpg' height='186' width='248'/>
                                    <media:content medium='image' url='http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-hp-video.jpg' height='144' width='256'/>
                                </media:group>
                            </item>";

            var document = GenerateDocumentFromXML(xml);
            var rss = new RssFeed();
            rss = rss20Controller.ProcessElement(document, rss);

            Assert.AreEqual("Hello, World", rss.Items.FirstOrDefault()?.Title.Text);
            Assert.AreEqual("http://www.cnn.com/app-international-edition/index.html", rss.Items.FirstOrDefault()?.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("Hello, World Description", rss.Items.FirstOrDefault()?.Description.Text);
            Assert.AreEqual("Мирела Веселинова", rss.Items.FirstOrDefault()?.Author.Email);
            Assert.AreEqual("MSFT", rss.Items.FirstOrDefault()?.Category.Label);
            Assert.AreEqual("http://www.fool.com/cusips", rss.Items.FirstOrDefault()?.Category.Scheme);
            Assert.AreEqual("www.yahoo.com", rss.Items.FirstOrDefault()?.Comments.Href);
            Assert.AreEqual("http://www.scripting.com/mp3s/weatherReportSuite.mp3", rss.Items.FirstOrDefault()?.Enclosure.Url.Href);
            Assert.AreEqual("12216320", rss.Items.FirstOrDefault()?.Enclosure.Length);
            Assert.AreEqual("audio/mpeg", rss.Items.FirstOrDefault()?.Enclosure.Type);
            Assert.AreEqual("http://inessential.com/2002/09/01.php#a2", rss.Items.FirstOrDefault()?.Guid.Id);
            Assert.AreEqual("true", rss.Items.FirstOrDefault()?.Guid.IsPermaLink);
            Assert.AreEqual("Sat, 07 Sep 2002 00:00:01 GMT", rss.Items.FirstOrDefault()?.PubDate);
            Assert.AreEqual("http://www.tomalak.org/links2.xml", rss.Items.FirstOrDefault()?.Source.Url.Href);
            Assert.AreEqual("Tomalak's Realm", rss.Items.FirstOrDefault()?.Source.Text);

            var mediaRss = rss.Items.FirstOrDefault()?.Extensions.FirstOrDefault()?.Model as MediaRssExtension;

            Assert.AreEqual("image", mediaRss.Group.FirstOrDefault()?.Medium);
            Assert.AreEqual("http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-super-169.jpg", mediaRss.Group.FirstOrDefault()?.Url.Href);
            Assert.AreEqual("619", mediaRss.Group.FirstOrDefault()?.Height);
            Assert.AreEqual("1100", mediaRss.Group.FirstOrDefault()?.Width);
        }

        private XElement GenerateDocumentFromXML(string xml)
        {
            TextReader tReader = new StringReader(xml);
            XmlReaderSettings settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse };
            var xReader = XmlReader.Create(tReader, settings);
            return XDocument.Load(xReader).Root;
        }
    }
}
