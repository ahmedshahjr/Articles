using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using HangFire.Protos;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static HangFire.Protos.HelloWorld;

namespace HangFIre.Service
{
    public class HangFireJobManager
    {
        public async Task<bool> ExecuteFireAndForgetJob()
        {
            try
            {
                //serviceEndpoint contains the address of the gRPC server.
                var serviceEndpoint = "https://localhost:7218";

                //The GrpcChannel.ForAddress() method creates a channel to the gRPC server. The GrpcChannelOptions object specifies that the channel will use the GrpcWebHandler to handle HTTP requests.
                var channel = GrpcChannel.ForAddress(serviceEndpoint, new GrpcChannelOptions
                {
                    HttpHandler = new GrpcWebHandler(new HttpClientHandler())
                });
               // The HelloWorld service is a gRPC service that is defined in the HelloWorld.proto file. The HelloWorld.HelloWorldClient class is a class that provides a client for the HelloWorld service.
               var client = new HelloWorld.HelloWorldClient(channel);
                //The helloRequest variable is a HelloRequest message. The Message field of the helloRequest message is set to the string "Calling Server From Client".
                Console.WriteLine("Sending Request to Server");
                var helloRequest = new HelloRequest
                {
                    Message = "Calling Server From Client"
                };
                //The client.SayHello() method sends the helloRequest message to the server and returns a HelloReply message.
                var ServerResponse = await Task.FromResult(client.SayHello(helloRequest));
               // The Serverresponse variable is a HelloReply message.The Message field of the Serverresponse message is set to the greeting that the server sent to the client.
                Console.WriteLine($"Server Reponse :{ServerResponse.Message}");
                return true;

            }
            catch (Exception ex)
            {
                //logging needs to be implemeented
            }
            return true;
        }

    }
}