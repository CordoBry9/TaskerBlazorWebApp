using Microsoft.EntityFrameworkCore;
using NEWWEBAPP.Data;
using NEWWEBAPP.Models;
using NEWWEBAPP.Services.Interfaces;

namespace NEWWEBAPP.Services
{
    public class TaskerItemRepository : ITaskerItemRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public TaskerItemRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {

            _contextFactory = contextFactory;
        }



        public async Task<TaskerItem> CreateTaskerItemAsync(TaskerItem item)
        {
            using var context = _contextFactory.CreateDbContext(); //look up more about using statements

            await context.TaskerItems.AddAsync(item);
            await context.SaveChangesAsync();

            return item;
        }

        public async Task<IEnumerable<TaskerItem>> GetTaskerItemsAsync(string userId)
        {
            using var context = _contextFactory.CreateDbContext(); //instatiation of the database, coming from the factory made thru dependency injection

            IEnumerable<TaskerItem> taskerItems = await context.TaskerItems.Where(t => t.UserId == userId).ToListAsync();

            return taskerItems;
        }


        public async Task<TaskerItem> GetTaskerItemByIdAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var item = await context.TaskerItems.FindAsync(id);
            if (item == null)
                throw new Exception($"No tasker item found with ID {id}");
            return item;
        }



        public async Task DeleteTaskerItemAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var item = await context.TaskerItems.FindAsync(id);
            if (item == null)
                throw new Exception($"No tasker item found with ID {id}");

            context.TaskerItems.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTaskerItemAsync(Guid id, TaskerItem updatedItem)
        {
            using var context = _contextFactory.CreateDbContext();
            var item = await context.TaskerItems.FindAsync(id);
            if (item == null)
                throw new Exception($"No tasker item found with ID {id}");

            item.Name = updatedItem.Name;
            item.IsComplete = updatedItem.IsComplete;
            context.TaskerItems.Update(item);
            await context.SaveChangesAsync();
        }


    }
}

