using RSSFeed.DAL;
using RSSFeed.Interfaces;
using RSSFeed.Models;
using System.Collections.Generic;
using System.Linq;

namespace RSSFeed.Services
{
    public class ItemService: IItemService
    {
        RSSContext db;



        public ItemService(RSSContext db)
        {
            this.db = db;
        }



        public Item Find(string title, string pubDate)
        {
            Item item = db.Items.FirstOrDefault(a => a.Title == title && a.PubDate == pubDate);
            return item;
        }


        public IEnumerable<Item> GetAll()
        {
            return db.Items.ToList();
        }


        public void Update(Item updateItem)
        {
            Item item = db.Items.FirstOrDefault(a => a.Title == updateItem.Title && a.PubDate == updateItem.PubDate); // check
            updateItem.Id = item.Id;
            db.Entry(item).CurrentValues.SetValues(updateItem);
            db.SaveChanges();
        }
    }
}
