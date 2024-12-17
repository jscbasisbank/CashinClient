using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basis.Service.Cashin.Api.Contract.Responses.Checker
{
    public class CheckResponse
    {
        /// <summary>
        /// სათაური
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// აღწერა
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Error და Warring -ისთვის მეილისთვის
        /// </summary>
        public string SupportEmail { get; set; }


        /// <summary>
        /// შიდა გამოყენებული სერვისების შესახებ ინფორმაცია
        /// </summary>
        public List<ServiceCheckResponse> ServiceCheckResponses { get; set; }

        public CheckResponse()
        {
            ServiceCheckResponses = new List<ServiceCheckResponse>();
        }
    }
}
