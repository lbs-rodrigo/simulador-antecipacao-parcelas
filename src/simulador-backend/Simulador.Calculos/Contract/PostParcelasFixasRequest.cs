using System;

namespace Simulador.Calculos.Contract
{
    public class PostParcelasFixasRequest
    {
        public decimal ValorEmprestimo { get; set; }
        public int Prazo { get; set; }
        /// <summary>
        /// Opcional prazo até o pagamento da primeira parcela, é representado da seguinte maneira
        /// 1 = 1mês
        /// 1,5 = 1mês e meio
        /// default: 1
        /// </summary>
        public decimal Carencia { get; set; }
        public decimal TaxaJurosMensal { get; set; }
        /// <summary>
        /// Opcional
        /// </summary>
        public OutrasTaxasModel OutrasTaxas { get; set; }
    }

    /// <summary>
    /// Refencia sobre IOF
    /// https://receita.economia.gov.br/acesso-rapido/legislacao/legislacao-por-assunto/imposto-sobre-operacoes-de-credito-cambio-e-seguro-ou-relativas-a-titulos-ou-valores-mobiliarios-iof#decretos
    /// </summary>
    public class OutrasTaxasModel
    {
        /// <summary>
        /// IOF adicional
        /// </summary>
        public decimal IOFAdicional { get; set; }
        /// <summary>
        /// IOF ao dia
        /// </summary>
        public decimal IOFAoDia { get; set; }
    }
}
