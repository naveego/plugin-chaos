using System.Threading.Tasks;
using Naveego.Sdk.Plugins;
using PluginChaos.API.Utility;

namespace PluginChaos.API.Discover
{
    public static partial class Discover
    {
        public static Task<Count> GetCountOfRecords(Endpoint? endpoint)
        {
            return endpoint != null
                ? endpoint.GetCountOfRecords()
                : Task.FromResult(new Count {Kind = Count.Types.Kind.Unavailable});
        }
    }
}