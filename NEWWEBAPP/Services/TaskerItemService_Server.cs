using Microsoft.EntityFrameworkCore.Query;
using NEWWEBAPP.Client.Models;
using NEWWEBAPP.Client.Services.Interfaces;
using NEWWEBAPP.Models;
using NEWWEBAPP.Services.Interfaces;

namespace NEWWEBAPP.Services
{
    public class TaskerItemService_Server : ITaskerItemService //interface implementation
    {
        //need a way to talk to the database appdbcontext (dependency injection)
        private readonly ITaskerItemRepository _taskerItemRepository;

        public TaskerItemService_Server(ITaskerItemRepository taskerItemRepository)
        {
            _taskerItemRepository = taskerItemRepository;
        }

        public async Task<TaskerItemDTO> CreateTaskerItemAsync(TaskerItemDTO taskerItem, string userId)
        {
            TaskerItem newTaskerItem = new()
            {
                Name = taskerItem.Name,
                IsComplete = taskerItem.IsComplete,
                UserId = userId,
            };

            TaskerItem createdTaskerItem = await _taskerItemRepository.CreateTaskerItemAsync(newTaskerItem);

            return createdTaskerItem.ToDTO();
        }

        public async Task<List<TaskerItemDTO>> GetTaskerItemsAsync(string userId)
        {
            IEnumerable<TaskerItem> taskerItems = await _taskerItemRepository.GetTaskerItemsAsync(userId);

            List<TaskerItemDTO> taskerItemDTOs = new List<TaskerItemDTO>();

            foreach (TaskerItem item in taskerItems)
            {
                TaskerItemDTO itemDTO = item.ToDTO();

                taskerItemDTOs.Add(itemDTO);
            }

            return taskerItemDTOs;
        }

        public async Task UpdateTaskerItemAsync(Guid id, TaskerItemDTO updatedTaskerItemDTO, string userId)
        {
            TaskerItem updatedItem = new TaskerItem()
            {
                Id = id,
                Name = updatedTaskerItemDTO.Name,
                IsComplete = updatedTaskerItemDTO.IsComplete,
                UserId = userId
            };

            await _taskerItemRepository.UpdateTaskerItemAsync(id, updatedItem);
        }

        public async Task DeleteTaskerItemAsync(Guid id, string userId)
        {
            await _taskerItemRepository.DeleteTaskerItemAsync(id);
        }

        public async Task<TaskerItemDTO> GetTaskerItemByIdAsync(Guid id)
        {
            TaskerItem taskerItem = await _taskerItemRepository.GetTaskerItemByIdAsync(id);

            return taskerItem.ToDTO();
        }
    }
}
