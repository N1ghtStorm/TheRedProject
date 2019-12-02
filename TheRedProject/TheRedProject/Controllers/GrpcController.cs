using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
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
        private readonly IGrpcAction _grpcAction;
        public GrpcController(IGrpcAction grpcAction)
        {
            _grpcAction = grpcAction;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]ConfigureGrpc conf)
        {
            var doc = ConvertToXmlByteArr(conf);
            var array = ConvertXmlToByteArr(doc);

            var result = await _grpcAction.ApiWriteAsync(conf.URL, array);

            //var reply = await grpc_act.SayHello(conf.URL, conf.Name);

            return Ok(result);
        }
        private XmlDocument ConvertToXmlByteArr(ConfigureGrpc conf)
        {
            XmlSerializer ser = new XmlSerializer(conf.GetType());
            XmlDocument xDoc = null;
            
            using (MemoryStream memStm = new MemoryStream())
            {
                ser.Serialize(memStm, conf);

                memStm.Position = 0;

                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;

                using (var xtr = XmlReader.Create(memStm, settings))
                {
                    xDoc = new XmlDocument();
                    xDoc.Load(xtr);
                }

            }

            return xDoc;
        }

        private byte[] ConvertXmlToByteArr(XmlDocument xDoc)
        {
            using MemoryStream stream = new MemoryStream(); //C#8 FEATURE, LIKE IT =)))
            xDoc.Save(stream);
            return stream.ToArray();
        }
    }
}