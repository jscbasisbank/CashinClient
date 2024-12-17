using System.ComponentModel.DataAnnotations;

namespace Basis.Service.Cashin.Api.Contract.Requests
{
    public class ReceiptUploadRequest
    {
        /// <summary>
        /// მობილურის ნომერი
        /// </summary>
        [Required()]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "ტელეფონის ნომერი უნდა შეიცავდეს 9 სიმბოლოს")]
        public string Phone { get; set; }

        /// <summary>
        /// ტემინალის ნომერი
        /// </summary>
        [Required()]
        public string TerminalId { get; set; }

        /// <summary>
        /// ტერმინალის გადახდის ნომერი
        /// </summary>
        [Required()]
        public string TerminalPaymentId { get; set; }


        /// <summary>
        ///  სურათის ტექსტი base 64 ფორმტში
        /// </summary>
        [Required()]
        public string Source { get; set; }
    }
}
