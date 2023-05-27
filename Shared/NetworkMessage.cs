using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public abstract class NetworkMessage
    {
        public readonly Dictionary<string, object> Payload = new Dictionary<string, object>();

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override string ToString()
        {
            return ToJson();
        }
    }
}
