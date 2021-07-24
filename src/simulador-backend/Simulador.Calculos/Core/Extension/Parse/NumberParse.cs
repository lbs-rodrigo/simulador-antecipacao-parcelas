using System;

namespace Simulador.Calculos.Core.Extension.Parse
{
    public static partial class NumberParse
    {
        /// <summary>
        /// Convert um valor double em decimal
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this double d) =>
            Convert.ToDecimal(d);

        /// <summary>
        /// Convert um valor decimal para double
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static double ToDouble(this decimal d) =>
            Convert.ToDouble(d);
    }
}
