using AutoMapper;
using Microsoft.Extensions.Logging;
using POPSAPI.Model;
using POPSAPI.Repository;
using POPSAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Services
{
    public class SupplierService:ISupplierService
    {
        private readonly IMapper mapper;
        private readonly ISupplierRepo supplierRepo;
        private readonly ILogger<SupplierService> logger;
        public SupplierService(IMapper mapper, ISupplierRepo supplierRepo,
            ILogger<SupplierService> logger)
        {
            this.mapper = mapper;
            this.supplierRepo = supplierRepo;
            this.logger = logger;
        }

        public async Task<bool> Add(SupplierVM supplierVM)
        {
            Supplier supplier = mapper.Map<Supplier>(supplierVM);
            return await supplierRepo.AddSupplier(supplier);
        }

        public async Task<bool> Delete(string supplierId)
        {
            return await supplierRepo.DeleteSupplier(supplierId);
        }

        public async Task<bool> Edit(SupplierVM supplierVM)
        {
            Supplier supplier = mapper.Map<Supplier>(supplierVM);
            return ((await supplierRepo.UpdateSupplier(supplier)) == null) ?
                true : false;

        }

        public async Task<List<SupplierVM>> GetAllSupplier()
        {
            var suppliers = await supplierRepo.GetAllSupplier();
            List<SupplierVM> supplierVMS = mapper.Map<List<SupplierVM>>(suppliers);
            return supplierVMS;
        }

        public async Task<SupplierVM> GetSupplierById(string iD)
        {
            var supplier = await supplierRepo.GetSupplierById(iD);
            var supplierVM = mapper.Map<SupplierVM>(supplier);
            return supplierVM;

        }
    }
}
