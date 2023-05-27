using Newtonsoft.Json;

namespace Shared
{
    public class Request : NetworkMessage
    {
        public readonly string Action;

        public Request(string action = "")
        {
            Action = action.ToLower();
        }

        public static Request? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Request>(json);
        }
    }
}
