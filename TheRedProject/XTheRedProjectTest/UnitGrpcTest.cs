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
        public async void TestGrpc()
        {
            //Arrange
            var mock = new Mock<IGrpcAction>();
            mock.Setup(a => a.SayHello("https://localhost:5001", "Dima")).ReturnsAsync(new GrpcGreeter.HelloReply { Message = "Hello Dima"});
            Console.WriteLine(mock.Object.ToString());
            IGrpcAction grpcAction = new GrpcAction();          

            //Act
            var result = await grpcAction.SayHello("https://localhost:5001", "Dima");

            var mock_result = await mock.Object.SayHello("https://localhost:5001", "Dima");

            //Assert
            Assert.Equal(result, mock_result);
        }
    }
}
    