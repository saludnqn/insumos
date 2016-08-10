using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ExtensionMethods {
    public static class MyExtensions {

        public static int WordCount(this String str) {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static int? ParseInt(this String str) {
            int k;
            return int.TryParse(str, out k) ? k : (int?)null;
        }

        public static double? ParseDouble(this String str) {
            double k;
            return double.TryParse(str, out k) ? k : (double?)null;
        }

        public static DateTime? ParseDateTime(this String str) {
            DateTime k;
            return DateTime.TryParse(str, out k) ? k : (DateTime?)null;
        }

        // Int
        /// <summary>
        /// Devuelve un entero a partir de una cadena y 0 (cero) si no se pudo convertir.
        /// </summary>
        /// <param name="str">La cadena a convertir</param>
        /// <returns>La cadena convertida a int o cero si no se pudo convertir</returns>
        public static int TryParseInt(this String str) {
            return TryParseInt(str, 0);
        }

        /// <summary>
        /// Devuelve un entero a partir de una cadena
        /// </summary>
        /// <param name="str">La cadena a convertir</param>
        /// <param name="defa">Valor a devolver si no se pudo convertir</param>
        /// <returns></returns>
        public static int TryParseInt(this String str, int defa) {
            int k;
            return int.TryParse(str, out k) ? k : defa;
        }

        // Double
        public static double TryParseDouble(this String str) {
            return TryParseDouble(str, 0);
        }

        /// <summary>
        /// Trata de convertir un string a doble usando:
        /// CultureInfo.InvariantCulture y NumberStyles.Number
        /// </summary>
        /// <param name="str">cadena a convertir</param>
        /// <param name="defa">valor por defecto si no puede convertir a doble</param>
        /// <returns>la cadena convertida o el valor que se especifique por defecto</returns>
        public static double TryParseDouble(this String str, double defa) {
            double k;
            return double.TryParse(str,NumberStyles.Number, CultureInfo.InvariantCulture,out k ) ? k : defa;
        }

        // Datetime
        public static DateTime TryParseDateTime(this String str) {
            return TryParseDateTime(str, new DateTime(1900, 1, 1));
        }

        public static DateTime TryParseDateTime(this String str, DateTime defa) {
            DateTime k;
            return DateTime.TryParse(str, out k) ? k : defa;
        }

        public static string TryParseISODate(this String str) {
            DateTime dt = TryParseDateTime(str);
            return dt.ToString("yyyyMMdd");
        }
    }
}
