using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RoutineApi.Models;
using RoutineApi.Repositories;

namespace RoutineApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartRepository cartRepository;
        public CartController(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return cartRepository.ReadAll();
        }

        [HttpGet("[controller]/{id}")]
        public Cart Get(Guid id)
        {
            return cartRepository.Read(id);
        }

        [HttpPost("[controller]/add")]
        public void Post([FromBody] Cart cart)
        {
            cartRepository.Create(cart);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Cart cart)
        {
            cartRepository.Update(id, cart);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            cartRepository.Delete(id);
        }
    }
}
