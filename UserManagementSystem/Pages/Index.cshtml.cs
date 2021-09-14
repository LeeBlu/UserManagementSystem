using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.API.Model.Interface;
using UserManagementSystem.Model;
using UserManagementSystem.Services.Interface;

namespace UserManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserservice _userRepository;

        public IEnumerable<User> User { get; set; }
        public IndexModel(IUserservice userRepository)
        {
            this._userRepository = userRepository;
        }
        
        public void OnGet()
        {
            User = _userRepository.GetAllUsers().Result;
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {

            await _userRepository.DeleteUser(id);
            return RedirectToPage();
        }
    }
}
