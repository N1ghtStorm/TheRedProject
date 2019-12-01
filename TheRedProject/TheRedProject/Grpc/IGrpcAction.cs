using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRedProject.Grpc
{
    public interface IGrpcAction
    {
        Task SayHello(string url, string clientName);
    }
}
