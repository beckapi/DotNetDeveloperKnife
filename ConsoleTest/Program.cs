using System;
using SpiderRobot;
using System.Threading;

namespace ConsoleTest
{
   public class Program
    {
        static string username = "fishd2";
        static string pwd = "46d5c0e7f880529e305845a73c75dd386fa1eadbae7885c9e13b84df90069de7f9a5d41be1044907e70816a9e25d8ae302a286b2c3e1d0a85722d306b8884e9cf8f5f3a060e5f0c41341712842022fecb40da9e37ca13a69a9e1bb19d069aa376648d6af07283673e126e3c3e7bde23500e56aadd93400b6c37b2497a58fafdc";

        static void Main(string[] args)
        {
            Taobao taobao = new Taobao();
            taobao.username = username;
            taobao.password = pwd;

            while (true)
            {
                try
                {
                    var s = taobao.GetLoginedPage("https://cart.taobao.com/cart.htm?spm=a1z09.2.a2109.d1000367.64122e8dvPxJdg&nekot=1470211439694");
                    var result = s.IndexOf("日本包车九州到东京");
                    if (result > 0)
                    {
                        Log.Write(DateTime.Now + "    获取成功");
                    }
                    else
                    {
                        Log.Write(DateTime.Now + "      获取失败");
                        taobao.Login();
                    }
                }
                catch (Exception ex)
                {
                    Log.Write(DateTime.Now +   " 处理出错：" +ex.Message);
                }

                Thread.Sleep(  1000);
            }
           
        }
     
    }
}
