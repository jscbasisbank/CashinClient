using System.ComponentModel;

namespace Basis.Service.Cashin.Api.Contract.Enums
{
    public enum ErrorEnum
    {
        /// <summary>
        /// არასწორი პარამეტრი 
        /// </summary>
        InvalidParameter = 1,
        /// <summary>
        /// ზოგადი შეცდომა
        /// </summary>
        Error = 2,
        [Description("დეპოზიტი, რომელზეც დაშვებულია აპარატით თანხის შეტანა, არ მოიძებნა.")]
        DepositsNotFound = 3,
        [Description("ანგარიში, რომელზეც დაშვებულია აპარატით თანხის შეტანა, არ მოიძებნა.")]
        AccountsNotFound = 4,
        [Description("სესხი, რომელზეც დაშვებულია აპარატით თანხის შეტანა, არ მოიძებნა.")]
        LoanAccountsNotFound = 5,
        [Description("სესხი, რომელზეც დაშვებულია აპარატით თანხის შეტანა, არ მოიძებნა.")]
        CardLoanAccountsNotFound = 6,
        [Description("თანხის შეტანის დღიური ლიმიტი ამოწურულია")]
        DailyLimitExpired =7
    }
}
