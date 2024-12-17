
namespace Basis.Service.Cashin.Api.Contract.Responses
{
    public class CurrencyRatesResponse
    {
        /// <summary>
        /// კურსები
        /// </summary>
        public IEnumerable<CurrencyRateResponse> CurrenctRates { get; set; }
    }
}
