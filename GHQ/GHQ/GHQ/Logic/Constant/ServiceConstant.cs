namespace GHQ.Logic.Constant
{
    static public class ServiceConstant
    {
        //WebAPI:https://registration.uaensr.ae/regapi/api/

        static public readonly string BaseUrl_Prod = "https://registration.uaensr.ae";
        static public readonly string BaseUrl_Dev = "http://ghq-reg.linkdev.com";
        static public readonly string BaseUrl = Constant.IsProduction ? BaseUrl_Prod : BaseUrl_Dev;

        static public readonly string ApiBaseUrl_Prod = BaseUrl + "/regapi/api";
        static public readonly string ApiBaseUrl_Dev = BaseUrl + "/WebApis/api";
        static public readonly string ApiBaseUrl = Constant.IsProduction ? ApiBaseUrl_Prod : ApiBaseUrl_Dev;

      
    }
}
