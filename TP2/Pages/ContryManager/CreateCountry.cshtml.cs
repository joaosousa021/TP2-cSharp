using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP2.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public List<InputModel> Paises { get; set; } = new();

        public List<Country> PaisesCadastrados { get; set; } = new();

        public class InputModel
        {
            [Required(ErrorMessage = "O nome do pa�s � obrigat�rio.")]
            [Display(Name = "Nome do Pa�s")]
            public string NomePais { get; set; }

            [Required(ErrorMessage = "O c�digo do pa�s � obrigat�rio.")]
            [StringLength(2, MinimumLength = 2, ErrorMessage = "O c�digo do pa�s deve conter exatamente 2 letras.")]
            [Display(Name = "C�digo do Pa�s (ISO)")]
            public string CodigoPais { get; set; }
        }

        public class Country
        {
            public string NomePais { get; set; }
            public string CodigoPais { get; set; }
        }

        public void OnGet()
        {
            for (int i = 0; i < 5; i++)
            {
                Paises.Add(new InputModel());
            }
        }

        public IActionResult OnPost()
        {
           
            PaisesCadastrados = new();

            
            for (int i = 0; i < Paises.Count; i++)
            {
                var input = Paises[i];

                if (!string.IsNullOrWhiteSpace(input.NomePais) && !string.IsNullOrWhiteSpace(input.CodigoPais))
                {
                    var primeiraLetraNome = char.ToUpper(input.NomePais[0]);
                    var primeiraLetraCodigo = char.ToUpper(input.CodigoPais[0]);

                    if (primeiraLetraNome != primeiraLetraCodigo)
                    {
                        ModelState.AddModelError($"Paises[{i}].CodigoPais",
                            "O c�digo do pa�s deve come�ar com a mesma letra que o nome do pa�s.");
                    }
                }
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            foreach (var input in Paises)
            {
                PaisesCadastrados.Add(new Country
                {
                    NomePais = input.NomePais,
                    CodigoPais = input.CodigoPais.ToUpper()
                });
            }

            return Page();
        }
    }
}
