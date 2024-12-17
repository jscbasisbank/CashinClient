using System.ComponentModel;

namespace Basis.Service.Cashin.Api.Contract.Enums
{
    /// <summary>
    /// ტრანზაქციის სტატუსები გარე კლიენტისთვის
    /// </summary>
    public enum TransactionStatusClientEnum
    {
        /// <summary>
        /// შექმნილი
        /// </summary>
        [Description("შექმნილი ემზადება დასამუშავებლად")]
        Created = 1,
        /// <summary>
        /// დამუშავების პროცესში
        /// </summary>
        [Description("დამუშავების პროცესში")]
        Processing = 2,
        /// <summary>
        /// დასრულებული
        /// </summary>
        [Description("წარმატებული.")]
        Succeed = 3,
        /// <summary>
        /// გაუქმებული
        /// </summary>
        [Description("გაუქმებული")]
        Rejected = 4,
    }
}
