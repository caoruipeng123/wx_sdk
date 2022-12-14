using System;
using System.Xml.Linq;

namespace WxSdk
{
    public class EventHelper
    {
        /// <summary>
        /// 根据xml信息，返回EventType
        /// </summary>
        public static Event GetEventType(XDocument doc)
        {
            return GetEventType(doc.Root.Element("Event").Value);
        }

        public static Event GetEventType(string str)
        {
            return (Event)Enum.Parse(typeof(Event), str, true);
        }
    }
}
