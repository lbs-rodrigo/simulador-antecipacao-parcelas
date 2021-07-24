namespace Simulador.Calculos.Contract
{
    public class PostParcelasFixasResponse
    {
        /// <summary>
        /// Valor informado
        /// </summary>
        public decimal ValorEmprestimo { get; set; }
        /// <summary>
        /// Prazo em meses
        /// </summary>
        public decimal Prazo { get; set; }
        /// <summary>
        /// Valor da parcela
        /// </summary>
        public decimal ValorParcela { get; set; }
        /// <summary>
        /// Valor total de juros que será cobrado até o final do prazo
        /// </summary>
        public decimal ValorTotalJurosCobrados { get; set; }
        /// <summary>
        /// Valor total a pagar até o final do prazo
        /// </summary>
        public decimal ValorTotalPagar { get; set; }
    }
}
