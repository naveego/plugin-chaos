using Newtonsoft.Json;

namespace PluginChaos.DataContracts
{
    public class ApiError
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}