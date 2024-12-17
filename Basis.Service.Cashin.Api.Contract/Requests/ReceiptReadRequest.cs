using System.ComponentModel.DataAnnotations;

namespace Basis.Service.Cashin.Api.Contract.Requests
{
    public class ReceiptReadRequest
    {
        /// <summary>
        /// ფაილის სახელი
        /// </summary>
        [Required()]
        public string FileName { get; set; }
    }
}
