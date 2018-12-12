using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AudioAgentTest.Context;
using AudioAgentTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AudioAgentTest.Pages.ImagesStored
{
    public class IndexModel : PageModel
    {
        public ApplicationDbContext _db { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        [BindProperty]
        public IList<ImagesStorage> ImagesStorageCollection { get; set; }

        [BindProperty]
        public bool HasImageStorage => ImagesStorageCollection != null ? ImagesStorageCollection.Count > 0 : false;

        [BindProperty(SupportsGet = true)]
        public ImagesStorage ImagesStorage { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (string.IsNullOrEmpty(ImagesStorage.ImagePath))
            {
                return Page();
            }

            ImagesStorageCollection = await _db.ImagesStorage.ToListAsync();

            var matches = ImagesStorageCollection.Where(row =>
                   row.ImagePath == ImagesStorage.ImagePath).FirstOrDefault();

            if (matches == null)
            {
                //Insert
                ImagesStorage.ImageFileExtension =  "jpg";
                ImagesStorage.ImageName= "Photo Niagara";
                
                _db.ImagesStorage.Add(ImagesStorage);

                await _db.SaveChangesAsync();

                Message = "Image Detail created successfully";

                return Page();
            }
            
            return Page();
        }
    }
}