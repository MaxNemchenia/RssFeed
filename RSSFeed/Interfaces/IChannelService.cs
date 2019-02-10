using RSSFeed.Models;

namespace RSSFeed.Interfaces
{
    public interface IChannelService: IService<Channel>
    {
        Channel Find(string Title);
    }
}
