using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TP2.Pages.DetailsManager
{
    public class CitySelectorModel : PageModel
    {
        public List<string> Cities { get; set; } = new() { "Rio", "S�o Paulo", "Bras�lia" };

        public void OnGet()
        {
        }
    }
}