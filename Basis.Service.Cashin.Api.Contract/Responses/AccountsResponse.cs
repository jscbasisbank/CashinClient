namespace Basis.Service.Cashin.Api.Contract.Responses
{
    /// <summary>
    /// ანგარიშების პასუხი
    /// </summary>
    public class AccountsResponse
    {
        /// <summary>
        /// ანგარიშები
        /// </summary>
        public IEnumerable<AccountResponse> Accounts { get; set; }

        /// <summary>
        /// კლიენტის საკომისიო
        /// </summary>
        public int Commission { get; set; }
    }

   
}
