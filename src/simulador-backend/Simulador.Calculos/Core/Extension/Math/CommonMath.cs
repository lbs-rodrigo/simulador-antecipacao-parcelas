namespace Simulador.Calculos.Core.Extension.Math
{
    public static partial class CommonMath
    {
        /// <summary>
        /// Normaliza a porcentagem
        /// Ex: 3.0% to 0,03
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public static decimal NormalizePercent(this decimal percent) =>
            percent / ConstantsMath.BasePercent;

        /// <summary>
        /// Retorna o valor da porcentagem informada sobre o valor informado
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="porcentage"></param>
        /// <returns></returns>
        public static decimal Porcentagem(this decimal valor, decimal porcentage) =>
            valor * porcentage.NormalizePercent();

        /// <summary>
        /// Arredonda um valor do tipo decimal
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static decimal Round(this decimal valor) =>
            System.Math.Round(valor, ConstantsMath.RoundPrecision);

        /// <summary>
        /// A redonda o valor com N casas decimais
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static decimal Round(this decimal d, int precision) =>
            System.Math.Round(d, precision);
    }
}
