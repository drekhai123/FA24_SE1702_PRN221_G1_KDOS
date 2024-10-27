using KDOS.Data;
using KDOS.Data.Models;
using KDOS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KDOS.WebApp.Pages.Packings
{
    public class EditModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public EditModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Packing Packing { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Packing = await _unitOfWork.PackingRepository.GetByIdAsync(id);

            if (Packing == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _unitOfWork.PackingRepository.SaveAsync(Packing); 

            return RedirectToPage("./Index");
        }
    }
}
