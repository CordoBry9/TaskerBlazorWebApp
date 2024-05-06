using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEWWEBAPP.Client.Models;
using NEWWEBAPP.Client.Services.Interfaces;
using NEWWEBAPP.Helpers.Extensions;
using static System.Net.WebRequestMethods;

namespace NEWWEBAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskerItemsController : ControllerBase
    {
        //Access a service that communicates with the database ApplicationDbContext???
        private readonly ITaskerItemService _taskerItemService;
        private string _userId => User.GetUserId()!; //string field

        public TaskerItemsController(ITaskerItemService taskerItemService)
        {
            _taskerItemService = taskerItemService;
        }

        [HttpPost]
        public async Task<ActionResult<TaskerItemDTO>> PostDbTaskerItem([FromBody] TaskerItemDTO taskerItem)
        {
            TaskerItemDTO createdItem = await _taskerItemService.CreateTaskerItemAsync(taskerItem, _userId);

            return Ok(createdItem);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<TaskerItemDTO>>> GetDBTaskerItems()
        {
            IEnumerable<TaskerItemDTO> taskerItems = await _taskerItemService.GetTaskerItemsAsync(_userId);

            return Ok(taskerItems);

        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateTaskerItem([FromRoute] Guid id, [FromBody] TaskerItemDTO taskerItemDTO)
        {
            if (id != taskerItemDTO.Id)
                return BadRequest("ID mismatch");

            await _taskerItemService.UpdateTaskerItemAsync(id, taskerItemDTO, _userId);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTaskerItem([FromRoute] Guid id)
        {
            await _taskerItemService.DeleteTaskerItemAsync(id, _userId);
            return NoContent();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TaskerItemDTO>> GetDBTaskerItemById([FromRoute] Guid id)
        {
            TaskerItemDTO taskerItems = await _taskerItemService.GetTaskerItemByIdAsync(id);

            return Ok(taskerItems);

        }
    }
}
