
using System.Collections.Generic;
using System.Linq;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Protocol;

namespace RSoft.MacroPad.BLL.Infrasturture
{
    public class ComposerRepository
    {
        public List<(IReportComposer Composer, ProtocolType Type, byte Version)> _cache;

        public ComposerRepository()
        {
            _cache = new List<(IReportComposer Composer, ProtocolType Type, byte Version)>();
        }

        public IReportComposer Get(ProtocolType type, byte version)
        {
            var i = _cache.FindIndex(x => x.Type == type && x.Version == version);
            
            if (i != -1)
                return _cache[i].Composer;

            var result = type == ProtocolType.Legacy
                ? (IReportComposer)new LegacyReportComposer(version)
                : new ExtendedReportComposer(version);
            _cache.Add((result, type, version));
            return result;
        }

    }
}
