using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge_API.DAL
{
    public class ItemDAL
    {
        public void SaveItem(Item item)
        {
            using (ShopBridgeEntities db = new ShopBridgeEntities())
            {
                db.Items.Add(item);
                db.SaveChanges();
            }
        }
        public List<Item> GetItems()
        {
            List<Item> items = null;
            using (ShopBridgeEntities db = new ShopBridgeEntities())
            {
                items = db.Items.ToList();
            }
            return items;
        }
        public Item GetItemById(long id)
        {
            Item item = new Item();
            using (ShopBridgeEntities db = new ShopBridgeEntities())
            {
                item = db.Items.SingleOrDefault(x=>x.ItemId.Equals(id));
            }
            return item;
        }
        public void DeleteItemById(long id)
        {
            using (ShopBridgeEntities db = new ShopBridgeEntities())
            {
                var item = db.Items.SingleOrDefault(x => x.ItemId.Equals(id));
                db.Items.Remove(item);
                db.SaveChanges();
            }
        }
    }
}