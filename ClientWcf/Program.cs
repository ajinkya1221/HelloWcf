using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWcf
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new Service1Client();
            var a = client.GetData(43);
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
