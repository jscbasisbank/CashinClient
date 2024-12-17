using System.ComponentModel;

namespace Basis.Service.Cashin.Api.Contract.Enums
{
    /// <summary>
    /// კლიენტის იდენტიფიკაციისთვის გადმოცემული იდენტიფიკატორის ტიპი
    /// </summary>
    public enum IdentityTypeEnum
    {
        /// <summary>
        /// პირადობის ნომერი
        /// </summary>
        [Description("პირადობის ნომერი")]
        PersonalNumber,
        /// <summary>
        /// იურიდიული პირის ნომერი Tax
        /// </summary>
        [Description("იურიდიული პირის ნომერი Tax კოდი")]
        JuridicalIdentityNumber,
        /// <summary>
        /// ანგარიშის ნომერი
        /// </summary>
        [Description("ანგარიშის ნომერი Iban")]
        Iban,
        /// <summary>
        /// პასპორტის ნომერი
        /// </summary>
        [Description("პასპორტის ნომერი")]
        Passport
    }
}
