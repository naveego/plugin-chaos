using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Grpc.Core;
using Naveego.Sdk.Logging;
using Naveego.Sdk.Plugins;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PluginChaos.DataContracts;
using Serilog.Formatting.Display;

namespace PluginChaos.API.Utility.EndpointHelperEndpoints
{
    public static class MaybeReturnEndpointHelper
    {
        private class MaybeReturnEndpoint : Endpoint
        {
            public override async IAsyncEnumerable<Record> ReadRecordsAsync(Schema schema,
                bool isDiscoverRead = false)
            {
                var limit = 100;
                var count = 0;
                while (count < limit)
                {
                    // Random even number will return record, odd will not.
                    var rnd = new Random();
                    var rndInt = rnd.Next();
                    if (rndInt % 2 != 0)
                    {
                        yield break;
                    }
                    var genRecord = Utility.GenerateRecord();

                    var record = new Record
                    {
                        Action = Record.Types.Action.Upsert,
                        DataJson = JsonConvert.SerializeObject(genRecord)
                    };
                    yield return record;
                    count++;
                }
            }
            
            public override Task<Count> GetCountOfRecords()
            {
                return base.GetCountOfRecords();
            }
        }

        public static readonly Dictionary<string, Endpoint> Endpoints = new Dictionary<string, Endpoint>
        {
            {
                "MaybeReturnEndpoint", new MaybeReturnEndpoint
                {
                    Id = "MaybeReturnEndpoint",
                    Name = "MaybeReturn Endpoint",

                    SupportedActions = new List<EndpointActions>
                    {
                        EndpointActions.Get
                    }
                }
            }
        };
    }
}