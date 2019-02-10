using RSSFeed.DAL;
using RSSFeed.Services;
using System;
using System.Data.Entity;

namespace RSSFeed
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new ChannelInitializer()); // check
            RssService rss = new RssService();
            rss.RssFeeder();
            Console.ReadKey();
        }
    }
}
