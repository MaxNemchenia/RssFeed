using System.Collections.Generic;

namespace RSSFeedWeb.Models
{
    public class ItemViewModel
    {
        public IEnumerable<ItemModel> Items { get; set; }
        public IEnumerable<ChannelModel> Channels { get; set; }
        public int? Sort { get; set; } = 0;
        public int? Filter { get; set; } = 0;
    }
}