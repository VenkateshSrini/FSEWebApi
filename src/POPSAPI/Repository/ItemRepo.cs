using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POPSAPI.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POPSAPI.Repository
{
    public class ItemRepo : IItemRepo
    {
        private POPSContext dbContext;
        private readonly ILogger<ItemRepo> logger;
        public ItemRepo(POPSContext context, ILogger<ItemRepo> logger)
        {
            dbContext = context;
            this.logger = logger;
        }

        public async Task<bool> AddItem(Item item)
        {
            long nextMax = 0;
            var connection = dbContext.Database.GetDbConnection();
            
                if (connection.State == System.Data.ConnectionState.Closed)
                    connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT nextval('Itemserial');";
                nextMax = (long)command.ExecuteScalar();
            
            item.ItemCode = $"I{nextMax}";
            await dbContext.Items.AddAsync(item);
            var recordsAffected = await dbContext.SaveChangesAsync();
            return (recordsAffected > 0) ? true : false;

        }

        public async Task<Item> EditItem(Item item)
        {
            dbContext.Items.Update(item);
            var recordsAffected = await dbContext.SaveChangesAsync();
            return (recordsAffected > 0) ? item : null;
        }

        public async Task<bool> DeleteItem(string itemId)
        {
            var delItem = dbContext.Items.Find(itemId);
            if (delItem == null)
                throw new ApplicationException("Item not found");
            dbContext.Items.Remove(delItem);
            var recordsAffected = await dbContext.SaveChangesAsync();
            return (recordsAffected > 0) ? true : false;

        }

        public async Task<Item> GetItemById(string itemId)
        {
            return await dbContext.Items.FindAsync(itemId);
        }

        public async Task<List<Item>> GetAllItem()
        {
            return await dbContext.Items.ToListAsync();
        }
    }
}
