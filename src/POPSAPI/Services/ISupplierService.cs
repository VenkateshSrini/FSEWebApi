using POPSAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Services
{
    public interface ISupplierService
    {
        Task<bool> Add(SupplierVM supplierVM);
        Task<bool> Edit(SupplierVM supplierVM);
        Task<bool> Delete(string supplierId);
        Task<SupplierVM> GetSupplierById(string iD);
        Task<List<SupplierVM>> GetAllSupplier();
    }
}
