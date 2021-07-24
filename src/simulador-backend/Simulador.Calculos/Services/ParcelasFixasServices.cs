using Microsoft.AspNetCore.Mvc;
using Simulador.Calculos.Contract;
using Simulador.Calculos.Core.Extension.Math;
using Simulador.Calculos.Core.ResponseBase;
using System;
using System.Threading.Tasks;

namespace Simulador.Calculos.Services
{
    public class ParcelasFixasServices : SingleResponse
    {
        /// <summary>
        /// Realiza a simulação de emprestimo com parcelas fixas
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IActionResult> Simular(PostParcelasFixasRequest request)
        {
            DateTime dtBase = DateTime.Now;

            decimal valorFinanciado = request.ValorEmprestimo;
            if (request.OutrasTaxas != null && request.OutrasTaxas.IOFAdicional > 0)
                valorFinanciado = request.ValorEmprestimo + request.ValorEmprestimo.Porcentagem(request.OutrasTaxas.IOFAdicional);

            DateTime dtPrimeiraParcela = request.Carencia > 0 ? request.Carencia.DataPrimeiraParcela(dtBase) : 1M.DataPrimeiraParcela(dtBase);

            decimal totalIOFAoDia = 0;
            if (request.OutrasTaxas != null && request.OutrasTaxas.IOFAoDia > 0)
                totalIOFAoDia = request.ValorEmprestimo.ValorTotalIOFAoDia(request.OutrasTaxas.IOFAoDia, request.Prazo, dtBase, dtPrimeiraParcela);

            decimal valorParcela = valorFinanciado.ValorParcela(request.TaxaJurosMensal, request.Prazo, totalIOFAoDia);

            var resultado = new PostParcelasFixasResponse();
            resultado.ValorEmprestimo = request.ValorEmprestimo;
            resultado.Prazo = request.Prazo;
            resultado.ValorParcela = valorParcela;
            resultado.ValorTotalPagar = valorParcela * request.Prazo;
            resultado.ValorTotalJurosCobrados = resultado.ValorTotalPagar - request.ValorEmprestimo;

            return SuccessResponse(resultado);
        }
    }
}
