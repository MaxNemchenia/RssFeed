using RSSFeed.Models;

namespace RSSFeed.Interfaces
{
    public interface IItemService: IService<Item>
    {
        Item Find(string title, string pubDate);
    }
}
