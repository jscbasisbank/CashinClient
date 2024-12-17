using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basis.Service.Cashin.Api.Contract.Responses.Checker
{
    public class ServiceMethodCheckResponse
    {
        /// <summary>
        /// ინფორმაცია რაც გაიტესტა
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// პრობლემის მოგვარების სავარაუდო გზა
        /// </summary>
        public string FixedDescription { get; set; }

        /// <summary>
        /// სერვისის შესახებ სტატუსი
        /// </summary>
        public ServiceCheckStatusEnum ServiceCheckStatus { get; set; }

        /// <summary>
        /// შეცდომის მესიჯი
        /// </summary>
        public string? ExceptionMessage { get; set; }

        /// <summary>
        /// ზოგადი შეტყობინენები
        /// </summary>
        public List<ServiceMessageRespose> Messages { get; set; }

        public ServiceMethodCheckResponse()
        {
            Messages = new List<ServiceMessageRespose>();
        }

        public void AddMessage(object key, string message)
        {
            if (key != null)
                Messages.Add(new ServiceMessageRespose(key.ToString(), message));
            else
                Messages.Add(new ServiceMessageRespose(message));


        }

        public void AddMessage(string message)
        {
            Messages.Add(new ServiceMessageRespose(message));
        }
    }
}
