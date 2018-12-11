using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

public class AuthHeader : SoapHeader
{
    public string UserName;
    public string Password;
}

public class Result
{
    public Result()
    {

    }
    public Result(string errCode, string errMessage)
    {
        this.ErrCode = errCode;
        this.ErrMessage = errMessage;
    }
    public string ErrCode;
    public string ErrMessage;
}


/// <summary>
/// WebService 的摘要描述
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
// [System.Web.Script.Services.ScriptService]
public class WebService1 : System.Web.Services.WebService
{

    public AuthHeader AuthHeader;
    [SoapHeader("AuthHeader")]
    [WebMethod]
    public Result HelloWorld(string userId)
    {
        var result = CheckUser(AuthHeader);
        if (result.ErrCode == "00")
        {
            var msg = string.Format("hello,{0}", userId);
            return new Result("00", msg);
        }
        else
        {
            return result;
        }
    }

    private Result CheckUser(AuthHeader authHeader)
    {
        if (authHeader == null)
        {
            return new Result("99", "Header認證有誤!");
        }
        else
        {
            var user = authHeader.UserName;
            var password = authHeader.Password;
            if ((user == "mike") && (password == "1234"))
            {
                return new Result("00", "");
            }
            if ((user == "john") && (password == "5678"))
            {
                return new Result("00", "");
            }
        }
        return new Result("98", "帳號或密碼有誤!");
    }
}
