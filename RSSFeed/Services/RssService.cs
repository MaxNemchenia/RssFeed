using RSSFeed.DAL;
using RSSFeed.Interfaces;
using RSSFeed.Models;
using System;
using System.Net.Http;
using System.Xml;

namespace RSSFeed.Services
{
    class RssService
    {
        private readonly HttpClient client;
        RSSContext rssContext;
        IChannelService channelService;
        IItemService itemService;


        public RssService()
        {
            client = new HttpClient();
            rssContext = new RSSContext();
            channelService = new ChannelService(rssContext);
            itemService = new ItemService(rssContext);
        }



        public bool RssFeeder() // check
        {
            try
            {
                foreach (var channel in channelService.GetAll())
                {
                    XmlDocument doc = GetRss(channel.Link);
                    RssLoad(doc, channel);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        XmlDocument GetRss(string link)
        {
            var responseString = client.GetStringAsync(link).Result.TrimStart();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseString);
            return doc;
        }



        void RssLoad(XmlDocument doc, Channel channel)
        {
            int news = 0;
            int newNews = 0;
        
            XmlNode root = doc.DocumentElement;
            XmlNodeList nodeList = doc.GetElementsByTagName("item");
            
            foreach (XmlNode currentItem in nodeList)
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

                news++;
                if (itemService.Find(article.Title, article.PubDate) == null)
                {
                    newNews++;
                    article.ChannelId = channel.Id;
                    article.Channel = channel; //TODO: check
                    channel.Items.Add(article);
                }
                else
                {
                    article.ChannelId = channel.Id;
                    article.Channel = channel; //TODO: check
                    itemService.Update(article);
                }
            }

            channelService.Update(channel);

            Console.WriteLine(channel.Title);
            Console.WriteLine("News: {0}", news);
            Console.WriteLine("New news: {0}", newNews);
        }
    }
}
