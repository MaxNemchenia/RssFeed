﻿using RSSFeedWeb.Models;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text.RegularExpressions;

namespace RSSFeedWeb.Serices
{
    public class Service
    {
        string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        DataContext db;


        public Service()
        {
            db = new DataContext(connection);
        }



        public IEnumerable<ItemModel> GetItems(int? channelId)
        {
            IEnumerable<ItemModel> items;

            if (channelId != null && channelId > 0)
            {
                items = db.GetTable<ItemModel>().Where(x => x.ChannelId == channelId).ToList();
            }
            else
            {
                items = db.GetTable<ItemModel>().ToList();
            }

            var channels = db.GetTable<ChannelModel>().ToList();
            foreach (var i in items)
            {
                i.Channel = channels.FirstOrDefault(x => x.Id == i.ChannelId);
            }

            return items;
        }


        public IEnumerable<ItemModel> Sort(IEnumerable<ItemModel> items, int? sort)
        {
            if (sort != null && sort != 0)
            {
                if (sort == 1)
                {
                    items = items.OrderByDescending(i => i.PubDate);
                }
                else if (sort == 2)
                {
                    items = items.OrderBy(i => i.ChannelId);
                }
            }

            return items;
        }
        

        public IEnumerable<ChannelModel> GetChannels()
        {
            var channels = db.GetTable<ChannelModel>();
            return channels;
        }
    }
}