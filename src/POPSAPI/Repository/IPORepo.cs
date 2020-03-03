using POPSAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Repository
{
    public interface IPORepo
    {
        Task<bool> AddPo(PoMaster poMaster);
        Task<PoMaster> EditPo(PoMaster poMaster);
        Task<bool> DeletePo(string Pono, string itemCode);
        Task<PoMaster> GetPoMaster(string Pono, string itemCode);
        Task<List<PoMaster>> GetAllPos();
    }
}
