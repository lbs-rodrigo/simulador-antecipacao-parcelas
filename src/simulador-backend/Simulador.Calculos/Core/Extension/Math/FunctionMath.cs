using Simulador.Calculos.Core.Extension.Parse;
using System;

namespace Simulador.Calculos.Core.Extension.Math
{
    public static partial class FunctionMath
    {
        /// <summary>
        /// Calcula o valor da parcela 
        /// </summary>
        /// <param name="valor">Valor do emprestimo</param>
        /// <param name="juros">Porcentagem do Juros</param>
        /// <param name="prazo">Prazo em meses</param>
        /// <returns></returns>
        public static decimal ValorParcela(this decimal valor, decimal juros, int prazo) =>
            (valor / ((1 - System.Math.Pow(1 + juros.NormalizePercent().ToDouble(), -prazo)).ToDecimal() / juros.NormalizePercent())).Round();

        /// <summary>
        /// Calcula o valor da parcela com o IOF ao dia
        /// </summary>
        /// <param name="valor">Valor financiado do emprestimo</param>
        /// <param name="juros">Porcentagem da taxa efetiva do emprestimo</param>
        /// <param name="prazo">Prazo em meses</param>
        /// <param name="totalIOFAoDia"></param>
        /// <returns></returns>
        public static decimal ValorParcela(this decimal valor, decimal juros, int prazo, decimal totalIOFAoDia) =>
            (
                (
                 valor /
                    (
                     (
                        1 - System.Math.Pow(1 + juros.NormalizePercent().ToDouble(), -prazo)
                     ).ToDecimal() /
                     juros.NormalizePercent()
                    )
                ) +
                totalIOFAoDia / prazo
            ).Round();

        /// <summary>
        /// Calcula o valor futuro
        /// </summary>
        /// <param name="valor">Valor da parcela</param>
        /// <param name="prazo">Prazo em meses</param>
        /// <returns></returns>
        public static decimal ValorFuturo(this decimal valor, int prazo) =>
            (valor * prazo).Round();

        /// <summary>
        /// Calcula o valor total de IOF diario
        /// </summary>
        /// <param name="valor">Valor solicitado</param>
        /// <param name="taxaIOFAoDia">Taxa de IOF ao dia</param>
        /// <param name="prazo">Prazo</param>
        /// <param name="dataContratacao">Data da contratação ou prevista</param>
        /// <param name="dataPrimeiraParcela">Data da primeira parcela prevista ou efetiva</param>
        /// <returns></returns>
        public static decimal ValorTotalIOFAoDia(
            this decimal valor,
            decimal taxaIOFAoDia,
            int prazo,
            DateTime dataContratacao,
            DateTime dataPrimeiraParcela)
        {
            decimal valorPrincipal = valor / prazo;
            decimal valorTotalIOFAoDia = 0;
            DateTime proximaParcela = dataPrimeiraParcela;

            for (int i = 0; i < prazo; i++)
            {
                int diasParaVencimento = dataContratacao.DiasParaVencimento(proximaParcela);
                decimal valorIOFAoDia = (diasParaVencimento * taxaIOFAoDia.NormalizePercent() * valorPrincipal).Round(4);
                valorTotalIOFAoDia = valorTotalIOFAoDia + valorIOFAoDia;
                proximaParcela = proximaParcela.AddMonths(1);
            }

            decimal valorMaximoIOF = valor.Porcentagem(ConstantsMath.percentMaxIOF);
            if (valorTotalIOFAoDia > valorMaximoIOF)
                valorTotalIOFAoDia = valorMaximoIOF;

            return valorTotalIOFAoDia.Round();
        }

        /// <summary>
        /// Calcula a quantidade de dias para o vencimento da parcela
        /// </summary>
        /// <param name="dataParcela"></param>
        /// <param name="dataAtual"></param>
        /// <returns></returns>
        public static int DiasParaVencimento(this DateTime dataContratacao, DateTime dataParcela) =>
            (int)(dataParcela - dataContratacao).TotalDays;

        /// <summary>
        /// Calcula a data da primeira parcela ou proxima parcela
        /// </summary>
        /// <param name="carencia">Valor da carencia</param>
        /// <returns></returns>
        public static DateTime DataPrimeiraParcela(this decimal carencia, DateTime data) =>
            data.AddDays((int)System.Math.Round(carencia * 30, 0));
    }
}
