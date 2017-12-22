using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityContoso.Models;

namespace UniversityContoso.PagesStudents
{
    public class CreateVmModel : PageModel
    {
        private readonly UniversityContoso.Data.SchoolContext _context;

        public CreateVmModel(UniversityContoso.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // TODO remove. For quick testing.
            StudentVM = new StudentVM
            {
                EnrollmentDate = DateTime.Now.AddYears(-10),
                FirstMidName = "Rick",
                LastName = "Anderson"
            };
            return Page();
        }

        // divega review 
        #region snippet_OnPostAsync
        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        #endregion
    }
}
