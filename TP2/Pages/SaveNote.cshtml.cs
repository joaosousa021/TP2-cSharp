using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Text;

namespace TP2.Pages
{
    public class SaveNoteModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public string FileName { get; set; }

        public class InputModel
        {
            public string Content { get; set; }
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (string.IsNullOrWhiteSpace(Input?.Content))
                return;

            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            FileName = $"note-{timestamp}.txt";

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", FileName);
            System.IO.File.WriteAllText(filePath, Input.Content, Encoding.UTF8);
        }
    }
}
