using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Naveego.Sdk.Plugins;
using Newtonsoft.Json;
using PluginChaos.API.Utility;
using PluginChaos.DataContracts;
using PluginChaos.Helper;

namespace PluginChaos.API.Discover
{
    public static partial class Discover
    {
        public static async IAsyncEnumerable<Schema> GetAllSchemas(Settings settings,
            int sampleSize = 5)
        {
            var allEndpoints = EndpointHelper.GetAllEndpoints();

            foreach (var endpoint in allEndpoints.Values)
            {
                // base schema to be added to
                var schema = new Schema
                {
                    Id = endpoint.Id,
                    Name = endpoint.Name,
                    Description = "",
                    PublisherMetaJson = JsonConvert.SerializeObject(endpoint),
                    DataFlowDirection = endpoint.GetDataFlowDirection()
                    
                };

                schema = await GetSchemaForEndpoint(schema, endpoint);

                // get sample and count
                yield return await AddSampleAndCount(schema, sampleSize, endpoint);
            }
        }

        private static async Task<Schema> AddSampleAndCount(Schema schema,
            int sampleSize, Endpoint? endpoint)
        {
            if (endpoint == null)
            {
                return schema;
            }

            // add sample and count
            var records = Read.Read.ReadRecordsAsync(schema).Take(sampleSize);
            schema.Sample.AddRange(await records.ToListAsync());
            schema.Count = await GetCountOfRecords(endpoint);

            return schema;
        }

        private static async Task<Schema> GetSchemaForEndpoint(Schema schema, Endpoint? endpoint)
        {
            if (endpoint == null)
            {
                return schema;
            }

            return await endpoint.GetStaticSchemaAsync(schema);
        }
    }
}