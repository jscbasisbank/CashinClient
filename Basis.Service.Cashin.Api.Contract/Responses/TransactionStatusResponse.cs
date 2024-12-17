using Basis.Service.Cashin.Api.Contract.Enums;


namespace Basis.Service.Cashin.Api.Contract.Responses
{
    public class TransactionStatusResponse
    {
        public TransactionStatusClientEnum Status { get; set; }

        public string Description { get; set; }
    }
}
