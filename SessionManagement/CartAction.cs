using Newtonsoft.Json;
using CartManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CartManagement.Repositories
{
    public class CartAction
    {
        public Guid cartGenerate()
        {
            List<Cart> cartList = JsonConvert.DeserializeObject<List<Cart>>(File.ReadAllText("cart.json"));
            Cart newcart = new Cart();
            newcart.Id = Guid.NewGuid();
            newcart.items = new Dictionary<string, int>();
            cartList.Add(newcart);
            File.WriteAllText("cart.json", JsonConvert.SerializeObject(cartList, Formatting.Indented));
            return newcart.Id;
        }

        public void addItem(Guid id, string item)
        {
            List<Cart> cartList = JsonConvert.DeserializeObject<List<Cart>>(File.ReadAllText("cart.json"));
            var cart = cartList.Find(cart => cart.Id == id);
            bool newItem = true;
            foreach (var Item in cart.items.ToList())
            {
                if (Item.Key == item)
                {
                    cart.items[Item.Key] += 1;
                    newItem = false;
                }
            }
            if (newItem)
            {
                cart.items[item] = 1;
            }
            File.WriteAllText("cart.json", JsonConvert.SerializeObject(cartList, Formatting.Indented));
        }

        public void removeItem(Guid id, string item)
        {
            List<Cart> cartList = JsonConvert.DeserializeObject<List<Cart>>(File.ReadAllText("cart.json"));
            var cart = cartList.Find(cart => cart.Id == id);
            foreach (var product in cart.items.ToList())
            {
                if (product.Key == item)
                {
                    cart.items.Remove(product.Key);
                }
            }
            File.WriteAllText("cart.json", JsonConvert.SerializeObject(cartList, Formatting.Indented));
        }

        public void decreaseItem(Guid id, string item)
        {
            List<Cart> cartList = JsonConvert.DeserializeObject<List<Cart>>(File.ReadAllText("cart.json"));
            var cart = cartList.Find(cart => cart.Id == id);
            foreach (var Item in cart.items.ToList())
            {
                if (Item.Key == item)
                {
                    if (Item.Value > 1)
                    {
                        cart.items[Item.Key] -= 1;
                    }
                    else
                    {
                        cart.items.Remove(Item.Key);
                    }
                }
            }
            File.WriteAllText("cart.json", JsonConvert.SerializeObject(cartList, Formatting.Indented));
        }

        public Cart getCart(Guid id)
        {
            List<Cart> cartList = JsonConvert.DeserializeObject<List<Cart>>(File.ReadAllText("cart.json"));
            return cartList.Find(cart => cart.Id == id);
        }

    }
}
