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
        Task<bool> DeletePo(string Pono);
        Task<PoMaster> GetPoMaster(string Pono);
        Task<List<PoMaster>> GetAllPos();
    }
}
