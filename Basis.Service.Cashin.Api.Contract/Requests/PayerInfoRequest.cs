using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Basis.Service.Cashin.Api.Contract.Requests
{
    public class PayerInfoRequest
    {
        /// <summary>
        /// ვერიფიკაციის წყაროს უნიკალური ნომერი
        /// </summary>
        [Required]
        public string VerificationId { get; set; }

        /// <summary>
        /// თანხის შემომტანის პირადობის ნომერი
        /// </summary>
        public string IdentityNumber { get; set; }


        ///// <summary>
        ///// დამატებითი დანიშნულების ველი
        ///// </summary>
        //[IgnoreDataMember]
        //public string Purpose { get { return $"{VerificationId} {IdentityNumber}"; } }
    }


    public class ClientPayerInfoRequest
    {
        /// <summary>
        /// ვერიფიკაციის წყაროს უნიკალური ნომერი
        /// </summary>

        public string? VerificationId { get; set; }

        /// <summary>
        /// თანხის შემომტანის პირადობის ნომერი
        /// </summary>
        public string IdentityNumber { get; set; }


        ///// <summary>
        ///// დამატებითი დანიშნულების ველი
        ///// </summary>
        //[IgnoreDataMember]
        //public string Purpose { get { return $"{VerificationId} {IdentityNumber}"; } }
    }
}
