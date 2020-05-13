using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var lstType = typeof(List<>);
            var stringLstType = lstType.MakeGenericType(typeof(string));
            var stringLst = Activator.CreateInstance(stringLstType);


            //var assembly = GetAssembly();
            //InspectAssembly(assembly);
            //DynamicAdd();
            //FindTypes();
            GetAttribute();
            Console.ReadLine();
        }

        private static Assembly GetAssembly()
        {
            return Assembly.LoadFrom("DemoClassLib.dll");
        }

        private static void InspectAssembly(Assembly assembly)
        {
            Console.WriteLine(assembly.ToString());
            Console.WriteLine("Types:");
            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine("{0} {1}", type.IsPublic ? "P" : "I", type.FullName);
                var methods = type.GetMethods(BindingFlags.Default 
                    | BindingFlags.Public 
                    | BindingFlags.NonPublic 
                    | BindingFlags.Instance 
                    | BindingFlags.Static);
                foreach (var mth in methods)
                    Console.WriteLine("    {0} {1}", mth.IsPublic ? "P" : "I", mth.Name);
            }
        }

        private static void DynamicAdd()
        {
            var t = Type.GetType("DemoClassLib.Calculator, DemoClassLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f147ee9515a82f84");
            var calc = Activator.CreateInstance(t);
            var mth = t.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = mth.Invoke(calc, new object[] { 1, 2 });
            Console.WriteLine(result);
        }

        private static void FindTypes()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = from x in assembly.GetTypes() where typeof(MyBaseClass).IsAssignableFrom(x) // x.IsSubclassOf(typeof(MyBaseClass)) 
                        && !x.IsAbstract 
                        && x.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, Array.Empty<Type>(), null) != null
                        select x;
            foreach (var t in types)
                Console.WriteLine(t.FullName);
        }

        private static void GetAttribute()
        {
            var t = typeof(MyTestClass);
            var attr = t.GetCustomAttribute<LabelAttribute>();
            Console.WriteLine(attr.Label);
        }
    }
}
