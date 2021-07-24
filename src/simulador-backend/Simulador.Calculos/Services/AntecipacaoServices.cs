using Microsoft.AspNetCore.Mvc;
using Simulador.Calculos.Contract;
using Simulador.Calculos.Core.ResponseBase;
using System.Threading.Tasks;

namespace Simulador.Calculos.Services
{
    public class AntecipacaoServices : SingleResponse
    {
        public async Task<IActionResult> Simular(PostAntecipacaoRequest request)
        {
            return SuccessResponse();
        }
    }
}
