using RSSFeed.DAL;
using RSSFeed.Interfaces;
using RSSFeed.Models;
using System.Collections.Generic;
using System.Linq;

namespace RSSFeed.Services
{
    class ChannelService : IChannelService
    {
        RSSContext db;



        public ChannelService(RSSContext db)
        {
            this.db = db;
        }



        public Channel Find(string link)
        {
            Channel channel = new Channel();
            channel = db.Channels.FirstOrDefault(a => a.Link == link);
            return channel;
        }


        public IEnumerable<Channel> GetAll()
        {
            var channels = db.Channels.Include("Items").ToList();
            return channels;
        }


        public void Update(Channel updateChannel)
        {
            Channel channel = db.Channels.FirstOrDefault(a => a.Link == updateChannel.Link);
            updateChannel.Id = channel.Id;
            db.Entry(channel).CurrentValues.SetValues(updateChannel);
            db.SaveChanges();
        }
    }
}
