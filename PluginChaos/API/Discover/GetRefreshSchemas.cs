using System;
using System.Collections.Generic;
using Google.Protobuf.Collections;
using Naveego.Sdk.Plugins;
using PluginChaos.API.Utility;
using PluginChaos.Helper;

namespace PluginChaos.API.Discover
{
    public static partial class Discover
    {
        public static async IAsyncEnumerable<Schema> GetRefreshSchemas(RepeatedField<Schema> refreshSchemas,
            Settings settings, int sampleSize = 5)
        {
            foreach (var schema in refreshSchemas)
            {
                var endpoint = EndpointHelper.GetEndpointForSchema(schema);

                var refreshSchema = await GetSchemaForEndpoint(schema, endpoint);

                // get sample and count
                yield return await AddSampleAndCount(refreshSchema, sampleSize, endpoint, settings);
            }
        }
    }
}