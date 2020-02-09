using System;
using System;
using Grpc.Core;
using Calculadora;

namespace CalculadoraClient
{
    class Program
    {

        public static void Main(string[] args)
        {
          

            

            var sair = false;
            while (sair == false)
            {

                Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
                var client = new Operacao.OperacaoClient(channel);

                Console.WriteLine("Digite o primeiro parâmetro!");
                var parametro1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Digite a operação!(+ - / *)");
                var operacao = Console.ReadLine();

                Console.WriteLine("Digite o segundo parâmetro!");
                var parametro2 = int.Parse(Console.ReadLine());

                

                if (operacao == "+")
                {
                    Console.WriteLine("Resultado: : " + Soma(client, parametro1, parametro2).ToString());
                }
                else
                if (operacao == "-")
                {
                    Console.WriteLine("Resultado : " + Subtracao(client, parametro1, parametro2).ToString());
                }
                else
                if (operacao == "/")
                {
                    Console.WriteLine("Resultado : " + Divisao(client, parametro1, parametro2).ToString());
                }
                else
                if (operacao == "*")
                {
                    Console.WriteLine("Resultado : " + Multiplicao(client, parametro1, parametro2).ToString());
                }
                
                channel.ShutdownAsync().Wait();
                Console.WriteLine("Digite s para sair ou n para tentar novamente");

               
                sair = Console.ReadLine() == "s" ? true : false;


                Console.WriteLine("++++++++++++++++++++++++++++++++++");
                Console.WriteLine("");
            }
        }

        public static int Soma( Operacao.OperacaoClient client, int parametro1, int parametro2)
        {
            return client.Somar(new ParametroRequest { Primeiro = parametro1, Segundo = parametro2 }).Resultado;
        }

        public static int Divisao(Operacao.OperacaoClient client, int parametro1, int parametro2)
        {
            return client.Dividir(new ParametroRequest { Primeiro = parametro1, Segundo = parametro2 }).Resultado;
        }

        public static int Multiplicao(Operacao.OperacaoClient client, int parametro1, int parametro2)
        {
            return client.Multiplicar(new ParametroRequest { Primeiro = parametro1, Segundo = parametro2 }).Resultado;
        }

        public static int Subtracao(Operacao.OperacaoClient client, int parametro1, int parametro2)
        {
            return client.Subtrair(new ParametroRequest { Primeiro = parametro1, Segundo = parametro2 }).Resultado;
        }
    }
}

