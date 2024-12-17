namespace Basis.Service.Cashin.Api.Contract.Responses
{
    public class TransactionRegisterResponse
    {
        public string Message { get; set; }
        /// <summary>
        /// ტრანზაქციის უნიკალური ნომერი
        /// </summary>
        public long TransactionId { get; set; }
        /// <summary>
        /// დღიური დარჩენილი ტრანზქციის ლიმიტი 
        /// </summary>
        public decimal? RemainingDailyLimit { get; set; }
    }
}
