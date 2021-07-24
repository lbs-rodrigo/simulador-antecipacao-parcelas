using Microsoft.AspNetCore.Mvc;
using Simulador.Calculos.Contract;
using Simulador.Calculos.Core.ResponseBase;
using System.Threading.Tasks;

namespace Simulador.Calculos.Services
{
    public class ParcelasFixasServices : SingleResponse
    {
        public async Task<IActionResult> Simular(PostParcelasFixasRequest request)
        {
            return SuccessResponse();
        }
    }
}
