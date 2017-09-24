using RssAlphaReader.Model.SubContent;

namespace RssAlphaReader.Model.Interface
{
    public interface IContext
    {
        RssSyndicationText Description { get; set; }
        RssSyndicationText Title { get; set; }
    }
}
