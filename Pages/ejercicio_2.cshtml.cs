using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazor.Pages
{
    public class ejercicio_2Model : PageModel
    {
        [BindProperty]
        public string mensaje { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";
        [BindProperty]
        public string accion { get; set; } = "";

        public string resultado = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            int nInt = Convert.ToInt32(n);

            if (accion == "cifrar")
            {
                resultado = cifrarMensaje(nInt, mensaje);
            } else if(accion == "descifrar")
            {
                resultado = descifrarMensaje(nInt, mensaje);
            }
        }

        private string cifrarMensaje(int n, string mensaje)
        {
            char[] letras = new char[] {
                'A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','X','Y','Z'
            };


            string mensajeUpper = mensaje.ToUpper();

            string mensajeCifrado = "";

            for (int i = 0; i < mensaje.Length; i++)
            {
                if (mensajeUpper[i] == ' ')
                {
                    mensajeCifrado += ' ';
                    continue;
                }

                int posicionOriginal = Array.IndexOf(letras, mensajeUpper[i]);
                int posicionNueva = (posicionOriginal + n) % 25;
                mensajeCifrado += letras[posicionNueva];
            }

            return mensajeCifrado;
        }
        private string descifrarMensaje(int n, string mensaje)
        {
            char[] letras = new char[] {
                'A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','X','Y','Z'
            };


            string mensajeUpper = mensaje.ToUpper();

            string mensajeDescifrado = "";

            for (int i = 0; i < mensaje.Length; i++)
            {

                if (mensajeUpper[i] == ' ')
                {
                    mensajeDescifrado += ' ';
                    continue;
                }

                int posicionOriginal = Array.IndexOf(letras, mensajeUpper[i]);

                int posicionNueva = ((posicionOriginal - n) + 25) % 25;

                mensajeDescifrado += letras[posicionNueva];
            }

            return mensajeDescifrado;
        }
    }

}
