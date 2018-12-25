using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Helpers.Concrete
{
    class JsonContent:StringContent
    {
        public JsonContent(object obj) :base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {

            throw new NotImplementedException();
        }

        protected override bool TryComputeLength(out long length)
        {
            throw new NotImplementedException();
        }
    }
}
