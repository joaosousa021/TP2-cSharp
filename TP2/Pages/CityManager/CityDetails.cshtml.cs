using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TP2.Pages.DetailsManager
{
    public class CityDetailsModel : PageModel
    {
        public string CityName { get; set; }

        public void OnGet(string cityName)
        {
            CityName = cityName;
        }
    }
}
