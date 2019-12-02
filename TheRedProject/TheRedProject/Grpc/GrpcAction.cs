﻿using Google.Protobuf;
using Grpc.Net.Client;
using GrpcComServ;
using GrpcGreeter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRedProject.Grpc
{
    public class GrpcAction : IGrpcAction
    {
        public async Task<HelloReply> SayHello(string url, string clientName)
        {
            // address maybe url = "https://localhost:5001"
            var channel = GrpcChannel.ForAddress(url);
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = clientName });


            //Console.WriteLine("Greeting: " + reply.Message);
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();
            return reply;
        }

        public async Task<Result> ApiWriteAsync(string url, byte[] fileContainer)
        {
            var channel = GrpcChannel.ForAddress(url);
            var client = new ApiGateway.ApiGatewayClient(channel);
            //client.
            //var r = client.SetConfig();
            var result = await client.SetConfig();
            using var codedOutputStream = new CodedOutputStream(fileContainer);
            result.WriteTo(codedOutputStream);
            return result;
        }
    }
}
