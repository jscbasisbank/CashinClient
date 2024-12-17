using Basis.Service.Cashin.Api.Contract.Enums;
using System.ComponentModel.DataAnnotations;

namespace Basis.Service.Cashin.Api.Contract.Requests
{
    /// <summary>
    /// კლიენტის გადამოწმების რექვესტი
    /// </summary>
    public class ClientCheckRequest
    {
        /// <summary>
        /// პირადობის ნომერი ან იურიდიული პირის იდენტიფიკატორი ან ანგარიში ნომერი(IBAN)
        /// </summary>
        [Required()]
        public string IdentityNumber { get; set; }


        /// <summary>
        /// იდენტიფიკატორის ტიპი. IdentityNumber-ის შევსების დროს უნდა მონიშნოთ შესაბამისი ტიპი
        /// </summary>
        public IdentityTypeEnum IdentityType { get; set; }//2323

        /// <summary>
        /// თანხის შემომტანის ინფორმაცია
        /// </summary>
        public ClientPayerInfoRequest? PayerVerifyData { get; set; }
    }
}
