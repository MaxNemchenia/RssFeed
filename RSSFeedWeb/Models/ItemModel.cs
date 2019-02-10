using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace RSSFeedWeb.Models
{
    [Table(Name = "Items")]
    public class ItemModel
    {
        [Column]
        public int Id { get; set; }
        [Column]
        public string Title { get; set; }
        [Column]
        public string Link { get; set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public string PubDate { get; set; }

        [Column]
        public int ChannelId { get; set; }
        public virtual ChannelModel Channel { get; set; }
    }
}