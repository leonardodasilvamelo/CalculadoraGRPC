using System;
using Grpc.Core;
using Calculadora;


using System.Threading.Tasks;

namespace CalculadoraServer
{

    class CalculadoraImpl : Operacao.OperacaoBase
    {
        
        public override Task<ParametroReply> Somar(ParametroRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ParametroReply { Resultado = request.Primeiro + request.Segundo });
        }

        public override Task<ParametroReply> Dividir(ParametroRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ParametroReply { Resultado = request.Primeiro / request.Segundo });
        }

        public override Task<ParametroReply> Subtrair(ParametroRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ParametroReply { Resultado = request.Primeiro - request.Segundo });
        }

        public override Task<ParametroReply> Multiplicar(ParametroRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ParametroReply { Resultado = request.Primeiro * request.Segundo });
        }

    }

    class Program
    {
        const int Port = 50051;

        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Operacao.BindService(new CalculadoraImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
