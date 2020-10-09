using ShopBridge_API.DAL;
using ShopBridge_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge_API.BLL
{
    public class ItemBLL
    {
        ItemDAL itemDAL = new ItemDAL();
        public void SaveItem(ItemBO itemBO)
        {
            Item item = new Item
            {
                Name = itemBO.Name,
                ItemDescription = itemBO.Description,
                Price = itemBO.Price,
                AddedOn = DateTime.Now,
                ImageData = itemBO.ItemImage
            };
            itemDAL.SaveItem(item);
        }
        public List<ItemBO> GetItems()
        {
            List<ItemBO> items = new List<ItemBO>();
            List<Item> itemList = itemDAL.GetItems();
            foreach (var item in itemList)
            {
                items.Add(new ItemBO
                {
                    Id = item.ItemId,
                    Name = item.Name,
                    Description = item.ItemDescription,
                    Price = item.Price.Value,
                    AddedOn = item.AddedOn.Value,
                    ItemImage = item.ImageData
                });
            }
            return items;
        }
        public ItemBO GetItemById(long id)
        {

            Item item = itemDAL.GetItemById(id);
            ItemBO itemBO = new ItemBO
            {
                Id = item.ItemId,
                Name = item.Name,
                Description = item.ItemDescription,
                Price = item.Price.Value,
                AddedOn = item.AddedOn.Value,
                ItemImage = item.ImageData
            };
            return itemBO;
        }
        public void DeleteItemById(long id)
        {
            itemDAL.DeleteItemById(id);
        }
    }
}