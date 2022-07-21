using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Naveego.Sdk.Logging;
using Naveego.Sdk.Plugins;
using Newtonsoft.Json;
using PluginChaos.API.Utility.EndpointHelperEndpoints;
using PluginChaos.DataContracts;

namespace PluginChaos.API.Utility
{
    public static class EndpointHelper
    {
        private static readonly Dictionary<string, Endpoint> Endpoints = new Dictionary<string, Endpoint>();

        static EndpointHelper()
        {
            // add all implementations
            ThrowsExceptionEndpointHelper.Endpoints.ToList().ForEach(x => Endpoints.TryAdd(x.Key, x.Value));
            RandomDataEndpointHelper.Endpoints.ToList().ForEach(x => Endpoints.TryAdd(x.Key, x.Value));
            DuplicateEndpointHelper.Endpoints.ToList().ForEach(x => Endpoints.TryAdd(x.Key, x.Value));
            MaybeReturnEndpointHelper.Endpoints.ToList().ForEach(x => Endpoints.TryAdd(x.Key, x.Value));
            LongPauseEndpointHelper.Endpoints.ToList().ForEach(x => Endpoints.TryAdd(x.Key, x.Value));
            RandomIntervalEndpointHelper.Endpoints.ToList().ForEach(x => Endpoints.TryAdd(x.Key, x.Value));
        }

        public static Dictionary<string, Endpoint> GetAllEndpoints()
        {
            return Endpoints;
        }

        public static Endpoint? GetEndpointForId(string id)
        {
            return Endpoints.ContainsKey(id) ? Endpoints[id] : null;
        }

        public static Endpoint? GetEndpointForSchema(Schema schema)
        {
            var endpointMetaJson = JsonConvert.DeserializeObject<dynamic>(schema.PublisherMetaJson);
            string endpointId = endpointMetaJson.Id;
            return GetEndpointForId(endpointId);
        }
    }

    public class Endpoint
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        public List<EndpointActions> SupportedActions { get; set; } = new List<EndpointActions>();

        public virtual Task<Count> GetCountOfRecords()
        {
            return Task.FromResult(new Count
            {
                Kind = Count.Types.Kind.Unavailable,
            });
        }

        public virtual async IAsyncEnumerable<Record> ReadRecordsAsync(Schema schema, int recordLimit = 100, bool isDiscoverRead = false)
        {
            throw new NotImplementedException();
            yield break;
        }

        public virtual async Task<string> WriteRecordAsync(Schema schema, Record record,
            IServerStreamWriter<RecordAck> responseStream)
        {
            throw new NotImplementedException();
        }

        public virtual Task<Schema> GetStaticSchemaAsync(Schema schema)
        {
            var properties = new List<Property>();

            var propertyId = new Property
            {
                Id = "Id",
                Name = "Id",
                Type = PropertyType.Integer,
                IsKey = true,
                IsNullable = false,
                TypeAtSource = "int"
            };
            properties.Add(propertyId);

            var propertyName = new Property
            {
                Id = "Name",
                Name = "Name",
                Type = PropertyType.String,
                IsKey = false,
                IsNullable = true,
                TypeAtSource = "string"
            };
            properties.Add(propertyName);

            var propertyDescription = new Property
            {
                Id = "Description",
                Name = "Description",
                Type = PropertyType.String,
                IsKey = false,
                IsNullable = true,
                TypeAtSource = "string"
            };
            properties.Add(propertyDescription);
                
            var propertyBool = new Property
            {
                Id = "Bool",
                Name = "Bool",
                Type = PropertyType.Bool,
                IsKey = false,
                IsNullable = true,
                TypeAtSource = "bool"
            };
            properties.Add(propertyBool);
                
            var propertyByte = new Property
            {
                Id = "Byte",
                Name = "Byte",
                Type = PropertyType.Integer,
                IsKey = false,
                IsNullable = true,
                TypeAtSource = "byte"
            };
            properties.Add(propertyByte);
                
            var propertyInt = new Property
            {
                Id = "Int",
                Name = "Int",
                Type = PropertyType.Integer,
                IsKey = false,
                IsNullable = true,
                TypeAtSource = "int"
            };
            properties.Add(propertyInt);
                
            var propertyFloat = new Property
            {
                Id = "Float",
                Name = "Float",
                Type = PropertyType.Float,
                IsKey = false,
                IsNullable = true,
                TypeAtSource = "float"
            };
            properties.Add(propertyFloat);
                
            var propertyChar = new Property
            {
                Id = "Char",
                Name = "Char",
                Type = PropertyType.String,
                IsKey = false,
                IsNullable = true,
                TypeAtSource = "char"
            };
            properties.Add(propertyChar);
                
            var propertyString = new Property
            {
                Id = "String",
                Name = "String",
                Type = PropertyType.String,
                IsKey = false,
                IsNullable = true,
                TypeAtSource = "string"
            };
            properties.Add(propertyString);
                
            var propertyDateTime = new Property
            {
                Id = "DateTime",
                Name = "DateTime",
                Type = PropertyType.Datetime,
                IsKey = false,
                IsNullable = true,
                TypeAtSource = "DateTime"
            };
            properties.Add(propertyDateTime);

            schema.Properties.AddRange(properties);
            
            return Task.FromResult(schema);
        }

        public Schema.Types.DataFlowDirection GetDataFlowDirection()
        {
            if (CanRead() && CanWrite())
            {
                return Schema.Types.DataFlowDirection.ReadWrite;
            }

            if (CanRead() && !CanWrite())
            {
                return Schema.Types.DataFlowDirection.Read;
            }

            if (!CanRead() && CanWrite())
            {
                return Schema.Types.DataFlowDirection.Write;
            }

            return Schema.Types.DataFlowDirection.Read;
        }


        private bool CanRead()
        {
            return SupportedActions.Contains(EndpointActions.Get);
        }

        private bool CanWrite()
        {
            return SupportedActions.Contains(EndpointActions.Post) ||
                   SupportedActions.Contains(EndpointActions.Put) ||
                   SupportedActions.Contains(EndpointActions.Delete);
        }
    }

    public enum EndpointActions
    {
        Get,
        Post,
        Put,
        Delete
    }
}