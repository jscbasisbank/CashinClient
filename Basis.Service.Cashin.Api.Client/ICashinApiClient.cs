using Basis.Service.Cashin.Api.Contract.Requests;
using Basis.Service.Cashin.Api.Contract.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Service.Cashin.Client
{
    public interface ICashinApiClient
    {

        /// <summary>
        /// არეგისტრირებს ტრანზაქციას
        /// </summary>
        /// <param name="request"></param>
        /// <returns>აბრუნებს ტრანზაქციის აიდის</returns>
        Task<TransactionRegisterResponse> RegisterAsync(TransactionRegisterRequest request, [Refit.HeaderCollection] IDictionary<string, string> headers);

        /// <summary>
        /// ტრაზაქციის სტატუსის შემოწმება
        /// </summary>
        /// <param name="trasactionId">ქეშინის სისტემის ტრანზაქციის ნომერი</param>
        /// <returns>აბრუნებს ტრანზაციის სტატუსის მონამცენებს</returns>
        Task<TransactionStatusResponse> StatusCheckAsync(string trasactionId, [Refit.HeaderCollection] IDictionary<string, string> headers);

        /// <summary>
        /// კლიენტის შემოწმება
        /// </summary>
        /// <param name="request"></param>
        /// <returns>აბრუნებს კლიენტის ინფორმაციას</returns>
        Task<ClientResponse> CheckAsync(ClientCheckRequest request, [Refit.HeaderCollection] IDictionary<string, string> headers);

        /// <summary>
        /// კლიენტის ანგარიშების წამოღება
        /// </summary>
        /// <param name="request"></param>
        /// <returns>აბრუნებს ანგარიშებს</returns>
        Task<AccountsResponse> AccountsAsync(AccountRequest request, [Refit.HeaderCollection] IDictionary<string, string> headers);

        /// <summary>
        /// აბრუნებს ბანკის კურსებს
        /// </summary>
        /// <returns></returns>
        Task<CurrencyRatesResponse> CurrencyRatesAsync([Refit.HeaderCollection] IDictionary<string, string> headers);
    }
}
