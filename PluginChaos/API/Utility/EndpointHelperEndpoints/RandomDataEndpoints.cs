using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using PluginChaos.Helper;
using Serilog.Formatting.Display;

namespace PluginChaos.API.Utility.EndpointHelperEndpoints
{
    public static class RandomDataEndpointHelper
    {
        private class RandomDataEndpoint : Endpoint
        {
            public override async IAsyncEnumerable<Record> ReadRecordsAsync(Schema schema,  int recordLimit = 100, 
                bool isDiscoverRead = false)
            {
                var limit = recordLimit;
                var count = 0;

                while (count < limit)
                {
                    var genRecord = Utility.GenerateRecord(new Utility.GenerateRecordOptions
                    {
                        RandomData = true,
                    });
                
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
                "RandomDataEndpoint", new RandomDataEndpoint
                {
                    Id = "RandomDataEndpoint",
                    Name = "RandomData Endpoint",

                    SupportedActions = new List<EndpointActions>
                    {
                        EndpointActions.Get
                    }
                }
            }
        };
    }
}