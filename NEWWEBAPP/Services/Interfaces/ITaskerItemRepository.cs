using NEWWEBAPP.Models;

namespace NEWWEBAPP.Services.Interfaces
{
    public interface ITaskerItemRepository
    {
        Task<IEnumerable<TaskerItem>> GetTaskerItemsAsync(string userId);
        Task<TaskerItem> CreateTaskerItemAsync(TaskerItem newTaskerItem);
        Task<TaskerItem> GetTaskerItemByIdAsync(Guid id);
        Task DeleteTaskerItemAsync(Guid id);
        Task UpdateTaskerItemAsync(Guid id, TaskerItem updatedItem);


    }
}
