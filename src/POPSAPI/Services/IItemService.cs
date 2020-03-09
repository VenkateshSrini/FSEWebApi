using POPSAPI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POPSAPI.Services
{
    public interface IItemService
    {
        Task<bool> Add(ItemVM items);
        Task<bool> Edit(ItemVM item);
        Task<bool> Delete(string itemId);
        Task<ItemVM> GetItemById(string itemId);
        Task<List<ItemVM>> GetAllItems();
    }
}
