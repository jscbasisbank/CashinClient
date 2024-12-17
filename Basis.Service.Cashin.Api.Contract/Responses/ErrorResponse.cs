using Basis.Service.Cashin.Api.Contract.Enums;
using Newtonsoft.Json;


namespace Basis.Service.Cashin.Api.Contract.Responses
{
    public class ErrorResponse
    {
        /// <summary>
        /// შეცდომის კოდი
        /// </summary>
        public ErrorEnum Error { get; set; }

        /// <summary>
        /// შეცდომის აღწერა
        /// </summary>
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
