using ShopBridge_API.BLL;
using ShopBridge_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge_API.Controllers
{
    public class ItemsController : ApiController
    {
        ItemBLL itemBLL = new ItemBLL();
        [HttpPost]
        public IHttpActionResult SaveItem(ItemBO item)
        {
            if (item == null)
                return BadRequest();
            itemBLL.SaveItem(item);
            return CreatedAtRoute("DefaultApi", new { id = item.Id }, item);
        }
        [HttpGet]
        public IHttpActionResult GetItems()
        {
            List<ItemBO> items = itemBLL.GetItems();
            if (items == null)
                return NotFound();
            return Ok(items);
        }
        [HttpGet]
        public IHttpActionResult GetItemById(long id)
        {
            ItemBO item = itemBLL.GetItemById(id);
            if (item == null)
                return BadRequest();
            return Ok(item);
        }
        [HttpDelete]
        public IHttpActionResult DeleteItemById(long id)
        {
            if (id <= 0)
                return BadRequest();
            itemBLL.DeleteItemById(id);
            return Ok();
        }
    }
}
