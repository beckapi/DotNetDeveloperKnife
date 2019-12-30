using CommonFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpiderRobot
{
   public class Taobao
    {
        public string username { get; set; }
        public string password { get; set; }

        private HttpMethod httpMethod = new HttpMethod();
        private static string loginUrl = "https://login.taobao.com/member/login.jhtml";

        public void Login()
        {
            Log.Write(DateTime.Now + "   进行登录操作...");
            var passportUrl = GetPassportUrl(username, password);
            Log.Write(DateTime.Now + "获取passporturl成功");
            var st = GetStCode(passportUrl);
            Log.Write(DateTime.Now + "获取st成功");
            GetLogindCookie(st);
        }

        public string GetLoginedPage(string url)
        {
            return httpMethod.Get(url,null,"GB2312");
        }

        public string GetPassportUrl(string username,string encodePwd)
        {
            var post_dic = new Dictionary<string, string>();
            post_dic["TPL_username"] = username;
            post_dic["TPL_password_2"] = encodePwd;
            post_dic["ncoToken"] = "adbc69b96a7cdc7506b8b88bac9844cc5e33ecb4";
            post_dic["slideCodeShow"] = "flase";
            post_dic["useMobile"] = "false";
            post_dic["lang"] = "zh_CN";
            post_dic["loginsite"] = "0";
            post_dic["newlogin"] = "0";
            post_dic["from"] = "tb";
            post_dic["fc"] = "default";
            post_dic["style"] = "default";
            post_dic["keyLogin"] = "false";
            post_dic["newMini"] = "false";
            post_dic["newMini2"] = "false";
            post_dic["loginType"] = "3";
            post_dic["gvfdcname"] = "10";
            post_dic["gvfdcre"] = "68747470733A2F2F6C6F67696E2E74616F62616F2E636F6D2F6D656D6265722F6C6F676F75742E6A68746D6C3F73706D3D61317A30392E322E3735343839343433372E372E653130333265386478523736687926663D746F70266F75743D7472756526726564697265637455524C3D6874747073253341253246253246627579657274726164652E74616F62616F2E636F6D25324674726164652532466974656D6C6973742532466C6973745F626F756768745F6974656D732E68746D25334673706D253344613231626F2E323031372E313939373532353034352E322E35616639313164396730796C6E61";
            post_dic["oslanguage"] = "CN";

            post_dic["loginASR"] = "1";
            post_dic["loginASRSuc"] = "1";
            post_dic["um_token"] = "TE3A1C36F7CB7FCD6CEDAF279530BED8DDFCD023F4E789EF7E8012A7DB3";
            post_dic["ua"] = "122#4bmcaE9UEEa08DpZMEpaEJponDJE7SNEEP7rEJ+//CeERFQLpo7iEDpWnDEeK51HpyGZp9hBuDEEJFOPpC76EJponDJL7gNpEPXZpJRgu4Ep+FQLpoGUEJLWn4yP7SQEEyuLpERLWytyprZCnaRx9kbNkbFDf/pG4FPLJztyi9Qj5k4YqH0SoWKtRaTZ14GXHLlGWf2LScRQWmvbpadsuS3KqhMSBNFBcE9EDEPQwgp1uOLWP3Hw8VdTJzEEyBF3RneCDo9ongplul5EELXrGCpiAx3DJF3mqWfWEJpanS+ituaHDtVZ85G6JDEERFtDqMfbDEpxnSp1uOIEEL7Z8CLUJ4bEyF3mqW32D5pangL4ul0EDLIL8oL6x4qEyB3maMLVx4bWy7hl+7PLmqDL35y5bSR8LhpPkk1KW05dVqj+W2vVQ2M17YEcBtfKd6ktELJdf3K4UPJ90Bo2Sb30ha/soo62Hb7wpkf/lQJtwYYAUSpM+IbHEoTnMUOc6ws3MvreGy9bXy5yrMeHO27NgMYuUbiDkc3nM1RBPwSEdC6yV0ppBhBze57mX8cPGye8Uc6s1loK5cysvz15g7CUTivdsDsKCKNcUKS84k5+xvSJabycEd5sVQFE10IleJcruaBU8b7Ge2cSrOIasom1nauOrCqZmGIyid9s68cQKrP77K5XeLFTiC2xHcgMijk4aygOanZqss6U2gE3ZtE7k8NoQl/YuvXT0IeahidCYQuXASAM6YnXRBpGrTWVhq8st4g4n/+vHdOuZbFEHM7v4dduikifPM42ji4FWQCNEg9RFbXtP9RurwYoZ5F8rGOAueri69MWkcVW1qu8dkcO1BbrGLEpqcSKtri9avcyetQInthhMYGqSRMBvv95Ysqntz3oN3QgT1XRRu933vP8A1Vx2uBpgDbpdKuG2AGOqGBkTb0hltyBCy0BCIcbaLn1ZIPyB7RHFV4WZKreYM9YIIunlE9zcJVNb8kIY51JetIC99s4cGofVNVHXfDKy67lQFuGctsS9+4aEPilslUD82ljF2P6AtZ8ajRqRfbRgKw9zsyDsLbtPJsyTIwrUfn7dXeafgpSqNp3k8/9GW/n+wcqq5+ZhuaKG2kg2Q11Znik7lc1uZLnn+RLwx66pkSS7c3l+hN04GYrvnctYfGsZozZjsZGNMinkfIcwdcasy2V4gp8kgg47ROSJMJebFjnrBWMNIVS/WaU9KbeOLlmQQk4UDFz1akxQ+ESckReFoLDa5T8Y3mqOoLhfOwdv6l7XeGSHgXvR9qo0niOOnZVZBUYLk7M0Qfmn4arI4oI5whvD8/u0bJnphDZtOeE6Z12W7pRnr/ayD==";
            var postdata = new StringBuilder();
            foreach (var key in post_dic.Keys)
            {
                postdata.Append(key);
                postdata.Append("=");
                postdata.Append(post_dic[key]);
                postdata.Append("&");
            }

            var header = new Dictionary<string, string>();
            header["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.70 Safari/537.36";
            var res = httpMethod.Post(loginUrl,postdata.ToString(),header,"GB2312");
            var passPortStartIndex = res.IndexOf("https://passport.alibaba.com");
            if (passPortStartIndex < 0)
            {
                throw new Exception("获取passport url 失败， 需要验证码");
            }
            else
            {
                res = res.Substring(passPortStartIndex);
                res = res.Substring(0, res.IndexOf("\""));
            }
            return res;
        }

        public string GetStCode(string passportUrl)
        {
            var res = httpMethod.Get(passportUrl,null);
            var stIndex = res.IndexOf("st");
            if (stIndex < 0)
            {
                throw new Exception("获取st失败");
            }
            else
            {
                res = res.Substring(stIndex+5);
                res = res.Substring(0,res.IndexOf("\""));
            }
            return res;
        }

        private void GetLogindCookie(string stCode)
        {
            var url = string.Format("https://login.taobao.com/member/vst.htm?st={0}", stCode);
             httpMethod.Get(url, null);
        }
    }
}
