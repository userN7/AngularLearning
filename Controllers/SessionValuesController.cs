using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ServerApp.Models;
using ServerApp.Models.BindingTargets;

namespace ServerApp.Controllers
{
    [Route("/api/session")]
    [ApiController]
    public class SessionValuesController : Controller
    {
        [HttpGet("cart")]
        public IActionResult GetCart() {
            return Ok(HttpContext.Session.GetString("cart"));
        }

        [HttpPost("cart")]
        public void StoreCart([FromBody] ProductionSelection[] products) {
            var jsonData = JsonConvert.SerializeObject(products);
            HttpContext.Session.SetString("cart", jsonData);
        }

        [HttpGet("checkout")]
        public IActionResult GetCheckout() => Ok(HttpContext.Session.GetString("checkout"));

        [HttpPost("checkout")]
        public void StroeCheckout([FromBody] CheckoutState data)
        {
            HttpContext.Session.SetString("checkout", JsonConvert.SerializeObject(data));
        }
    }
}