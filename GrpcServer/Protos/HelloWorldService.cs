using Grpc.Core;

namespace GrpcServer.Protos
{
    //The HelloWorldService class inherits from the HelloWorld.HelloWorldBase class. The HelloWorld.HelloWorldBase class is a base class that provides the implementation for the SayHello() method in HelloWorld.proto that we have created.
    public class HelloWorldService : HelloWorld.HelloWorldBase
    {
        public override async Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {

            HelloReply responseModel = new HelloReply();
            try
            {
                Console.WriteLine($"Request From the Client:{request.Message}");
                responseModel.Message = "Hello From the Server";
                Console.WriteLine("Server Response Sent");
                return responseModel;
            }
            catch (Exception ex)
            {
                //log any error 
                throw;
            }
        }
    }
}
