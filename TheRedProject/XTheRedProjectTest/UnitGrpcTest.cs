using System;
using System.Collections.Generic;
using Moq;
using System.Text;
using Xunit;
using TheRedProject.Grpc;
using GrpcGreeter;
using System.Threading.Tasks;
using GrpcServiceTest;
using Microsoft.Extensions.Logging;
using Grpc.Core;
//using Grpc.Core.Testing;

namespace XTheRedProjectTest
{

    public class UnitGrpcTest
    {
        [Fact]
        public void TestGrpc()
        {
            //Arrange
            var mock = new Mock<IGrpcAction>();
            mock.Setup(a => a.SayHello("https://localhost:5001", "Dima")).Returns(Task.FromResult(new GrpcGreeter.HelloReply()));
            Console.WriteLine(mock.Object.ToString());
            //throw new Exception(mock.Object.SayHello("https://localhost:5001", "Dima"));
            IGrpcAction grpcAction = new GrpcAction();
            //GreeterService a = new GreeterService();
           

            //Act
            var result = grpcAction.SayHello("https://localhost:5001", "Dima");



            //Assert
            Assert.Equal(mock.Object.SayHello("https://localhost:5001", "Dima"),result);
        }
    }
}
    