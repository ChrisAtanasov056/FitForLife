using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FitForLife.Data.Models;
using FitForLife.Services.Data.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FitForLife.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<FitForLifeUser> _userManager;
        private readonly SignInManager<FitForLifeUser> _signInManager;
        private readonly IUserService userService;

        public IndexModel(
            UserManager<FitForLifeUser> userManager,
            SignInManager<FitForLifeUser> signInManager, 
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.userService = userService;
        }
        
        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public string Username { get; set; }
        
        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [MinLength(3)]
            [MaxLength(30)]
            public string FirstName { get; set; }
            [MinLength(3)]
            [MaxLength(30)]
            public string LastName { get; set; }

        }

        private async Task LoadAsync(FitForLifeUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            this.Input.FirstName = user.FirstName;
            this.Input.LastName = user.LastName;
            this.Input.PhoneNumber = user.PhoneNumber;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstName = await this.userService.GetFirstNameAsync(user.Id);
            var lastName = await this.userService.GetLastNameAsync(user.Id);
            if (this.Input.FirstName != firstName)
            {
                await this.userService.ChangeFirstNameAsync(user.Id, this.Input.FirstName);
            }

            if (this.Input.LastName != lastName)
            {
                await this.userService.ChangeLastNameAsync(user.Id, this.Input.LastName);
            }
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
