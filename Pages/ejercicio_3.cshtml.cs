using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazor.Pages
{
    public class ejercicio_3Model : PageModel
    {

        [BindProperty]
        public string a { get; set; } = "";
        [BindProperty]
        public string b { get; set; } = "";
        [BindProperty]
        public string x { get; set; } = "";
        [BindProperty]
        public string y { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";

        public string resultado = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            int aInt = Convert.ToInt32(a);
            int bInt = Convert.ToInt32(b);
            int xInt = Convert.ToInt32(x);
            int yInt = Convert.ToInt32(y);
            int nInt = Convert.ToInt32(n);

            double result = 0;

            for (int k = 0; k <= nInt; k++)
            {
                double cnk = cNk(nInt, k);

                result += cnk * Math.Pow((aInt * xInt), nInt - k) * Math.Pow((bInt * yInt), k);
            }

            resultado = Convert.ToString(result);
        }


        private double cNk(int n, int k)
        {
            int nfactorial = factorial(n);
            int kfactorial = factorial(k);
            int nkfactorial = factorial(n - k);

            double resultado = (nfactorial) / (kfactorial * nkfactorial);

            return resultado;
        }

        private int factorial(int n)
        {
            var resultado = 1;

            for (int i = 1; i <= n; i++)
            {
                resultado = resultado * i;
            }

            return resultado;
        }
    }
}
