namespace Basis.Service.Cashin.Api.Contract.Responses.Checker
{
    public class ServiceCheckResponse
    {
        public ServiceCheckResponse(string url,
                                    string title,
                                    string settingkey)
        {
            Url = url;
            Title = title;
            Settingkey = settingkey;
            ServiceMethodCheckResponses = new List<ServiceMethodCheckResponse>();
        }
        /// <summary>
        /// სერვისის მისამართი
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// სერვისის დასახელება
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// AppSetting-ში key-ის სათაური
        /// </summary>
        public string Settingkey { get; private set; }

        /// <summary>
        /// სერვისში გატესტილი მეთოდების შესახებ ინფორმაცია
        /// </summary>
        public List<ServiceMethodCheckResponse> ServiceMethodCheckResponses { get; set; }


        public ServiceCheckResponse()
        {
            ServiceMethodCheckResponses = new List<ServiceMethodCheckResponse>();
        }
    }
}
