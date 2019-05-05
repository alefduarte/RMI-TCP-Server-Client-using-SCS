using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Service;
using VoldeMoveis_CommonLib;

namespace VoldeMoveis_Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(10048));

            server.AddService<IVoldeMoveisService, VoldemoveisServices>(new VoldemoveisServices());

            server.Start();

            Console.WriteLine(
                "Servidor Iniciado com sucesso. Pressione Enter para parar...");
            Console.ReadLine();

            server.Stop();
        }
    }
}
