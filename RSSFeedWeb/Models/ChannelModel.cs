using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace RSSFeedWeb.Models
{
    [Table(Name ="Channels")]
    public class ChannelModel
    {
        [Column]
        public int Id { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string Link { get; set; }
      
        public virtual ICollection<ItemModel> Items { get; set; }

        public ChannelModel()
        {
            Items = new List<ItemModel>();
        }
    }
}