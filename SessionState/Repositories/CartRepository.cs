using Newtonsoft.Json;
using RoutineApi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace RoutineApi.Repositories
{
    public class CartRepository
    {
        internal IEnumerable<Cart> ReadAll()
        {
            return LoadData();
        }

        internal Cart Read(Guid id)
        {
            var carts = LoadData();
            return carts.Find(cart => cart.ID == id);
        }

        internal void Create(Cart cart)
        {
            var carts = LoadData();
            cart.ID = Guid.NewGuid();
            carts.Add(cart);
            SaveData(carts);
        }

        internal void Update(Guid id, Cart cart)
        {
            var carts = LoadData();
            var cartToUpdate = carts.Find(data => data.ID == id);
            cartToUpdate.ProductName = cart.ProductName;
            cartToUpdate.ProductQuantity = cart.ProductQuantity;
            SaveData(carts);
        }

        internal void Delete(Guid id)
        {
            var doctors = LoadData();
            var doctorToRemove = doctors.Find(data => data.ID == id);
            doctors.Remove(doctorToRemove);
            SaveData(doctors);
        }

        private List<Cart> LoadData()
        {
            // dataString e Jason file ta nibe. JasonConvert.DeserializeObject eta theke list of course dibe 
            var dataString = File.ReadAllText("D:/3-2/SWE 4602 (SDA Lab)/Assignments/Assignment 3/32-patientapi/RoutineApi/Data/Cart.json");
            return JsonConvert.DeserializeObject<List<Cart>>(dataString);
        }
        private void SaveData(List<Cart> courses)
        {
            // dataString e Jason file ta nibe. JasonConvert.DeserializeObject eta theke list of course dibe 
            var dataString = JsonConvert.SerializeObject(courses, Formatting.Indented);
            File.WriteAllText("D:/3-2/SWE 4602 (SDA Lab)/Assignments/Assignment 3/32-patientapi/RoutineApi/Data/Cart.json", dataString);
        }
    }
}
