using Basis.Service.Cashin.Api.Contract.Requests;
using Basis.Service.Cashin.Api.Contract.Responses;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basis.Service.Cashin.Client
{
    public interface ICashinApi
    {
        /// <summary>
        /// არეგისტრირებს ტრანზაქციას
        /// </summary>
        /// <param name="request"></param>
        /// <returns>აბრუნებს ტრანზაქციის აიდის</returns>
        [Post("/api/Transaction/Register")]
        Task<TransactionRegisterResponse> Register(TransactionRegisterRequest request, [Refit.HeaderCollection] IDictionary<string, string> headers);

        /// <summary>
        /// ტრაზაქციის სტატუსის შემოწმება
        /// </summary>
        /// <param name="trasactionId">ქეშინის სისტემის ტრანზაქციის ნომერი</param>
        /// <returns>აბრუნებს ტრანზაციის სტატუსის მონამცენებს</returns>
        [Get("/api/Transaction/StatusCheck?trasactionId={trasactionId}")]
        Task<TransactionStatusResponse> StatusCheck(string trasactionId);

        /// <summary>
        /// კლიენტის შემოწმება
        /// </summary>
        /// <param name="request"></param>
        /// <returns>აბრუნებს კლიენტის ინფორმაციას</returns>
        [Post("/api/client/Check")]
        Task<ClientResponse> Check(ClientCheckRequest request);

        /// <summary>
        /// კლიენტის ანგარიშების წამოღება
        /// </summary>
        /// <param name="request"></param>
        /// <returns>აბრუნებს ანგარიშებს</returns>
        [Post("/api/client/Accounts")]
        Task<AccountsResponse> Accounts(AccountRequest request);

        /// <summary>
        /// აბრუნებს ბანკის კურსებს
        /// </summary>
        /// <returns></returns>
        [Post("/api/bank/CurrencyRates")]
        Task<CurrencyRatesResponse> CurrencyRates();
    }
}
