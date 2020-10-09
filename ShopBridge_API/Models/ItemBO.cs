using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge_API.Models
{
    public class ItemBO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public DateTime AddedOn { get; set; }
        public string ItemImage { get; set; }
    }
}