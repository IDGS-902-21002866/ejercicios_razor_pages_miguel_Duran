using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazor.Pages
{
    public class ejercicio_1Model : PageModel
    {
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";

        public double resultado = 0;
        public void OnGet()
        {
        }

        public void OnPost()
        {
            double pesoDouble = Convert.ToDouble(peso);
            double alturaDouble = Convert.ToDouble(altura);

            resultado = pesoDouble / Math.Pow(alturaDouble, 2);

            ModelState.Clear();
        }
    }
}
