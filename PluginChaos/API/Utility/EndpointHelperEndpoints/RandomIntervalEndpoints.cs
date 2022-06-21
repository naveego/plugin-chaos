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
    public static class RandomIntervalEndpointHelper
    {
        private class RandomIntervalEndpoint : Endpoint
        {
            public override async IAsyncEnumerable<Record> ReadRecordsAsync(Schema schema,
                bool isDiscoverRead = false)
            {
                var limit = 100;
                var count = 0;
                while (count < limit)
                {
                    var genRecord = Utility.GenerateRecord();

                    var record = new Record
                    {
                        Action = Record.Types.Action.Upsert,
                        DataJson = JsonConvert.SerializeObject(genRecord)
                    };
                    //Random pause between .1 and 5 seconds for records.
                    var rnd = new Random();
                    var rndInt = rnd.Next(100, 5000);
                    Thread.Sleep(rndInt);
                
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
                "RandomIntervalEndpoint", new RandomIntervalEndpoint
                {
                    Id = "RandomIntervalEndpoint",
                    Name = "RandomInterval Endpoint",

                    SupportedActions = new List<EndpointActions>
                    {
                        EndpointActions.Get
                    }
                }
            }
        };
    }
}