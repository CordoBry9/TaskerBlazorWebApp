using NEWWEBAPP.Client.Models;

namespace NEWWEBAPP.Client.Services.Interfaces
{
    public interface ITaskerItemService
    {
        Task<TaskerItemDTO> CreateTaskerItemAsync(TaskerItemDTO taskerItem, string userId);
        Task<List<TaskerItemDTO>> GetTaskerItemsAsync(string userId);
        Task UpdateTaskerItemAsync(Guid id, TaskerItemDTO updatedTaskerItemDTO, string userId);
        Task DeleteTaskerItemAsync(Guid id, string userId);
        Task<TaskerItemDTO> GetTaskerItemByIdAsync(Guid id);
    }
}
