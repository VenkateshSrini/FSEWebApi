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
    public class ItemController : ControllerBase
    {
        private IItemService itemService;
        private ILogger<ItemController> logger;
        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            this.itemService = itemService;
            this.logger = logger;
        }
        // GET: api/Item
        /// <summary>
        /// Get all the items from DB
        /// </summary>
        /// <returns>List of Items</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ItemVM>>> Get()
        {
            var items = await itemService.GetAllItems();
            if ((items != null) && (items.Count > 0))
                return Ok(items);
            else
                return NotFound("No Items found");
        }

        // GET: api/Item/5
        /// <summary>
        /// Get items based on Id
        /// </summary>
        /// <param name="ItemId"></param>
        /// <returns>return View model that meets id</returns>
        [HttpGet("{ItemId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ItemVM>> Get(string ItemId)
        {

            if (string.IsNullOrWhiteSpace(ItemId))
            {
                ModelState.AddModelError("ItemIdEmpty", "Item id is empty");
                return BadRequest(ModelState);
            }
            var item = await itemService.GetItemById(ItemId);
            if (item == null)
                return NotFound("No Items found");
            else
                return Ok(item);
        }

        // POST: api/Item
        /// <summary>
        /// creates a Items 
        /// </summary>
        /// <param name="itemVM">Item view model</param>
        /// <returns>success state</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<bool>> Post(ItemVM itemVM)
        {
            if (itemVM == null)
            {
                ModelState.AddModelError("paramEmpty", "Request cannot be empty");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await itemService.Add(itemVM);
            if (result)
                return Created($"api/Item/{itemVM.ID}", result);
            else
                return StatusCode(500, "Unable to process request");
        }

        // PUT: api/Item
        /// <summary>
        /// Updates the item. Id is mandatory
        /// </summary>
        /// <param name="itemVM">item view model</param>

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<ActionResult<bool>> Put(ItemVM itemVM)
        {
            if (itemVM == null)
            {
                ModelState.AddModelError("paramEmpty", "Request cannot be empty");
                return BadRequest(ModelState);
            }
            else if (string.IsNullOrWhiteSpace(itemVM.ID))
            {
                ModelState.AddModelError("paramEmpty", "Id cannot be empty");
                return BadRequest(ModelState);
            }
            var result = await itemService.Edit(itemVM);
            if (result)
                return Accepted(result);
            else
                return StatusCode(500, "Request could not be processed");
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Deletes the item. 
        /// </summary>
        /// <param name="id">Item id</param>
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
            var result = await itemService.Delete(id);
            return (result) ? Ok(result) : StatusCode(500, "Request could not be processed");
        }
    }
}
