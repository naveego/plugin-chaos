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
        [JsonProperty("Bool")]public bool Bool { get; set; }
        [JsonProperty("Byte")]public byte Byte { get; set; }
        [JsonProperty("Int")]public int Int { get; set; }
        [JsonProperty("Float")]public double Float { get; set; }
        [JsonProperty("Char")]public char Char { get; set; }
        [JsonProperty("String")]public string String { get; set; }
        [JsonProperty("DateTime")]public DateTime DateTime { get; set; }
        
    }
}