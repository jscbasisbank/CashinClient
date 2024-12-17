using System.Runtime.Serialization;

namespace Basis.Service.Cashin.Api.Contract.Responses
{
    /// <summary>
    /// ანგარიში და სესხის წამოღების ობიექტი
    /// </summary>
    public class AccountResponse
    {
        [DataMember]
        public int SortId { get; set; }

        /// <summary>
        ///  ანგარიშის ID - ამ ნომრის გადმოგზავნახდება უკან გადახდის მომენტში. უნიკალურია
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// ანგარიშის დასახელება
        /// </summary>
        [DataMember]
        public string AccountName { get; set; }

    

        /// <summary>
        /// ანგარიშის ვალუტა(Gel,Usd,Eur ა.შ)
        /// </summary>
        [DataMember]
        public string AccountCurrency { get; set; }


        /// <summary>
        /// IBAN ანგარიში დამასკულად
        /// </summary>
        [DataMember]
        public string IbanMasked { get; set; }

        /// <summary>
        /// ბარათის ნომერი დამასკული
        /// </summary>
        [DataMember]
        public string CardMasked { get; set; }


        /// <summary>
        /// ბარათის დიზიანის ნომერი. ამ ნომრის მიხედვით უნდა მოხდეს კატალოგიდან ბარათის სურათის გამოტანა
        /// </summary>
        [DataMember]
        public string CardDesignId { get; set; }

        #region სესხები

        /// <summary>
        /// მიმდიანრე დავალიანება ვალუტაში(გრაფიკის წერტილით გადასახდელი სესხის თანხა.)
        /// </summary>
        [DataMember]
        public decimal? CurrentDebt { get; set; }

        /// <summary>
        /// მიმდინარე დავალიანება - ლარში(კურსთან მიმართებაში)(გრაფიკის წერტილით გადასახდელი სესხის თანხა.)
        /// </summary>
        [DataMember]
        public decimal? CurrentDebtInGel { get; set; }
        
        #region ვადაგადაცილების შემთხვევაში

        /// <summary>
        /// ვადაგადაცილებული ძირი დღეის მდგომარეობით
        /// </summary>
        public decimal OverDueDebt { get; set; }

        /// <summary>
        /// ჯარიმა
        /// </summary>
        public decimal Penalt { get; set; }

        /// <summary>
        /// პროცენტი
        /// </summary>
        public decimal Percent { get; set; }
        #endregion

        /// <summary>
        /// უახლოესი გრაფიკის წერტილი(სესხის დაფარვის თარიღი)
        /// </summary>
        [DataMember]
        public DateTime? CloseDate { get; set; }
        /// <summary>
        /// მომდევნო გადახდის წერტილი
        /// </summary>
        public DateTime? NextPaymentDate { get; set; }


        /// <summary>
        /// არის თუ არა სესხი ვადაგადაცილებაში
        /// </summary>
        public bool IsLoanInOverDue { get; set; }




        /// <summary>
        /// ანგარიშის პროდუქტის დასახელება ქართულად
        /// </summary>
        [DataMember]
        public string ProductNameKa { get; set; }
        /// <summary>
        /// ანგარიშის  პროდუქტის დასახელება ლათინურად
        /// </summary>
        [DataMember]
        public string ProductNameEn { get; set; }
        /// <summary>
        ///ანგარიშის  პროდუქტის დასახელება რუსულად
        /// </summary>
        [DataMember]
        public string ProductNameRu { get; set; }


       
        /// <summary>
        /// სესხის ნომერი- ამ ნომრის მიხედვით უნდა მოხდეს გრაფიკის სიის ჩამოტვირთვა
        /// </summary>
        [DataMember]
        public int LoanId { get; set; }

        #endregion
        /// <summary>
        /// დეპოზიტის გახსნის თარიღი
        /// </summary>
        public DateTime? DepositOpenDate { get; set; }

        /// <summary>
        /// დეპოზიტის დახურვის თარიღი
        /// </summary>
        public DateTime? DepositCloseDate { get; set; }
    }
}
