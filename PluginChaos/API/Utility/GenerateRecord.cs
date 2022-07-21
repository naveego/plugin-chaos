using System;
using System.Data.Common;
using System.Linq.Expressions;
using PluginChaos.DataContracts;

namespace PluginChaos.API.Utility
{
    public static partial class Utility
    {
        public class GenerateRecordOptions
        {
            public bool GenerateDuplicate { get; set; }
            public bool LongPause { get; set; }
            public bool RandomInterval { get; set; }
            public bool MaybeReturn { get; set; }
            public bool RandomData { get; set; }
            public bool ThrowsException { get; set; }
        }

        public static GenerateRecordOptions? DefaultOptions = new GenerateRecordOptions
        {
            GenerateDuplicate = false,
            LongPause = false,
            RandomInterval = false,
            MaybeReturn = false,
            RandomData = false,
            ThrowsException = false
        };

        public static GenericRecord GenerateRecord(GenerateRecordOptions? options = null)
        {
            switch (options)
            {
                case { GenerateDuplicate: true }:
                    return new GenericRecord
                    {
                        Id = 5,
                        Name = "Generic Name",
                        Description = "Generic Description",
                        Bool = false,
                        Byte = 255,
                        Int = 100,
                        Float = 3.14f,
                        Char = '\0',
                        String = "GenericString",
                        DateTime = DateTime.Today
                        
                    };
                case { RandomData: true }:
                    return new GenericRecord
                    {
                        Id = GenerateInt(),
                        Name = GenerateString(),
                        Description = GenerateString(),
                        Bool = GenerateBool(),
                        Byte = GenerateByte(),
                        Int = GenerateInt(),
                        Float = GenerateFloat(),
                        Char = GenerateChar(),
                        String = GenerateString(),
                        DateTime = GenerateDateTime(),
                    };
                default:
                    options = DefaultOptions;
                    return new GenericRecord
                    {
                        Id = GenerateInt(),
                        Name = GenerateString(),
                        Description = GenerateString(),
                        Bool = GenerateBool(),
                        Byte = GenerateByte(),
                        Int = GenerateInt(),
                        Float = GenerateFloat(),
                        Char = GenerateChar(),
                        String = GenerateString(),
                        DateTime = GenerateDateTime(),
                    };
            }
        }
        
    }
}
