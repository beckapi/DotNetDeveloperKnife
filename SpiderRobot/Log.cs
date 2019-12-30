using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderRobot
{
   public class Log
    {
        public static void Write(string content)
        {
            using (StreamWriter sr = new StreamWriter("log.txt",true))
            {
                sr.WriteLine(content);
            }
            Console.WriteLine(content);
        }
    }
}
