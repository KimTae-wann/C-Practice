using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;

namespace WCFHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(_39WCFService.HelloService));
            host.Open(); // 서비스 시작

            Console.WriteLine("서비스 시작");
            Console.WriteLine("Press any Key to STOP");
            Console.ReadLine();

            host.Close();
        }
    }
}
