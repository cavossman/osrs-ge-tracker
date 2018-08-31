using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace aspnetrefresher.Models
{
    public class Item
    {
        public String Icon { get; set; }
        public String Icon_large { get; set; }
        public int Id { get; set; }
        public String Type { get; set; }
        public String TypeIcon { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Trend Current { get; set; }
        public Trend Today { get; set; }
        public Boolean Members { get; set; }
        public Trend Day30 { get; set; }
        public Trend Day90 { get; set; }
        public Trend Day180 { get; set; }

        public Item(JObject item)
        {
            Icon = (String)item["icon"];
            Icon_large = (String)item["icon_large"];
            Id = (int)item["id"];
            Type = (String)item["type"];
            TypeIcon = (String)item["typeIcon"];
            Name = (String)item["name"];
            Description = (String)item["description"];
            Current = new Trend((JObject)item["current"]);
            Today = new Trend((JObject)item["today"]);
            Members = (Boolean)item["members"];
            Day30 = new Trend((JObject)item["day30"]);
            Day90 = new Trend((JObject)item["day90"]);
            Day180 = new Trend((JObject)item["day180"]);
        }
    }
}

//{
//    "item":
//    {
//        "icon":"http://services.runescape.com/m=itemdb_oldschool/1535624975753_obj_sprite.gif?id=4151",
//        "icon_large":"http://services.runescape.com/m=itemdb_oldschool/1535624975753_obj_big.gif?id=4151",
//        "id":4151,
//        "type":"Default",
//        "typeIcon":"http://www.runescape.com/img/categories/Default",
//        "name":"Abyssal whip",
//        "description":"A weapon from the abyss.",
//        "current":
//        {
//            "trend":"neutral",
//            "price":"2.9m"
//        },
//        "today":
//        {
//            "trend":"negative",
//            "price":"- 4,849"
//        },
//        "members":"true",
//        "day30":
//        {
//            "trend":"negative",
//            "change":"-3.0%"
//        },
//        "day90":
//        {
//            "trend":"positive",
//            "change":"+8.0%"
//        },
//        "day180":
//        {
//            "trend":"positive",
//            "change":"+39.0%"
//        }
//    }
//};