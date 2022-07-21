using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;
using Naveego.Sdk.Plugins;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace PluginChaos.Helper
{
    
    public class Settings
    {
        public string ConnectionName { get; set; }

        public int RecordLimit { get; set; } = 100;
        
        /// <summary>
        /// Validates the settings input object
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Validate()
        {
            if (RecordLimit < 1)
            {
                throw new Exception("Record Limit must be greater than 0");
            }
        }
        public int GetRecordLimit()
        {
            return GetRecordLimit();
        }
    }
}