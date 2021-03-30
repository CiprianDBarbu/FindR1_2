using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using FindR1_2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace FindR1_2.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "Your First Name must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "Your Last Name must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Birth Day")]
            public DateTime BirthDate { get; set; }


            [Display(Name = "Age")]
            public int Age { get; set; }

            public GenderType Gender { get; set; }
            //public PersonalAdress{get;set;}

            [StringLength(1000, ErrorMessage = "The Details about you must be a maximum pf {1} characters long.")]
            public string Details { get; set; }

            public byte[] ProfilePicture { get; set; }
            //Lista prieteni
            //Lista anunturi
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                using MemoryStream ms = new MemoryStream();
                Request.Form.Files[0].CopyTo(ms);
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    ProfilePicture = ms.ToArray(),
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    BirthDate = Input.BirthDate,
                    Age = DateTime.Today.Month < Input.BirthDate.Month ? DateTime.Today.Year - Input.BirthDate.Year - 1 : DateTime.Today.Year - Input.BirthDate.Year,
                    Gender = Input.Gender,
                    Details = Input.Details
                };
                ms.Close();
                ms.Dispose();
                
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
