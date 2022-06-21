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
                        _Bool = false,
                        _Byte = 255,
                        _Int = 100,
                        _Float = 3.14f,
                        _Char = '\0',
                        _String = "GenericString",
                        _DateTime = DateTime.Now
                    };
                case { RandomData: true }:
                    return new GenericRecord
                    {
                        Id = GenerateInt(),
                        Name = GenerateString(),
                        Description = GenerateString(),
                        _Bool = GenerateBool(),
                        _Byte = GenerateByte(),
                        _Int = GenerateInt(),
                        _Float = GenerateFloat(),
                        _Char = GenerateChar(),
                        _String = GenerateString(),
                        _DateTime = GenerateDateTime()
                    };
                default:
                    options = DefaultOptions;
                    return new GenericRecord
                    {
                        Id = 5,
                        Name = "Generic Name",
                        Description = "Generic Description",
                        _Bool = false,
                        _Byte = 255,
                        _Int = 100,
                        _Float = 3.14f,
                        _Char = '\0',
                        _String = "GenericString",
                        _DateTime = DateTime.Now
                    };
            }
        }
        
    }
}
