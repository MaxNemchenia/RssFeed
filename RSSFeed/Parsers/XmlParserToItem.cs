using RSSFeed.Interfaces;
using RSSFeed.Models;
using System.Xml;

namespace RSSFeed.Parsers
{
    public class XmlParserToItem : IParser<Item>
    {
        public Item Parse(XmlNode currentItem)
        {
            Item article = new Item();
            XmlNodeList itemsList = currentItem.ChildNodes;
            foreach (XmlNode item in itemsList)
            {
                switch (item.Name)
                {
                    case "title":
                        {
                            article.Title = item.InnerText;
                            break;
                        }

                    case "link":
                        {
                            article.Link = item.InnerText;
                            break;
                        }

                    case "description":
                        {
                            article.Description = item.InnerText.Trim();
                            break;
                        }

                    case "pubDate":
                        {
                            article.PubDate = item.InnerText;
                            break;
                        }
                }
            }
            return article;
        }
    }
}
