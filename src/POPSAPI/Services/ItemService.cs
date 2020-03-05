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
    public class ItemService:IItemService
    {
        IMapper mapper;
        IItemRepo itemRepo;
        ILogger<ItemService> logger;
        public ItemService(IMapper mapper, IItemRepo itemRepo,
            ILogger<ItemService> logger)
        {
            this.mapper = mapper;
            this.itemRepo = itemRepo;
            this.logger = logger;
        }

        public async Task<bool> Add(ItemVM items)
        {
            Item dbItem = mapper.Map<Item>(items);
            return await itemRepo.AddItem(dbItem);
        }

        public async Task<bool> Delete(string itemId)
        {
            return await itemRepo.DeleteItem(itemId);
        }

        public async Task<bool> Edit(ItemVM item)
        {
            Item dbItem = mapper.Map<Item>(item);
            return (((await itemRepo.EditItem(dbItem)) != null) ? true : false);

        }

        public async Task<List<ItemVM>> GetAllItems()
        {
            var items = await itemRepo.GetAllItem();
            var itemVMS = mapper.Map<List<ItemVM>>(items);
            return itemVMS;
        }

        public async Task<ItemVM> GetItemById(string itemId)
        {
            var item = await itemRepo.GetItemById(itemId);
            var itemVM = mapper.Map<ItemVM>(item);
            return itemVM;
        }
    }
}
