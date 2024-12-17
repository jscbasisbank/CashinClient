using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basis.Service.Cashin.Api.Contract.Responses
{
    public class ReceiptUploadResponse
    {
        /// <summary>
        /// გაგზანილი სმს-ს ტექსტი. შეიცავს ფაილის ლინკსაც
        /// </summary>
        public string SmsText { get; set; }
    }
}
