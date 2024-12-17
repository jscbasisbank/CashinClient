using Basis.Service.Cashin.Api.Contract.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Basis.Service.Cashin.Api.Contract.Requests
{
    /// <summary>
    /// ტრანზაქციის რეგიტრაციის ობიექტი
    /// </summary>
    public class TransactionRegisterRequest
    {
        /// <summary>
        /// ანგარიშის ნომერი 
        /// </summary>
        [Description("ანგარიშის ნომერი")]
        public int AccountId { get; set; }

        /// <summary>
        /// ბანკი კლიენტის იდენტიფიკატორი. ბრუნდება 'Check' მეთოდის გამოძახების დროს
        /// </summary>
        [Required]
        public int ClientNo { get; set; }

        /// <summary>
        /// სერვისის
        /// </summary>
        [Required]
        public ServicesEnum ServiceCode { get; set; }

       
        /// <summary>
        /// თანხა თეთრებში. (კლიენტის ანგარიშზე ასასახი თანხა)
        /// </summary>
        [Required]
        public int Amount { get; set; }

        /// <summary>
        /// კლიენტის ანგარიშზე ასასახი თანხა. გამოიყენება ზოგიერთი არხის ჭრილში
        /// </summary>
        public int? ReflectedAmount { get; set; }

        /// <summary>
        /// თანხის ვალუტა
        /// </summary>
        [Required]
        public string AmountCurrency { get; set; }

        /// <summary>
        /// ტრანზაქციის უნიკალური ნომერი ნომერი.( უნდა შეიცავდეს ტერმინალის ნომერსაც) მაგ:BAZIS001_1111 სადაც BAZIS001  არის ტერმინალის ნომერი 1111 ტრანზაქციის უნიკალური ნომერი
        /// </summary>
        [Required]
        public string TransactionId { get; set; }


        /// <summary>
        /// კიოსკში თანხის შეტანის თარიღი (შემოსული ფორმატი უნდა იყოს: yyyy-MM-dd HH:mm:ss )
        /// </summary>
        [Required]
        public string PaymentDate { get; set; }

        public string? SmsMobile { get; set; }

        public string? SmsText { get; set; }

        /// <summary>
        /// დამატებითი დანიშნულება. 
        /// </summary>
        [MaxLength(140)]
        public string Purpose { get; set; }

        /// <summary>
        /// თანხის შემომტანის ინფორმაცია
        /// </summary>
        public PayerInfoRequest? PayerVerifyData { get; set; }
    }
}
