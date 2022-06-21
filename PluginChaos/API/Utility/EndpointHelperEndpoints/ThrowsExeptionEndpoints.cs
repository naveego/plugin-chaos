using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public static class ThrowsExceptionEndpointHelper
    {
        private class ThrowsExceptionEndpoint : Endpoint
        {
            public override async IAsyncEnumerable<Record> ReadRecordsAsync(Schema schema,
                bool isDiscoverRead = false)
            {
                var limit = 100;
                var count = 0;
                while (count < limit)
                {
                    throw new Exception("No Records Found Chaos Error.");
                    var genRecord = Utility.GenerateRecord();

                    var record = new Record
                    {
                        Action = Record.Types.Action.Upsert,
                        DataJson = JsonConvert.SerializeObject(genRecord)
                    };
                    //returns nothing
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
                "ThrowsExceptionEndpoint", new ThrowsExceptionEndpoint
                {
                    Id = "ThrowsExceptionEndpoint",
                    Name = "ThrowsException Endpoint",

                    SupportedActions = new List<EndpointActions>
                    {
                        EndpointActions.Get
                    }
                }
            }
        };
    }
}