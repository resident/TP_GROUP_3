using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public abstract class NetworkMessage
    {
        public readonly Dictionary<string, object> Payload = new Dictionary<string, object>();

        public string Get(string key, bool throwIfNull = true)
        {
            var value = Payload[key].ToString();

            if (throwIfNull && value == null) throw new ArgumentNullException(key);

            return value ?? "";
        }

        public T? Get<T>(string key, bool throwIfNull = true)
        {
            var value = Payload[key] is T ? (T) Payload[key] : JsonConvert.DeserializeObject<T>(Payload[key].ToString() ?? "");

            if (throwIfNull && value == null) throw new ArgumentNullException(key);

            return value;
        }

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
