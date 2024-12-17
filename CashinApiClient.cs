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

      

        public async Task<AccountsResponse> AccountsAsync(AccountRequest request)
        {
            var response = await _cashinApi.Accounts(request);

            return response;
        }

        public async Task<ClientResponse> CheckAsync(ClientCheckRequest request)
        {
            var response = await _cashinApi.Check(request);

            return response;
        }

        public async Task<CurrencyRatesResponse> CurrencyRatesAsync()
        {
            var response = await _cashinApi.CurrencyRates();

            return response;
        }

        public async Task<TransactionRegisterResponse> RegisterAsync(TransactionRegisterRequest request, [Refit.HeaderCollection] IDictionary<string, string> headers)
        {
            var response = await _cashinApi.Register(request, headers);

            return response;
        }

        public async Task<TransactionStatusResponse> StatusCheckAsync(string trasactionId)
        {
            var response = await _cashinApi.StatusCheck(trasactionId);

            return response;
        }
    }
}
