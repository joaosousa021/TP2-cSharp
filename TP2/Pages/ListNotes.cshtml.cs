using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TP2.Pages
{
    public class ListNotesModel : PageModel
    {
        public List<string> FileNames { get; set; }

        public void OnGet()
        {
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            FileNames = Directory.GetFiles(dir, "*.txt")
                                 .Select(Path.GetFileName)
                                 .ToList();
        }
    }
}
