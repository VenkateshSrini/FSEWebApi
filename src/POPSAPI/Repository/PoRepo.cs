using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using POPSAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POPSAPI.Repository
{
    public class PoRepo:IPORepo
    {
        private POPSContext dbContext;
        private ILogger<PoRepo> logger;
        public PoRepo(POPSContext context, ILogger<PoRepo> logger)
        {
            dbContext = context;
            this.logger = logger;
        }

        public async Task<bool> AddPo(PoMaster poMaster)
        {
            int nextMax = 0;
            using (var connection = dbContext.Database.GetDbConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT nextval('POSerial');";
                nextMax = (int)command.ExecuteScalar();
            }
            poMaster.PoNumber = $"p{nextMax}";
            poMaster.Details?.ForEach(podetail =>
            {
                podetail.PuchaseOrderNumber = poMaster.PoNumber;
            });
            await dbContext.PoMasters.AddAsync(poMaster);
            var recordsAffected = await dbContext.SaveChangesAsync();
            return (recordsAffected > 0) ? true : false;

        }

        public async Task<bool> DeletePo(string Pono)
        {
            var po = await dbContext.PoMasters.FindAsync(Pono);
             dbContext.PoMasters.Remove(po);
            var recordsAffected = await dbContext.SaveChangesAsync();
            return (recordsAffected > 0) ? true : false;
        }

        public async Task<PoMaster> EditPo(PoMaster poMaster)
        {
            dbContext.Update(poMaster);
            var recordsAffected = await dbContext.SaveChangesAsync();
            return (recordsAffected > 0) ? poMaster : null;
        }

        public async Task<List<PoMaster>> GetAllPos()
        {
            return await dbContext.PoMasters.Include(pom=>pom.Details)
                   .ToListAsync();
        }

        public async Task<PoMaster> GetPoMaster(string Pono)
        {
            return await dbContext.PoMasters.Include(pom => pom.Details)
                                            .FirstOrDefaultAsync(pom => (pom.PoNumber.CompareTo(Pono) == 0));
        }
    }
}
