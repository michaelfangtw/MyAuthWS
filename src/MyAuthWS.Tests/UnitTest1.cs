using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyAuthWS.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public string Url { get { return "http://localhost:53757/WebService.asmx"; } }
        [TestMethod]
        public void TestMethod_wsAuthWS_HelloWorld()
        {
            //=======================================================
            //呼叫正常
            //=======================================================
            wsAuthWS.WebService1 ws = new wsAuthWS.WebService1();
            wsAuthWS.AuthHeader header = new wsAuthWS.AuthHeader() ;
            header.UserName = "mike";
            header.Password = "1234";
            ws.AuthHeaderValue = header;
            ws.Url = Url;
            var result=ws.HelloWorld("Mike");
            Assert.IsTrue(result.ErrCode == "00");
            Assert.IsTrue(result.ErrMessage.IndexOf("Mike") >= 0);
            //=======================================================
            //沒有權限,密碼錯誤
            //=======================================================
            wsAuthWS.WebService1 wsNoAuth = new wsAuthWS.WebService1();
            wsAuthWS.AuthHeader headerNoAuth = new wsAuthWS.AuthHeader();
            headerNoAuth.UserName = "mike";
            headerNoAuth.Password = "12341";
            wsNoAuth.AuthHeaderValue = headerNoAuth;
            wsNoAuth.Url = Url;
            var resultNoAuth = wsNoAuth.HelloWorld("mike");
            Assert.IsTrue(resultNoAuth.ErrCode == "98");            
            Assert.IsTrue(resultNoAuth.ErrMessage.IndexOf("帳號或密碼有誤") >= 0);

            //=======================================================
            //認證header有誤
            //=======================================================
            wsAuthWS.WebService1 wsNoHeader= new wsAuthWS.WebService1();
            var resultNoHeaer = wsNoHeader.HelloWorld("mike");            
            wsNoHeader.Url = Url;
            Assert.IsTrue(resultNoHeaer.ErrCode == "99");
            Assert.IsTrue(resultNoHeaer.ErrMessage.IndexOf("認證有誤") >= 0);            


        }
    }
}
