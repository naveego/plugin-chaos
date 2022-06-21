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
        [JsonProperty("_Bool")]public bool _Bool { get; set; }
        [JsonProperty("_Byte")]public byte _Byte { get; set; }
        [JsonProperty("_Int")]public int _Int { get; set; }
        [JsonProperty("_Float")]public double _Float { get; set; }
        [JsonProperty("_Char")]public char _Char { get; set; }
        [JsonProperty("_String")]public string _String { get; set; }
        [JsonProperty("_DateTime")]public DateTime _DateTime { get; set; }
        [JsonProperty("_Decimal")]public decimal _Decimal { get; set; }
    }
}