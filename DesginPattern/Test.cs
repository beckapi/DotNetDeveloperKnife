using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesginPattern
{
    public class Test
    {
        public void Run()
        {
            Animal dog = new Dog { Name="狗"};
            
            dog.Brak();
        }
        
    }

    class Animal
    {
        public string Name { get; set; }
        public virtual void Brak()
        {
            Console.WriteLine("叫"+Name);
        }
    }

    class Dog : Animal
    {
        public override void Brak()
        {
            base.Brak();
            Console.WriteLine("我又重写了一下");
        }
    }

}
