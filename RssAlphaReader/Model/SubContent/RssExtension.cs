using RssAlphaReader.Model.Interface;

namespace RssAlphaReader.Model.SubContent
{
    public class RssExtension
    {
        public IModel Model { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
    }
}
