using System.Xml;

namespace RSSFeed.Interfaces
{
    public interface IParser<T>
    {
        T Parse(XmlNode currentItem);
    }
}
