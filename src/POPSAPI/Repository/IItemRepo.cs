using POPSAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Repository
{
    public interface IItemRepo
    {
        Task<bool> AddItem(Item item);
        Task<Item> EditItem(Item item);
        Task<bool> DeleteItem(string itemId);
        Task<Item> GetItemById(string itemId);
        Task<List<Item>> GetAllItem();

    }
}
