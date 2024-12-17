using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basis.Service.Cashin.Common.Extensions
{
    public static class ExceptionExtension
    {
        public static string ToExString(
                    this Exception ex)
        {
            var description = new StringBuilder();
            description.AppendLine("START<");
            description.AppendFormat("Type: {0}, Message:{1}", ex.GetType().Name, ex.Message);

            try
            {
                if (ex is ApiException)
                {
                    var rEx = (ApiException)ex;
                    var result = rEx.GetContentAsAsync<Dictionary<string, string>>().Result;
                    if (result != null && result.Any())
                    {
                        foreach (var item in result)
                        {
                            description.Append($"{item.Key}{item.Value}");
                            description.AppendLine();
                        }
                        description.AppendLine();
                    }
                }
            }
            catch (Exception)
            {
                //ignore
            }


            if (ex.InnerException != null)
            {
                try
                {
                   


                    if (ex.InnerException is ApiException)
                    {
                        var rEx = (ApiException)ex.InnerException;
                        var result = rEx.GetContentAsAsync<Dictionary<string, string>>().Result;
                        if (result != null && result.Any())
                        {
                            foreach (var item in result)
                            {
                                description.Append($"{item.Key}{item.Value}");
                                description.AppendLine();
                            }
                            description.AppendLine();
                        }
                    }
                }
                catch (Exception)
                {
                    //ignore
                }




                description.AppendFormat(" InnerException.Message: {0}", InnerMostException(ex).Message);
                description.AppendLine();
                description.AppendFormat(" InnerException: {0}", InnerMostException(ex));
                description.AppendFormat(
                    "{0}   --- End of inner exception stack trace ---{0}",
                    Environment.NewLine);
            }

            description.AppendLine(ex.StackTrace);
            description.AppendLine("<END");
            return description.ToString();
        }

        /// <summary>
        /// ამოიღებს ყველაზე ბოლო InnerException-ს
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception InnerMostException(this Exception ex)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;

            return ex;
        }
    }
}
