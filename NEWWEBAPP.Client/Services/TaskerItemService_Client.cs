using NEWWEBAPP.Client.Models;
using NEWWEBAPP.Client.Services.Interfaces;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace NEWWEBAPP.Client.Services
{
    public class TaskerItemService_Client : ITaskerItemService
    {

        private readonly HttpClient _httpClient;

        public TaskerItemService_Client(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaskerItemDTO> CreateTaskerItemAsync(TaskerItemDTO taskerItem, string userId)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/TaskerItems", taskerItem);
            response.EnsureSuccessStatusCode();

            TaskerItemDTO? taskerItemDTO = await response.Content.ReadFromJsonAsync<TaskerItemDTO>();
            return taskerItemDTO!;
        }

        public async Task<List<TaskerItemDTO>> GetTaskerItemsAsync(string userId)
        {

                List<TaskerItemDTO> taskerItems = await _httpClient.GetFromJsonAsync<List<TaskerItemDTO>>("api/TaskerItems") ?? [];

                return taskerItems;
            
            
        }

        public async Task UpdateTaskerItemAsync(Guid id, TaskerItemDTO updatedTaskerItem, string userId)
        {
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"api/TaskerItems/{id}", updatedTaskerItem);
            response.EnsureSuccessStatusCode(); 
        }

        public async Task DeleteTaskerItemAsync(Guid id, string userId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"api/TaskerItems/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<TaskerItemDTO> GetTaskerItemByIdAsync(Guid id)
        {
            TaskerItemDTO? taskerItem = await _httpClient.GetFromJsonAsync<TaskerItemDTO>($"api/TaskerItems/{id}");

            return taskerItem;

            //TaskerItemDTO? taskerItem = await _httpClient.GetFromJsonAsync<TaskerItemDTO>($"api/TaskerItems/{id}");
            //return taskerItem;
        }
    }
}
