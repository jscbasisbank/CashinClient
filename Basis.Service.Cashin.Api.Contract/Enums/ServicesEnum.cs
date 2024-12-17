using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Basis.Service.Cashin.Api.Contract.Enums
{


    /// <summary>
    /// სერვისები
    /// </summary>
    public enum ServicesEnum
    {

        /// <summary>
        /// ანაბარზე თანხის შეტანა
        /// </summary>
        [Description("ანაბარზე თანხის შეტანა")]
        Deposits = 1,
        /// <summary>
        /// მიმდნარე და საბარეთე ანგარიშები
        /// </summary>
        [Description("მიმდინარე და საბარათე ანგარიშები")]
        Accounts,
        /// <summary>
        /// სასესხო ანგარიშები
        /// </summary>
        [Description("სასესხო ანგარიშები")]
        LoanAccounts,
        /// <summary>
        /// საკრედიტო ბარათები
        /// </summary>
        [Description("საკრედიტო ბარათები")]
        CardLoanAccount,
        /// <summary>
        /// იუდიდიული პირის ანგარიშები-taxCode-ს მიხედვით
        /// </summary>
        [Description("იუდიდიული პირის ანგარიშები-taxCode-ს მიხედვით")]
        TaxAccounts,
        /// <summary>
        /// ინდ. მეწარმეებისთვის - საბალანსო ანგარიშები
        /// </summary>
        [Description("ინდ. მეწარმეებისთვის - საბალანსო ანგარიშები")]
        BalanceAccounts,
        /// <summary>
        /// საბარათე ანგარიშები
        /// </summary>
        [Description("საბარათე ანგარიშები")]
        Cards,
        /// <summary>
        /// ინდ მეწარმის ბიზნეს ბარათები
        /// </summary>
        [Description("ინდ მეწარმის ბიზნეს ბარათები")]
        BusinessCards,
        [Description("DropBox-ის ანგარიშები")]
        DropBox
    }
}
