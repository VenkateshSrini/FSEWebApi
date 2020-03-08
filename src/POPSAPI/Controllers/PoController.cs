using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POPSAPI.Services;
using POPSAPI.ViewModel;
using Swashbuckle.AspNetCore.Annotations;

namespace POPSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Purchase order")]
    public class PoController : ControllerBase
    {
        private IMapper mapper;
        private IPoService poService;
        private ILogger<PoController> logger;
        public PoController(IMapper mapper, IPoService poService, ILogger<PoController> logger)
        {
            this.mapper = mapper;
            this.poService = poService;
            this.logger = logger;
        }
        // GET: api/Po
        /// <summary>
        /// Get All the purchase order
        /// </summary>
        /// <returns>Lsit of Purchase order view model</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PoVM>>> Get()
        {
            var poVms = await poService.GetAllPos();
            if ((poVms != null) && (poVms.Count > 0))
                return Ok(poVms);
            else
                return NotFound("No PoVM present");

        }

        // GET: api/Po/5
        /// <summary>
        /// Get the PO id by
        /// </summary>
        /// <param name="poId">Id of purchase order</param>
        /// <returns>Return purchase ordervm</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PoVM>> Get(string  poId)
        {
            if (string.IsNullOrWhiteSpace(poId))
            {
                ModelState.AddModelError("POIDEMpty", "PO ID is empty");
                return BadRequest(ModelState);
            }
            var poVM = await poService.GetPobyId(poId);
            if (poVM != null)
                return Ok(poVM);
            else
                return NotFound("VM result not found");
                
        }

        // POST: api/Po
        /// <summary>
        /// Creates po
        /// </summary>
        /// <param name="poVm"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<bool>> Post(PoVM poVm)
        {
            if (poVm==null)
            {
                ModelState.AddModelError("POMOdelEmpty", "Po model is empty");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await poService.Add(poVm);
            if (!result)
                return StatusCode(500, "Operation could not be processed");
            else
                return Created($"api/po/{poVm.ID}", result);
        }

        // PUT: api/Po/5
        /// <summary>
        /// Update purchase order.
        /// </summary>
        /// <param name="poVm">Viw model to be updated</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<bool>> Put(PoVM poVm)
        {
            if (poVm == null)
            {
                ModelState.AddModelError("POMOdelEmpty", "Po model is empty");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await poService.Edit(poVm);
            if (!result)
                return StatusCode(500, "Operation could not be processed");
            else
                return Accepted($"api/po/{poVm.ID}");

        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Deletes the PoID
        /// </summary>
        /// <param name="poID">purchase order Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> Delete(string  poID)
        {
            if (string.IsNullOrEmpty(poID))
            {
                ModelState.AddModelError("paramEmpty", "ID cannot be empty");
                return BadRequest(ModelState);
            }
            var result = await poService.Delete(poID);
            return (result) ? Ok(result) : StatusCode(500, "Request could not be processed");
        }
    }
}
