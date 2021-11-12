using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var appContext = new AppContext();
            appContext.SaveChanges();
        }
    }
}
