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
using Serilog.Formatting.Display;

namespace PluginChaos.API.Utility.EndpointHelperEndpoints
{
    public static class DuplicateEndpointHelper
    {
        private class DuplicateEndpoint : Endpoint
        {
           
            public override async IAsyncEnumerable<Record> ReadRecordsAsync(Schema schema,
                bool isDiscoverRead = false)
            {
                
                var count = 0;
                while (true)
                {
                    var genRecord = Utility.GenerateRecord(new Utility.GenerateRecordOptions
                    {
                        GenerateDuplicate = true
                    });

                    var record = new Record
                    {
                        Action = Record.Types.Action.Upsert,
                        DataJson = JsonConvert.SerializeObject(genRecord)
                    };
                    yield return record;

                    if (count == 2)
                    {
                        break;
                    }

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
                "DuplicateEndpoint", new DuplicateEndpoint
                {
                    Id = "DuplicateEndpoint",
                    Name = "Duplicate Endpoint",

                    SupportedActions = new List<EndpointActions>
                    {
                        EndpointActions.Get
                    }
                }
            }
        };
    }
}