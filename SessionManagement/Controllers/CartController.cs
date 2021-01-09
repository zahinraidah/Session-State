using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CartManagement.Models;
using CartManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        CartAction cartAction = new CartAction();

        [HttpPost]
        [Route("add/{item}")]
        public void add([FromRoute] string item)
        {
            string sessionId = Request.Headers["sessionId"];
            if (sessionId == null)
            {
                Guid id = cartAction.cartGenerate();
                Response.Headers.Add("sessionId", id.ToString());
                cartAction.addItem(id, item);
            }
            else
            {
                cartAction.addItem(Guid.Parse(sessionId), item);
            }
        }

        [HttpDelete]
        [Route("remove/{item}")]
        public void remove([FromRoute] string item)
        {
            string sessionId = Request.Headers["sessionId"];
            cartAction.removeItem(Guid.Parse(sessionId), item);
        }

        [HttpDelete]
        [Route("decrease/{item}")]
        public void decrease([FromRoute] string item)
        {
            string sessionId = Request.Headers["sessionId"];
            cartAction.decreaseItem(Guid.Parse(sessionId), item);
        }

        [HttpGet]
        public Cart getCartInfo()
        {
            string sessionId = Request.Headers["sessionId"];
            if (sessionId == null)
            {
                return null;
            }
            else
            {
                return cartAction.getCart(Guid.Parse(sessionId));
            }
        }

    }
}
