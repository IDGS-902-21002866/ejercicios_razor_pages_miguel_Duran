using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazor.Pages
{
    public class ejercicio_4Model : PageModel
    {
        public int[] numeros = new int[20];
        public int[] numerosOrdenados = new int[20];
        public int sumaResultado;
        public double mediaResultado;
        public List<int> modaResultado = new List<int>();
        public double medianaResultado;

        public void OnGet()
        {
            numeros = randomNumber();
            numerosOrdenados = numeros.OrderBy(n => n).ToArray();
            sumaResultado = suma(numeros);
            mediaResultado = media(numeros);
            modaResultado = moda(numeros);
            medianaResultado = mediana(numerosOrdenados);
        }

        private int[] randomNumber()
        {
            Random random = new Random();
            int[] numeros = new int[20];
            for (int i = 0; i < 20; i++)
                numeros[i] = random.Next(0, 101);
            return numeros;
        }

        private int suma(int[] numeros)
        {
            int suma = 0;
            foreach (var item in numeros)
                suma += item;
            return suma;
        }

        private double media(int[] numeros)
        {
            return (double)suma(numeros) / numeros.Length;
        }

        private List<int> moda(int[] numeros)
        {
            var frecuencias = new Dictionary<int, int>();
            foreach (var n in numeros)
            {
                if (frecuencias.ContainsKey(n))
                    frecuencias[n]++;
                else
                    frecuencias[n] = 1;
            }

        
            int maxFrecuencia = frecuencias.Values.Max();

            return frecuencias
                .Where(f => f.Value == maxFrecuencia)
                .Select(f => f.Key)
                .ToList();
        }

        private double mediana(int[] numerosOrdenados)
        {
            int mid = numerosOrdenados.Length / 2;

            if (numerosOrdenados.Length % 2 == 0)
                return (numerosOrdenados[mid - 1] + numerosOrdenados[mid]) / 2.0;
            else
                return numerosOrdenados[mid];
        }
    }
}