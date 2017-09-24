using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;
using System.Linq;
using RssAlphaReader.Model;
using System.Net;
using RssAlphaReader.Model.SubContent.Metadata.DublinCoreContext;
using RssAlphaReader.Model.SubContent.Metadata.MediaRssContext;
using RssAlphaReader.Tests;

namespace RssAlphaReader.Tests
{
    [TestClass]
    public class RSFManagerTests
    {
        [TestMethod]
        public void RSFManagerLoadBNT()
        {
            var xml = Resource.BNT;
            var xReader = GenerateReaderFromXML(xml);
            var feed = RssAlphaReaderManager.Load(xReader);

            Assert.IsNotNull(feed);

            var extension = feed.Extensions.FirstOrDefault().Context as RssAlphaReaderContext;
            Assert.AreEqual("http://news.bnt.bg/bg/rss/news.xml", extension.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("self", ((RssAlphaReaderContext)feed.Extensions.FirstOrDefault()?.Context).Link.FirstOrDefault()?.Rel);
            Assert.AreEqual("application/rss+xml", ((RssAlphaReaderContext)feed.Extensions.FirstOrDefault()?.Context).Link.FirstOrDefault()?.Type);

            Assert.AreEqual("БНТ Новини", feed.Title.Text);
            Assert.AreEqual("http://news.bnt.bg/", feed.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("Новини от Българска национална телевизия", feed.Description.Text);
            Assert.AreEqual("bg", feed.Language);
            Assert.AreEqual("Sat, 16 Sep 2017 16:25:05 +0300", feed.LastBuildDate);
            Assert.AreEqual("Откриха бюстове и картини на Хитлер в парламента на Австрия", feed.Items.FirstOrDefault()?.Title.Text);
            Assert.AreEqual("http://news.bnt.bg/bg/a/otkrikha-byustove-i-kartini-na-khitler-v-parlamenta-na-avstriya", feed.Items.FirstOrDefault()?.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("По време на ремонт на австрийския парламент строители откриха в едно от мазетата картини, два бюста и барелеф на Адолф Хитлер.", feed.Items.FirstOrDefault()?.Description.Text);
            Assert.AreEqual("По света / Общество", feed.Items.FirstOrDefault()?.Category.Label);
            Assert.AreEqual("http://news.bnt.bg/bg/a/otkrikha-byustove-i-kartini-na-khitler-v-parlamenta-na-avstriya", feed.Items.FirstOrDefault()?.Guid.Id);
            Assert.AreEqual("true", feed.Items.FirstOrDefault()?.Guid.IsPermaLink);
            Assert.AreEqual("Sat, 16 Sep 2017 15:50:11 +0300", feed.Items.FirstOrDefault()?.PubDate);
            Assert.AreEqual("http://nws2.bnt.bg/p/r/e/red-svqt-236867-360x202.jpg", feed.Items.FirstOrDefault()?.Enclosure.Url.Href);
            Assert.AreEqual("image/jpeg", feed.Items.FirstOrDefault()?.Enclosure.Type);
            Assert.AreEqual("11245", feed.Items.FirstOrDefault()?.Enclosure.Length);

        }

        [TestMethod]
        public void RSFManagerLoadCapital()
        {
            var xml = Resource.CapitalBG;
            var xReader = GenerateReaderFromXML(xml);
            var feed = RssAlphaReaderManager.Load(xReader);

            Assert.IsNotNull(feed);
            Assert.AreEqual("Капитал - България", feed.Title.Text);
            Assert.AreEqual("http://www.capital.bg/rss/?rubrid=2249", feed.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("bg", feed.Language);
            
            Assert.AreEqual("26", feed.Image.Height);
            Assert.AreEqual("144", feed.Image.Width);
            Assert.AreEqual("http://www.capital.bg", feed.Image.Link.Href);
            Assert.AreEqual("http://www.capital.bg/i/6/capital-rss.gif", feed.Image.Url.Href);
            Assert.AreEqual("Capital.bg", feed.Image.Title.Text);

            string description = @"<img src=""http://www.capital.bg/shimg/zx350_3003501.jpg"" alt="""" /><br />Президентът Румен Радев даде знак, че няма да подпише указа за назначаване на Георги Чолаков за председател на Върховния административен съд (ВАС), но и че ще даде шанс на новия Висш съдебен съвет (ВСС) да реши този избор окончателно. В този смисъл прозвуча изявлението му пред журналисти в събота в Борисовата градина, където президентът участва в инициативата ""Да изчистим България"".<br /><br />На въпрос ще подпише ли указа за назначаването на Чолаков, президентът Радев заяви: ""Казах, че...";

            Assert.AreEqual("CRSS generator", feed.Generator);
            Assert.AreEqual("online@capital.bg", feed.WebMaster.Email);
            Assert.AreEqual("Президентът: Новият съдебен съвет трябва да избере председателя на Върховния административен съд", feed.Items.FirstOrDefault()?.Title.Text);
            Assert.AreEqual("http://www.capital.bg/politika_i_ikonomika/bulgaria/2017/09/16/3043059_prezidentut_noviiat_sudeben_suvet_triabva_da_izbere/?ref=rss", feed.Items.FirstOrDefault()?.Link.FirstOrDefault()?.Href);
            Assert.AreEqual(description, feed.Items.FirstOrDefault()?.Description.Text);
            Assert.AreEqual("3043059", feed.Items.FirstOrDefault()?.Guid.Id);
            Assert.AreEqual("false", feed.Items.FirstOrDefault()?.Guid.IsPermaLink);
            Assert.AreEqual("Мирела Веселинова", feed.Items.FirstOrDefault()?.Author.Email);
            Assert.AreEqual("http://www.capital.bg/politika_i_ikonomika/bulgaria/2017/09/16/3043059_prezidentut_noviiat_sudeben_suvet_triabva_da_izbere/?ref=rss#comments", feed.Items.FirstOrDefault().Comments.Href);
            Assert.AreEqual("Sat, 16 Sep 2017 14:25:00 +0300", feed.Items.FirstOrDefault()?.PubDate);
        }

        [TestMethod]
        public void RSFManagerLoadTrafficNews()
        {
            
            var xml = Resource.TrafficNewsBG;
            var xReader = GenerateReaderFromXML(xml);
            var feed = RssAlphaReaderManager.Load(xReader);

            Assert.IsNotNull(feed);
            Assert.AreEqual("Trafficnews.bg", feed.Title.Text);
            Assert.AreEqual("https://trafficnews.bg/", feed.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("Категория България", feed.Description.Text);
            Assert.AreEqual("bg-bg", feed.Language);
            Assert.AreEqual("Copyright (C) 2017 Trafficnews.bg", feed.Copyright.Text);

            Assert.AreEqual("Болен мъж живее месеци наред на улицата в Смолян, социалните вдигат ръце СНИМКИ", feed.Items.FirstOrDefault()?.Title.Text);
            Assert.AreEqual("Той е бил девет пъти в затвора", feed.Items.FirstOrDefault()?.Description.Text);
            Assert.AreEqual("България", feed.Items.FirstOrDefault()?.Category.Label);
            Assert.AreEqual("https://trafficnews.bg/bulgaria/news/84428/", feed.Items.FirstOrDefault()?.Guid.Id);
            Assert.AreEqual("https://trafficnews.bg/bulgaria/news/84428/", feed.Items.FirstOrDefault()?.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("https://cdn2.trafficnews.bg/2017/09/14/1505390716_991-ratio-bezdomnik-smolian.jpg", feed.Items.FirstOrDefault()?.Enclosure.Url.Href);
            Assert.AreEqual("image/jpg", feed.Items.FirstOrDefault()?.Enclosure.Type);
        }

        [TestMethod]
        public void RSFManagerLoadVestiBG()
        {
            var xml = Resource.VestiBG;
            var xReader = GenerateReaderFromXML(xml);
            var feed = RssAlphaReaderManager.Load(xReader);

            Assert.IsNotNull(feed);

            Assert.AreEqual("https://www.vesti.bg/rss", ((RssAlphaReaderContext)feed.Extensions.FirstOrDefault()?.Context).Link.FirstOrDefault()?.Href);
            Assert.AreEqual("self", ((RssAlphaReaderContext)feed.Extensions.FirstOrDefault()?.Context).Link.FirstOrDefault()?.Rel);
            Assert.AreEqual("application/rss+xml", ((RssAlphaReaderContext)feed.Extensions.FirstOrDefault()?.Context).Link.FirstOrDefault()?.Type);

            Assert.AreEqual("VESTI.bg", feed.Title.Text);
            Assert.AreEqual("Български и световни новини от бизнеса и политиката. Наука, технологии и медии. Инциденти и произшествия, съдебна система. Любопитно за звездите.", feed.Description.Text);
            Assert.AreEqual("http://www.vesti.bg/", feed.Link.FirstOrDefault()?.Href);

            Assert.AreEqual("През 2018 г. учени ще търсят контакт с извънземни", feed.Items.FirstOrDefault()?.Title.Text);
            Assert.AreEqual("Следващата година започва нов проект за изпращане на сигнали в Космоса, който среща сериозна опозиция", feed.Items.FirstOrDefault()?.Description.Text);
            Assert.AreEqual("Наука и техника", feed.Items.FirstOrDefault()?.Category.Label);
            Assert.AreEqual("https://www.vesti.bg/tehnologii/nauka-i-tehnika/prez-2018-g.-ucheni-shte-tyrsiat-kontakt-s-izvynzemni-6073768", feed.Items.FirstOrDefault()?.Guid.Id);
            Assert.AreEqual("true", feed.Items.FirstOrDefault()?.Guid.IsPermaLink);
            Assert.AreEqual("https://www.vesti.bg/tehnologii/nauka-i-tehnika/prez-2018-g.-ucheni-shte-tyrsiat-kontakt-s-izvynzemni-6073768", feed.Items.FirstOrDefault()?.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("news@netinfo.bg (Vesti.bg)", feed.Items.FirstOrDefault()?.Author.Email);
            Assert.AreEqual("https://m.netinfo.bg/media/images/30758/30758750/201-140-kosmos-kosmonavt-mars.jpg", feed.Items.FirstOrDefault()?.Enclosure.Url.Href);
            Assert.AreEqual("image/jpg", feed.Items.FirstOrDefault()?.Enclosure.Type);
            Assert.AreEqual("13413", feed.Items.FirstOrDefault()?.Enclosure.Length);
            Assert.AreEqual("Sat, 16 Sep 2017 15:42:00 +0300", feed.Items.FirstOrDefault()?.PubDate);

        }

        [TestMethod]
        public void RSFManagerLoadDnesBG()
        {
            var xml = Resource.DnesBG;
            var xReader = GenerateReaderFromXML(xml);
            var feed = RssAlphaReaderManager.Load(xReader);

            Assert.IsNotNull(feed);

            Assert.AreEqual("DNES.BG: България", feed.Title.Text);
            Assert.AreEqual("http://www.dnes.bg/", feed.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("bg", feed.Language);

            Assert.AreEqual("http://www.dnes.bg", feed.Image.Link.Href);
            Assert.AreEqual("http://85.14.28.164/d/images/rss_logo.png", feed.Image.Url.Href);
            Assert.AreEqual("DNES.BG", feed.Image.Title.Text);

            Assert.AreEqual("Радев недоволен: Лобисти върнаха в началото конкурса за изтребителя", feed.Items.FirstOrDefault()?.Title.Text);
            Assert.AreEqual("http://www.dnes.bg/politika/2017/09/16/radev-nedovolen-lobisti-vyrnaha-v-nachaloto-konkursa-za-iztrebitelia.353471", feed.Items.FirstOrDefault()?.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("Това застрашава да приземи окончателно авиацията ни, смята президентът", feed.Items.FirstOrDefault()?.Description.Text);

            Assert.AreEqual("2017-09-16T13:27:00+03:00", ((DublinCoreExtensionContext)feed.Items.LastOrDefault()?.Extensions.FirstOrDefault()?.Context).Date);

            Assert.AreEqual("http://www.dnes.bg/politika/2017/09/16/radev-nedovolen-lobisti-vyrnaha-v-nachaloto-konkursa-za-iztrebitelia.353471", feed.Items.FirstOrDefault()?.Guid.Id);
            Assert.AreEqual("false", feed.Items.FirstOrDefault()?.Guid.IsPermaLink);
            Assert.AreEqual("http://85.14.28.164/d/images/photos/0353/0000353471-top2.jpg", feed.Items.FirstOrDefault()?.Enclosure.Url.Href);
            Assert.AreEqual("image/jpeg", feed.Items.FirstOrDefault()?.Enclosure.Type);
        }

        [TestMethod]
        public void RSFManagerLoadCNN()
        {
            var xml = Resource.CNN;
            var xReader = GenerateReaderFromXML(xml);
            var feed = RssAlphaReaderManager.Load(xReader);

            Assert.IsNotNull(feed);

            Assert.AreEqual("CNN.com - RSS Channel - App International Edition", feed.Title.Text);
            Assert.AreEqual("CNN.com delivers up-to-the-minute news and information on the latest top stories, weather, entertainment, politics and more.", feed.Description.Text);
            Assert.AreEqual("http://www.cnn.com/app-international-edition/index.html", feed.Link.FirstOrDefault()?.Href);

            Assert.AreEqual("http://www.cnn.com/app-international-edition/index.html", feed.Image.Link.Href);
            Assert.AreEqual("http://i2.cdn.turner.com/cnn/2015/images/09/24/cnn.digital.png", feed.Image.Url.Href);
            Assert.AreEqual("CNN.com - RSS Channel - App International Edition", feed.Image.Title.Text);

            Assert.AreEqual("coredev-bumblebee", feed.Generator);
            Assert.AreEqual("Sat, 16 Sep 2017 13:29:31 GMT", feed.LastBuildDate);
            Assert.AreEqual("Sat, 16 Sep 2017 10:25:41 GMT", feed.PubDate);
            Assert.AreEqual("Copyright (c) 2017 Turner Broadcasting System, Inc. All Rights Reserved.", feed.Copyright.Text);
            Assert.AreEqual("en-US", feed.Language);
            Assert.AreEqual("10", feed.Ttl);

            var extension = feed.Extensions.Where(e => e.Name == "atom10").FirstOrDefault();
            var link1 = (extension.Context as RssAlphaReaderContext).Link.Where(l => l.Rel == "self").FirstOrDefault();
            var link2 = (extension.Context as RssAlphaReaderContext).Link.Where(l => l.Rel == "hub").FirstOrDefault();
            Assert.AreEqual("http://rss.cnn.com/rss/edition", link1.Href);
            Assert.AreEqual("self", link1.Rel);
            Assert.AreEqual("application/rss+xml", link1.Type);

            Assert.AreEqual("http://pubsubhubbub.appspot.com/", link2.Href);
            Assert.AreEqual("hub", link2.Rel);

            Assert.AreEqual("Secret state: The side of the hermit nation the world rarely sees", feed.Items.FirstOrDefault()?.Title.Text);
            Assert.AreEqual("http://cnn.it/2vYYp2j", feed.Items.FirstOrDefault()?.Link.FirstOrDefault()?.Href);

            Assert.AreEqual("http://cnn.it/2vYYp2j", feed.Items.FirstOrDefault()?.Guid.Id);
            Assert.AreEqual("true", feed.Items.FirstOrDefault()?.Guid.IsPermaLink);

            var mediaRss = feed.Items.FirstOrDefault()?.Extensions.FirstOrDefault()?.Context as MediaRssExtensionContext;

            Assert.AreEqual("image", mediaRss.Group.LastOrDefault()?.Medium);
            Assert.AreEqual("http://i2.cdn.turner.com/cnnnext/dam/assets/170915145033-03-north-korea-tease-only-hp-video.jpg", mediaRss.Group.LastOrDefault()?.Url.Href);
            Assert.AreEqual("144", mediaRss.Group.LastOrDefault()?.Height);
            Assert.AreEqual("256", mediaRss.Group.LastOrDefault()?.Width);
        }

        [TestMethod]
        public void RSFManagerLoadTheRegister()
        {
            var xml = Resource.TheRegister;
            var xReader = GenerateReaderFromXML(xml);
            var feed = RssAlphaReaderManager.Load(xReader);

            Assert.IsNotNull(feed);

            Assert.AreEqual("tag:theregister.co.uk,2005:feed/theregister.co.uk/software/", feed.Guid.Id);
            Assert.AreEqual("The Register - Software", feed.Title.Text);

            var link1 = feed.Link.Where(l => l.Rel == "self").FirstOrDefault();
            var link2 = feed.Link.Where(l => l.Rel == "alternate").FirstOrDefault();

            Assert.AreEqual("https://www.theregister.co.uk/software/headlines.atom", link1.Href);
            Assert.AreEqual("self", link1.Rel);
            Assert.AreEqual("application/atom+xml", link1.Type);

            Assert.AreEqual("https://www.theregister.co.uk/software/", link2.Href);
            Assert.AreEqual("alternate", link2.Rel);
            Assert.AreEqual("text/html", link2.Type);

            Assert.AreEqual("Copyright В© 2017, Situation Publishing", feed.Copyright.Text);
            Assert.AreEqual("Team Register", feed.Author.Name);
            Assert.AreEqual("webmaster@theregister.co.uk", feed.Author.Email);
            Assert.AreEqual("https://www.theregister.co.uk/odds/about/contact/", feed.Author.Url.Href);

            Assert.AreEqual("https://www.theregister.co.uk/Design/graphics/icons/favicon.png", feed.Icon);
            Assert.AreEqual("Biting the hand that feeds IT вЂ” sci/tech news and views for the world", feed.Subtitle);
            Assert.AreEqual("https://www.theregister.co.uk/Design/graphics/Reg_default/The_Register_r.png", feed.Logo.Href);
            Assert.AreEqual("2017-09-15T20:16:04Z", feed.LastBuildDate);

            Assert.AreEqual("tag:theregister.co.uk,2005:story/2017/09/15/chrome_will_kill_autoplaying_video_sounds/", feed.Items.FirstOrDefault().Guid.Id);
            Assert.AreEqual("2017-09-15T20:17:08Z", feed.Items.FirstOrDefault().LastBuildDate);
            Assert.AreEqual("Iain Thomson", feed.Items.FirstOrDefault().Author.Name);
            Assert.AreEqual("https://search.theregister.co.uk/?author=Iain%20Thomson", feed.Items.FirstOrDefault().Author.Url.Href);

            Assert.AreEqual("http://go.theregister.com/feed/www.theregister.co.uk/2017/09/15/chrome_will_kill_autoplaying_video_sounds/", feed.Items.FirstOrDefault().Link.FirstOrDefault()?.Href);
            Assert.AreEqual("alternate", feed.Items.FirstOrDefault().Link.FirstOrDefault()?.Rel);
            Assert.AreEqual("text/html", feed.Items.FirstOrDefault().Link.FirstOrDefault()?.Type);

            Assert.AreEqual("Google to kill Chrome autoplay madness", feed.Items.FirstOrDefault().Title.Text);
            Assert.AreEqual("html", feed.Items.FirstOrDefault().Title.Type);

            string description = WebUtility.HtmlDecode(@"&lt;h4&gt;Sorta, kinda, well not really&lt;/h4&gt; &lt;p&gt;Google has promised to end the infuriating autoplay of videos in its Chrome browser вЂ“ but with a heap of exceptions that may actually make the problem worse.вЂ¦&lt;/p&gt;");
            Assert.AreEqual(description, feed.Items.FirstOrDefault().Description.Text);
        }

        [TestMethod]
        public void RSFManagerLoadSportalBG()
        {
            var xml = Resource.SportalBG;
            var xReader = GenerateReaderFromXML(xml);
            var feed = RssAlphaReaderManager.Load(xReader);

            Assert.IsNotNull(feed);

            Assert.AreEqual("sportal.bg", feed.Title.Text);
            Assert.AreEqual("http://www.sportal.bg/", feed.Link.FirstOrDefault()?.Href);
            Assert.AreEqual("Sportal BG", feed.Description.Text);
            Assert.AreEqual("bg", feed.Language);

            Assert.AreEqual("http://www.sportal.bg/uploads/rss_category_0.xml", ((RssAlphaReaderContext)feed.Extensions.FirstOrDefault()?.Context).Link.FirstOrDefault()?.Href);
            Assert.AreEqual("self", ((RssAlphaReaderContext)feed.Extensions.FirstOrDefault()?.Context).Link.FirstOrDefault()?.Rel);
            Assert.AreEqual("application/rss+xml", ((RssAlphaReaderContext)feed.Extensions.FirstOrDefault()?.Context).Link.FirstOrDefault()?.Type);

            Assert.AreEqual("БГ Футбол", feed.Items.FirstOrDefault().Category.Label);
            Assert.AreEqual("Венци Стефанов избухна: Един човек атакува съдиите - Краля слънце (видео)", feed.Items.FirstOrDefault().Title.Text);
            Assert.AreEqual("http://www.sportal.bg/news.php?news=685580", feed.Items.FirstOrDefault().Link.FirstOrDefault().Href);
            string description = @"<img src=""https://img2.sportal.bg/uploads/news/2017_38/thumb_mid/00685580.jpg"" alt=""news picture"" /><br />Президентът на Славия Венцеслав Стефанов атакува остро собственика на Лудогорец Кирил Домусмиев, като обяви, че съдиите грешат заради негов натиск. ""Днес ...";
            Assert.AreEqual(description, feed.Items.FirstOrDefault().Description.Text);

            Assert.AreEqual("https://img2.sportal.bg/uploads/news/2017_38/thumb_mid/00685580.jpg", feed.Items.FirstOrDefault()?.Enclosure.Url.Href);
            Assert.AreEqual("image/jpeg", feed.Items.FirstOrDefault()?.Enclosure.Type);
            Assert.AreEqual("37435", feed.Items.FirstOrDefault()?.Enclosure.Length);
            Assert.AreEqual("Sat, 23 Sep 2017 18:56:00 +0300", feed.Items.FirstOrDefault().PubDate);
            Assert.AreEqual("afa8b451e5dbf72ac28d8a845ae1b47f", feed.Items.FirstOrDefault().Guid.Id);
            Assert.AreEqual("false", feed.Items.FirstOrDefault().Guid.IsPermaLink);

        }

        private XmlReader GenerateReaderFromXML(string xml)
        {
            TextReader tReader = new StringReader(xml);
            XmlReaderSettings settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse };
            return XmlReader.Create(tReader, settings);
        }
    }
}
