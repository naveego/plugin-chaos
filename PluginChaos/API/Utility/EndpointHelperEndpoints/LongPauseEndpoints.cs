using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
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
    public static class LongPauseEndpointHelper
    {
        private class LongPauseEndpoint : Endpoint
        {
            public override async IAsyncEnumerable<Record> ReadRecordsAsync(Schema schema,
                bool isDiscoverRead = false)
            {
                var genRecord = Utility.GenerateRecord();

                var record = new Record
                {
                    Action = Record.Types.Action.Upsert,
                    DataJson = JsonConvert.SerializeObject(genRecord)
                };
                
                //Sleeps 10 seconds before returning.
                Thread.Sleep(10000);
                
                yield return record;
            }

            public override Task<Count> GetCountOfRecords( )
            {
                return base.GetCountOfRecords();
            }
        }

        public static readonly Dictionary<string, Endpoint> Endpoints = new Dictionary<string, Endpoint>
        {
            {
                "LongPauseEndpoint", new LongPauseEndpoint
                {
                    Id = "LongPauseEndpoint",
                    Name = "LongPause Endpoint",

                    SupportedActions = new List<EndpointActions>
                    {
                        EndpointActions.Get
                    }
                }
            }
        };
    }
}