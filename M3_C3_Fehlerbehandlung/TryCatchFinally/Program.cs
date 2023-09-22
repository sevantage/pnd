using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SubMethod();
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("Main: Caught ArgumentException with message {0}", argEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main: Caught exception with message {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("Main: Finally");
            }
            Console.ReadLine();
        }

        static void SubMethod()
        {
            try
            {
                Console.WriteLine("Running SubMethod");
                SubSubMethod();
            }
            catch
            {
                throw;
            }
        }

        static void SubSubMethod()
        {
            throw new ApplicationException("Demo exception");
        }

        static void ThrowsApplicationExceptionMethod()
        {
            Console.WriteLine("Running ThrowsApplicationExceptionMethod");
            throw new ApplicationException("Demo exception");
        }

        static void ThrowsArgumentNullExceptionMethod()
        {
            Console.WriteLine("Running ThrowsArgumentNullExceptionMethod");
            throw new ArgumentNullException("Null argument");
        }

        static void RethrowsExceptionMethod()
        {
            try
            {
                Console.WriteLine("Running RethrowsExceptionMethod");
                throw new ApplicationException("Demo exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine("RethrowsExceptionMethod: Caught exception with message {0}", ex.Message);
                throw;
            }
        }

        static void ExceptionInCatchBlockMethod()
        {
            try
            {
                Console.WriteLine("Running ExceptionInCatchBlockMethod");
                throw new ApplicationException("Demo exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ExceptionInCatchBlockMethod: Caught exception with message {0}", ex.Message);
                throw new Exception("Exception raised in catch block.");
            }
        }
    }
}
