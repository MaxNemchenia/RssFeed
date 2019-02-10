using RSSFeed.Models;
using System.Data.Entity;

namespace RSSFeed.DAL
{
    class ChannelInitializer: DropCreateDatabaseIfModelChanges<RSSContext>
    {
        protected override void Seed(RSSContext context)
        {
            context.Channels.Add(new Channel { Title = "Интерфакс", Link = @"https://www.interfax.by/news/feed" });
            context.Channels.Add(new Channel { Title = "Хабр", Link = @"https://habr.com/ru/rss/all/all/" });
            base.Seed(context);
        }
    }
}
