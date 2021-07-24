namespace Simulador.Calculos.Core.Extension.Math
{
    /// <summary>
    /// Constantes utilizadas nos calculos
    /// </summary>
    public static class ConstantsMath
    {
        /// <summary>
        /// Utilizado para normalizar valores informados em porcentagem
        /// </summary>
        public const decimal BasePercent = 100.00M;
        /// <summary>
        /// Utilizado para arrendondar casas decimais
        /// </summary>
        public const int RoundPrecision = 2;
        /// <summary>
        /// Utilizado explicitamente para arrendondar casas decimais sobre calculos de IOF
        /// </summary>
        public const int RoundPrecisionIOF = 4;
        /// <summary>
        /// Porcentagem maxima que pode ser cobrado sobre o IOF
        /// </summary>
        public const decimal percentMaxIOF = 3.0m;
    }
}
