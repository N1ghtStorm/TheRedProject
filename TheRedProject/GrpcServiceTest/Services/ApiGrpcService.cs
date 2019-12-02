using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcComServ;
using Microsoft.Extensions.Logging;

namespace GrpcServiceTest.Services
{
    public class ApiGrpcService : ApiGateway.ApiGatewayBase
    {
        private readonly ILogger<ApiGrpcService> _logger;
        public ApiGrpcService(ILogger<ApiGrpcService> logger)
        {
            _logger = logger;
        }

        public override Task GetConfig(Empty request, IServerStreamWriter<FilePart> responseStream, ServerCallContext context)
        {
            //return base.GetConfig(request, responseStream, context);
            //responseStream.WriteAsync();
            throw new RpcException(new Status(StatusCode.Unimplemented, "LOOOLOLOLOLOLOL"));
        }

        public override Task<Result> SetConfig(IAsyncStreamReader<FilePart> requestStream, ServerCallContext context)
        {
            var a = requestStream.ReadAllAsync();
            var b = a.GetAsyncEnumerator();
            //b.Current();
            a.ConfigureAwait(true);
            return Task.FromResult(new Result
            {

            }); 

            // throw new RpcException(new Status(StatusCode.Unimplemented, a.ToString()));
            // base.SetConfig(requestStream, context);
        }
    }
}
