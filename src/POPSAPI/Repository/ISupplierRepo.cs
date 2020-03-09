using POPSAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POPSAPI.Repository
{
    public interface ISupplierRepo
    {
        public Task<bool> AddSupplier(Supplier supplier);
        public Task<Supplier> UpdateSupplier(Supplier supplier);
        public Task<bool> DeleteSupplier(string supplierId);
        public Task<Supplier> GetSupplierById(string supplierId);
        public Task<List<Supplier>> GetAllSupplier();

    }
}
