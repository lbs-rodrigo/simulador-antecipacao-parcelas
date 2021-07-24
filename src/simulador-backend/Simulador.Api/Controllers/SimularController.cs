using Microsoft.AspNetCore.Mvc;
using Simulador.Calculos.Contract;
using Simulador.Calculos.Services;
using System.Threading.Tasks;

namespace Simulador.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SimularController : ControllerBase
    {
        private readonly ParcelasFixasServices _parcelasFixas;
        private readonly AntecipacaoServices _antecipacao;

        public SimularController(ParcelasFixasServices parcelasFixas, AntecipacaoServices antecipacao)
        {
            _parcelasFixas = parcelasFixas;
            _antecipacao = antecipacao;
        }

        [HttpPost("parcelas/fixas")]
        public async Task<IActionResult> ParcelasFixas([FromBody] PostParcelasFixasRequest request) =>
            await _parcelasFixas.Simular(request);

        [HttpPost("antecipacao")]
        public async Task<IActionResult> Antecipacao([FromBody] PostAntecipacaoRequest request) =>
            await _antecipacao.Simular(request);
    }
}
