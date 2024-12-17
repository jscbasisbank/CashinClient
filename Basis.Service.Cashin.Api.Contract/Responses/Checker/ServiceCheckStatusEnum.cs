using System.ComponentModel;

namespace Basis.Service.Cashin.Api.Contract.Responses.Checker
{
    public enum ServiceCheckStatusEnum
    {
        [Description("ყველაფერი რიგზეა")]
        Ok = 1,
        [Description("საგანგაშო პრობლემა")]
        Error = 2,
        [Description("გაფრთხილება")]
        Warning = 3
    }
}
