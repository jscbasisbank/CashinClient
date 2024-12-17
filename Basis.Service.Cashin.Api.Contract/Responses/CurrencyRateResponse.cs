using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basis.Service.Cashin.Api.Contract.Responses
{
    /// <summary>
    /// კურსი
    /// </summary>
    public class CurrencyRateResponse
    {
        public bool IsCommecialRate { get; set; }

        /// <summary>
        /// ვალუტიდან
        /// </summary>
        public string CurrencyFrom { get; set; }

        /// <summary>
        /// ვალუტაში
        /// </summary>
        public string CurrencyTo { get; set; }

        /// <summary>
        /// ყიდვა
        /// </summary>
        public decimal Buy { get; set; }
        /// <summary>
        /// გაყიდვა
        /// </summary>
        public decimal Sell { get; set; }
    }

}
