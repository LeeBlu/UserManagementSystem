using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagementSystem.Model;
using UserManagementSystem.Services.Interface;

namespace UserManagementSystem.Pages
{
    public class EditModel : PageModel
    {
        private readonly IUserservice _userRepository;

        [BindProperty]
        public User User { get; set; }
        public EditModel(IUserservice userRepository)
        {
            this._userRepository = userRepository;
        }
        public  void OnGet(int id)
        {
            
            User =  _userRepository.GetUser(id).Result;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            
            await _userRepository.UpdateUser(User);
            return RedirectToPage("./Index");
        }
    }
}
