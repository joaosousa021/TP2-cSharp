using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace TP2.Pages
{
    public class ViewNoteModel : PageModel
    {
        public string FileName { get; set; }
        public string Content { get; set; }

        public void OnGet(string file)
        {
            FileName = file;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", file);
            if (System.IO.File.Exists(filePath))
            {
                Content = System.IO.File.ReadAllText(filePath);
            }
            else
            {
                Content = "(Arquivo não encontrado)";
            }
        }
    }
}
