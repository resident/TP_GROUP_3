using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Shared
{
    public abstract class NetworkMessage
    {
        public readonly Dictionary<string, object> Payload = new();

        public string GetString(string key, bool throwIfNull = true)
        {
            var value = Payload[key].ToString();

            if (throwIfNull && value == null) throw new NoNullAllowedException(key);

            return value ?? "";
        }

        public T? Get<T>(string key, bool throwIfNull)
        {
            var value = Payload[key] is T ? (T) Payload[key] : JsonConvert.DeserializeObject<T>(Payload[key].ToString() ?? "");

            if (throwIfNull && value == null) throw new NoNullAllowedException(key);

            return value;
        }

        public T Get<T>(string key)
        {
            return Get<T>(key, true)!;
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
