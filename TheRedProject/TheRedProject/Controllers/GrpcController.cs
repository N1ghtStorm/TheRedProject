using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRedProject.Grpc;
using TheRedProject.Models;

namespace TheRedProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrpcController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostASync([FromBody]ConfigureGrpc conf)
        {
            var grpc_act = new GrpcAction();
            var reply = await grpc_act.SayHello(conf.URL, conf.Name);

            return Ok(reply);
        }
    }
}