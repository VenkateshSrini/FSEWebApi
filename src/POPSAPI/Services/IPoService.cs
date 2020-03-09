using POPSAPI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POPSAPI.Services
{
    public interface IPoService
    {
        Task<bool> Add(PoVM povm);
        Task<bool> Edit(PoVM povm);
        Task<bool> Delete(string poID);
        Task<List<PoVM>> GetAllPos();
        Task<PoVM> GetPobyId(string poId);
    }
}
