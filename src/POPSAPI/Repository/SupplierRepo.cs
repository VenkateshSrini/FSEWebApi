using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POPSAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Repository
{
    public class SupplierRepo:ISupplierRepo
    {
        private POPSContext dbContext;
        private readonly ILogger<SupplierRepo> logger;
        public SupplierRepo(POPSContext context, ILogger<SupplierRepo> logger)
        {
            dbContext = context;
            this.logger = logger;
        }

        public async Task<bool> AddSupplier(Supplier supplier)
        {
            int nextMax = 0;
            using(var connection = dbContext.Database.GetDbConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT nextval('Supplierserial');";
                nextMax = (int)command.ExecuteScalar();
            }
            supplier.SupplierNumber = $"S{nextMax}";
            await dbContext.Suppliers.AddAsync(supplier);
            var recordsAffected = await dbContext.SaveChangesAsync();
            return (recordsAffected>0)?  true:false;
        }

        public async Task<Supplier> UpdateSupplier(Supplier supplier)
        {
            dbContext.Suppliers.Update(supplier);
            var recordsAffected = await dbContext.SaveChangesAsync();
            return (recordsAffected > 0)? supplier: null;

        }

        public async Task<bool> DeleteSupplier(string supplierId)
        {
            var supplierToBeDeleted = await dbContext.Suppliers.FindAsync(supplierId);
            if (supplierToBeDeleted == null)
                throw new ApplicationException("Supplier not found");
            dbContext.Suppliers.Remove(supplierToBeDeleted);
            var rowsAffected = await dbContext.SaveChangesAsync();
            return (rowsAffected > 0) ? true : false;

        }

        public async Task<Supplier> GetSupplierById(string supplierId)
        {
            return await dbContext.Suppliers.FindAsync(supplierId);
        }

        public async Task<List<Supplier>> GetAllSupplier()
        {
            return await dbContext.Suppliers.ToListAsync();
        }
    }
}
