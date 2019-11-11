using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Model.Entity;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            using (var db = new OrdersDbContext())
            {
                var orders = db.Orders.ToList();
                return orders;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(long id)
        {
            using (var db = new OrdersDbContext())
            {
                return db.Orders.Find(id);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public  void Put(long id, [FromHeader]int invoce)
        {
            using (var db = new OrdersDbContext())
            {
                var order = db.Orders.Find(id);
                order.InvoiceNumber = invoce;
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(long id, [FromHeader]Byte status)
        {
            using (var db = new OrdersDbContext())
            {
                var order = db.Orders.Find(id);
                order.OrderStatus = status;
                db.Orders.Update(order);
                db.SaveChanges();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(WebApplication1.Model.Orders));
            using (var sr = new StringReader(value))
            {
                var orders = (WebApplication1.Model.Orders)ser.Deserialize(sr);
                using (var db = new OrdersDbContext())
                {
                    var orderToAdd = new Order();
                    orderToAdd.OxId = orders.Order.Oxid;
                    orderToAdd.OrderDatetime = DateTime.Parse(orders.Order.Orderdate);
                    var order = db.Orders.Add(orderToAdd);
                    db.SaveChanges();
                }
            }

        }

       
    }
}
