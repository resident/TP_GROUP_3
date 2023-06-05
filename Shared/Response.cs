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

        public string Status = StatusError;
        public string Message = string.Empty;

        public bool IsStatusOk()
        {
            return Status == StatusOk;
        }

        public bool IsStatusError()
        {
            return Status == StatusError;
        }

        public static Response? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Response>(json);
        }
    }
}
