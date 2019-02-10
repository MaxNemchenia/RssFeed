using RSSFeed.Models;
using System.Data.Entity;

namespace RSSFeed.DAL
{
    public class RSSContext : DbContext
    {
        public RSSContext()
           : base("DbConnection")
        { }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
