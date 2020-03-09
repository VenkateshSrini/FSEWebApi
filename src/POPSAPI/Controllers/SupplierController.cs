using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POPSAPI.Services;
using POPSAPI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// <summary>
        /// Gets all the suppliers. 
        /// </summary>
        /// <returns>List of supplier</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SupplierVM>>> Get()
        {
            var suppliers = await supplierService.GetAllSupplier();
            if ((suppliers != null) && (suppliers.Count > 0)) return Ok(suppliers);
            return NotFound("No suppliers found");

        }

        // GET: api/Supplier/5
        /// <summary>
        /// Get those supplier that match the id. The is is provided as path parameter. example
        /// api/Supplier/5
        /// </summary>
        /// <param name="id">Supplier id</param>
        /// <returns>Supplier object or error status</returns>
        [HttpGet("{id}")]
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
            var supplier = await supplierService.GetSupplierById(id);
            if (supplier == null)
            {
                ModelState.AddModelError("paramEmpty", "ID cannot be empty");
                return NotFound(ModelState);
            }
            return Ok(supplier);
        }

        // POST: api/Supplier
        /// <summary>
        /// Creates a supplier
        /// </summary>
        /// <param name="supplierVM">View model of the supplier</param>
        /// <returns>state signalling whether the object was created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<bool>> Post(SupplierVM supplierVM)
        {
            if (supplierVM == null)
            {
                ModelState.AddModelError("paramEmpty", "Request cannot be empty");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await supplierService.Add(supplierVM);
            if (result == false)
            {


                return StatusCode(500, "Request could not be processed");
            }
            return Created($"api/supplier/{supplierVM.ID}", result);

        }

        // PUT: api/Supplier/5
        /// <summary>
        /// Updates the supplier. The supplier id is mandatory.
        /// </summary>
        /// <param name="supplierVM">Supplier view model</param>
        /// <returns>status of update</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<bool>> Put(SupplierVM supplierVM)
        {
            if (supplierVM == null)
            {
                ModelState.AddModelError("paramEmpty", "Request cannot be empty");
                return BadRequest(ModelState);
            }
            else if (string.IsNullOrWhiteSpace(supplierVM.ID))
            {
                ModelState.AddModelError("paramEmpty", "Id cannot be empty");
                return BadRequest(ModelState);
            }
            var result = await supplierService.Edit(supplierVM);
            if (result == false)
                return StatusCode(500, "Request could not be processed");

            return Accepted(result);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Deletes the provided supplier
        /// </summary>
        /// <param name="id">Supplier id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ModelState.AddModelError("paramEmpty", "ID cannot be empty");
                return BadRequest(ModelState);
            }
            var result = await supplierService.Delete(id);
            return (result) ? Ok(result) : StatusCode(500, "Request could not be processed");
        }
    }
}
