using Basis.Service.Cashin.Api.Contract.Enums;
using System.ComponentModel.DataAnnotations;

namespace Basis.Service.Cashin.Api.Contract.Requests
{
    /// <summary>
    /// ანგარიშემის მოთხოვის რექვესტი
    /// </summary>
    public class AccountRequest
    {
        /// <summary>
        /// სერვისის კოდი
        /// </summary>
        public ServicesEnum Service { get; set; }

        /// <summary>
        /// ბანკი კლიენტის იდენტიფიკატორი ბრუნდება 'Check' მეტოდის გამოძახების დროს
        /// </summary>
        public int ClientNo { get; set; }

        /// <summary>
        /// თანხის შემომტანის ინფორმაცია
        /// </summary>
        public ClientPayerInfoRequest? PayerVerifyData { get; set; }

    }
}
