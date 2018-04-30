using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServiceBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceBookStore.Controllers
{
    [Produces("application/json")]
    [Route("api/ShoppingBasket")]
    public class ShoppingBasketController : Controller
    {
        // GET: api/ShoppingBasket
        [HttpGet]
        public IEnumerable<ShoppingBasket> Get()
        {
            ShoppingBasketRepository r = new ShoppingBasketRepository();
            return r.GetAll();
        }

        // GET: api/ShoppingBasket/GetAll
        [HttpGet("GetAll")]
        public IEnumerable<ShoppingBasket> GetAll()
        {
            ShoppingBasketRepository r = new ShoppingBasketRepository();
            return r.GetAll();
        }

        // GET: api/ShoppingBasket/GetById/5
        [HttpGet("GetById/{id}")]
        public ShoppingBasket Get(int id)
        {
            ShoppingBasketRepository r = new ShoppingBasketRepository();
            return r.GetById(id);
        }
        
        // POST: api/ShoppingBasket/Insert
        [HttpPost("Insert")]
        public void Post([FromBody]ShoppingBasket value)
        {
            ShoppingBasketRepository r = new ShoppingBasketRepository();
            r.Insert(value);
        }

        // PUT: api/ShoppingBasket/Update
        [HttpPut("Update")]
        public void Put([FromBody]ShoppingBasket value)
        {
            ShoppingBasketRepository r = new ShoppingBasketRepository();
            r.Update(value);
        }

        // DELETE: api/ShoppingBasket/Delete/5
        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            ShoppingBasketRepository r = new ShoppingBasketRepository();
            r.Delete(id);
        }
    }
}