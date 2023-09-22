using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            var cls1 = new Item(123) { Name = "Item1" };
            var cls2 = new Item(123) { Name = "Item1" };
            var obj1 = (object)cls1;
            Console.WriteLine("cls1.Equals(cls2): {0}", 
                cls1.Equals(cls2));
            Console.WriteLine("cls1 == cls2: {0}", 
                cls1 == cls2);
            Console.WriteLine("obj1 == cls2: {0}", 
                obj1 == cls2);
            Console.ReadLine();
        }
    }
}
