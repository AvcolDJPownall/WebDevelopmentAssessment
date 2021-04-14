using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebDevelopmentAssessment.Data;
using WebDevelopmentAssessment.Models;

namespace WebDevelopmentAssessment.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly WebDevelopmentAssessment.Data.WebContentContext _context;

        public CreateModel(WebDevelopmentAssessment.Data.WebContentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // this is techincally useless, but i got bored
            HashAlgorithm hashgen = SHA256.Create();
            byte[] hbytes = hashgen.ComputeHash(Encoding.UTF8.GetBytes(User.PasswordHash));
            User.PasswordHash = string.Join(string.Empty, hbytes.Select(hbytes => hbytes));

            if (User.ProfilePicture == null) User.ProfilePicture = "./img/user.png";

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
