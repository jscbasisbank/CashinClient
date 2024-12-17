namespace Basis.Service.Cashin.Api.Contract.Responses.Checker
{
    /// <summary>
    /// შეტყობინება
    /// </summary>
    public class ServiceMessageRespose
    {
        /// <summary>
        /// პარამეტრი ან რაიმე რაც შეყობინების დიაგნოსტირებას დააჩქარებს
        /// </summary>
        public string? Key { get; set; }

        /// <summary>
        /// შეტყობინება
        /// </summary>
        public string? Message { get; set; }

        public ServiceMessageRespose()
        {

        }

        public ServiceMessageRespose( string message)
        {
            Message = message;
        }

        public ServiceMessageRespose(string key, string message)
        {
            Key = key;
            Message = message;
        }
    }
}
