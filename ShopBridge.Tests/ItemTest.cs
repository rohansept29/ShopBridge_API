using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBridge_API;
using ShopBridge_API.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using ShopBridge_API.Models;
using ShopBridge_API.DAL;

namespace ShopBridge.Tests
{
    [TestClass]
    public class ItemTest
    {

        [TestMethod]
        public void TestGetAllItems()
        {
            var controller = new ItemsController();
            IHttpActionResult actionResult = controller.GetItems();

            var contentResult = actionResult as OkNegotiatedContentResult<List<ItemBO>>;
            Assert.IsNotNull(contentResult);
            List<Item> items;
            using (ShopBridgeEntities db = new ShopBridgeEntities())
            {
                items = db.Items.ToList();
            }
            List<ItemBO> itemBOs = new List<ItemBO>();
            foreach (var item in items)
            {
                itemBOs.Add(new ItemBO
                {
                    Id = item.ItemId,
                    Name = item.Name,
                    Description = item.ItemDescription,
                    Price = item.Price.Value,
                    AddedOn = item.AddedOn.Value,
                    ItemImage = item.ImageData
                });
            }
            Assert.AreEqual(itemBOs.Count, contentResult.Content.Count);
        }
        [TestMethod]
        public void TestGetItemById()
        {
            var controller = new ItemsController();
            var actionResult = controller.GetItemById(1);
            var contentResult = actionResult as OkNegotiatedContentResult<ShopBridge_API.Models.ItemBO>;
            Assert.IsNotNull(contentResult);
            Item item;
            using (ShopBridgeEntities db = new ShopBridgeEntities())
            {
                item = db.Items.SingleOrDefault(x => x.ItemId.Equals(1));
            }
            ItemBO itemBO = new ItemBO
            {
                Name = item.Name,
                Description = item.ItemDescription,
                Price = item.Price.Value,
                AddedOn = DateTime.Now,
                ItemImage = item.ImageData
            };
            var product = contentResult.Content;
            Assert.AreEqual(itemBO.Name, contentResult.Content.Name);
        }
        [TestMethod]
        public void TestSaveItem()
        {
            // Arrange  
            var controller = new ItemsController();
            ItemBO item = new ItemBO
            {
                Name = "Notebook",
                Description = "A notebook is a book or stack of paper pages that are often ruled and used for purposes such as recording notes or memoranda",
                Price = 70
            };
            // Act  
            IHttpActionResult actionResult = controller.SaveItem(item);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<ItemBO>;
            // Assert  
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.IsNotNull(createdResult.RouteValues["id"]);
        }
        [TestMethod]
        public void TestDeleteItemById()
        {
            // Arrange
            var controller = new ItemsController();

            // Act
            IHttpActionResult actionResult = controller.DeleteItemById(19);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
    }
}
