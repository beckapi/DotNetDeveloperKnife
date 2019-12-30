using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFramework.ado.net
{
   public class DemoDao:BaseDao
    {

        public int UpdateData(string name,int age)
        {
          return  ExcauteNoneQuery(
                "update Person set name=@name,age=@age",
                new Dictionary<string, string> {
                    {"name",name},
                    { "age",age.ToString()}
                }
                );
        }
    }
}
