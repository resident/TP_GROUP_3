using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Response : NetworkMessage
    {
        public const string StatusOk = "OK";
        public const string StatusError = "ERROR";

        public string Status = string.Empty;
        public string Error = string.Empty;
        public string Message = string.Empty;

        public static Response? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Response>(json);
        }
    }
}
