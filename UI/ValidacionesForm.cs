using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UI
{
    public class ValidacionesForm
    {
        // Validar que un campo no esté vacío o contenga solo espacios
        public static bool NoEstaVacio(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Validar que un campo contenga solo texto
        public static bool EsSoloTexto(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        // Validar que un campo contenga solo números
        public static bool EsSoloNumeros(string input)
        {
            return Regex.IsMatch(input, @"^[0-9]+$");
        }

        // Validar que un campo tenga el formato de un email
        public static bool EsEmailValido(string input)
        {
         // Utilizamos una expresión regular para validar el formato del email
         return Regex.IsMatch(input, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        }
    }
}
