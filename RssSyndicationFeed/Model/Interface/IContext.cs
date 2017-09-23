using RssSyndicationFeed.Model.SubContent;

namespace RssSyndicationFeed.Model.Interface
{
    public interface IContext
    {
        RssSyndicationText Description { get; set; }
        RssSyndicationText Title { get; set; }
    }
}
