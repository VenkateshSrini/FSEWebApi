using AutoMapper;
using Microsoft.Extensions.Logging;
using POPSAPI.Model;
using POPSAPI.Repository;
using POPSAPI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POPSAPI.Services
{
    public class PoService : IPoService
    {
        private IMapper mapper;
        private IPORepo poRepo;
        private readonly ILogger<PoService> logger;
        public PoService(IMapper mapper, IPORepo poRepo, ILogger<PoService> logger)
        {
            this.mapper = mapper;
            this.poRepo = poRepo;
            this.logger = logger;
        }

        public async Task<bool> Add(PoVM povm)
        {
            PoMaster poMaster = mapper.Map<PoMaster>(povm);
            return await poRepo.AddPo(poMaster);
        }

        public async Task<bool> Edit(PoVM povm)
        {
            PoMaster poMaster = mapper.Map<PoMaster>(povm);
            return ((await poRepo.EditPo(poMaster) != null) ? true : false);
        }

        public async Task<bool> Delete(string poID)
        {
            return await poRepo.DeletePo(poID);
        }

        public async Task<List<PoVM>> GetAllPos()
        {
            var poMasters = await poRepo.GetAllPos();
            var poVMS = mapper.Map<List<PoVM>>(poMasters);
            return poVMS;
        }

        public async Task<PoVM> GetPobyId(string poId)
        {
            var poMaster = await poRepo.GetPoMaster(poId);
            return mapper.Map<PoVM>(poMaster);

        }
    }
}
