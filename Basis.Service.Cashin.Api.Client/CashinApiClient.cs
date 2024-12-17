using Basis.Service.Cashin.Api.Contract.Requests;
using Basis.Service.Cashin.Api.Contract.Responses;
using Basis.Service.Cashin.Client.Factory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Service.Cashin.Client
{
    public class CashinApiClient : ICashinApiClient
    {
        private readonly ICashinApi _cashinApi;

        public CashinApiClient(string hostUrl, ICashinApiFactory CashinApiFactory)
        {
            _cashinApi = CashinApiFactory.CreateNew(hostUrl);
        }

      

        public async Task<AccountsResponse> AccountsAsync(AccountRequest request, [Refit.HeaderCollection] IDictionary<string, string> headers)
        {
            var response = await _cashinApi.Accounts(request, headers);

            return response;
        }

        public async Task<ClientResponse> CheckAsync(ClientCheckRequest request, [Refit.HeaderCollection] IDictionary<string, string> headers)
        {
            var response = await _cashinApi.Check(request, headers);

            return response;
        }

        public async Task<CurrencyRatesResponse> CurrencyRatesAsync([Refit.HeaderCollection] IDictionary<string, string> headers)
        {
            var response = await _cashinApi.CurrencyRates(headers);

            return response;
        }

        public async Task<TransactionRegisterResponse> RegisterAsync(TransactionRegisterRequest request, [Refit.HeaderCollection] IDictionary<string, string> headers)
        {
            var response = await _cashinApi.Register(request, headers);

            return response;
        }

        public async Task<TransactionStatusResponse> StatusCheckAsync(string trasactionId, [Refit.HeaderCollection] IDictionary<string, string> headers)
        {
            var response = await _cashinApi.StatusCheck(trasactionId, headers);

            return response;
        }
    }
}
