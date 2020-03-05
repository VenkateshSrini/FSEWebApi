using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POPSAPI.Services;
using POPSAPI.ViewModel;

namespace POPSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ISupplierService supplierService;
        private ILogger<SupplierController> logger;
        public SupplierController(ISupplierService supplierService, ILogger<SupplierController> logger)
        {
            this.supplierService = supplierService;
            this.logger = logger;
        }
        // GET: api/Supplier
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SupplierVM>>> Get()
        {
            var suppliers= await supplierService.GetAllSupplier();
            if ((suppliers != null) && (suppliers.Count > 0)) return suppliers;
                 
            return NotFound("No suppliers found");
                    
        }

        // GET: api/Supplier/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<SupplierVM>> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("paramEmpty", "ID cannot be empty");
                return BadRequest(ModelState);
            }
            var supplier= await supplierService.GetSupplierById(id);
            if (supplier==null)
            {
                ModelState.AddModelError("paramEmpty", "ID cannot be empty");
                return NotFound(ModelState);
            }
            return supplier;
        }

        // POST: api/Supplier
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Supplier/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
