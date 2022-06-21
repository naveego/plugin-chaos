using System;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PluginChaos.DataContracts
{
    public class GenericRecord
        
    {
        [JsonProperty("Id")] public int Id { get; set; }
        [JsonProperty("Name")] public string Name { get; set; }
        [JsonProperty("Description")] public string Description { get; set; }
        [JsonProperty("Bool")]public bool _Bool { get; set; }
        [JsonProperty("Byte")]public byte _Byte { get; set; }
        [JsonProperty("Int")]public int _Int { get; set; }
        [JsonProperty("Float")]public float _Float { get; set; }
        [JsonProperty("Char")]public char _Char { get; set; }
        [JsonProperty("String")]public string _String { get; set; }
        [JsonProperty("DateTime")]public DateTime _DateTime { get; set; }
    }
}