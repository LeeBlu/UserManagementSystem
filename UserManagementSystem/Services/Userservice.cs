using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using UserManagementSystem.Model;
using UserManagementSystem.Services.Interface;

namespace UserManagementSystem.Services
{
    public class Userservice : IUserservice
    {
        private readonly HttpClient httpClient;

        public Userservice(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<User> CreateUser(User newUser)
        {

            string jsonuser= JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(jsonuser, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"api/User/", stringContent);
            var result = response.Content.ReadAsStringAsync();
            var _user = JsonSerializer.Deserialize(result.Result, typeof(User), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return _user as User;
        }

        public async Task DeleteUser(int id)
        {
            await httpClient.DeleteAsync($"api/User/{id}");
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var response = await httpClient.GetAsync($"api/User/");
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync();
            var _user = JsonSerializer.Deserialize(result.Result, typeof(List<User>), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return _user as List<User>;
        }

        public async Task<User> GetUser(int id)
        {
            var response = await httpClient.GetAsync($"api/User/{id}");
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync();
            var _user = JsonSerializer.Deserialize(result.Result, typeof(User), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return _user as User;
        }

        public async Task<User> UpdateUser(User updatedUser)
        {
            string jsonuser = JsonSerializer.Serialize(updatedUser);
            var stringContent = new StringContent(jsonuser, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/User", stringContent);
           // return await httpClient.PutAsync<User>("api/employees", updatedUser);
            var result = response.Content.ReadAsStringAsync();
            var _user = JsonSerializer.Deserialize(result.Result, typeof(User), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return _user as User;
        }
    }
}


