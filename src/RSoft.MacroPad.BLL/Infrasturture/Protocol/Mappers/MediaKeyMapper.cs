using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers
{
    public static class MediaKeyMapper
    {
        static readonly List<(MediaKey Key, VirtualKey Value)> _map = new List<(MediaKey, VirtualKey)>();
        static readonly List<(MediaKey Key, byte Version, byte B1, byte B2)> _byteMap = new List<(MediaKey, byte, byte, byte)>();
        static MediaKeyMapper()
        {
            var members = typeof(MediaKey).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var member in members)
            {
                ;
                var val = (MediaKey)member.GetValue(null);

                var attr = member.GetCustomAttribute<VirtualKeyMapAttribute>();
                _map.Add((val, attr.Key));

                var bAttrs = member.GetCustomAttributes<MediaValueAttribute>();
                foreach (var v in new[] { 0, 2, 3 })
                {
                    var bAttr = bAttrs.FirstOrDefault(a => a.Version == v);
                    _byteMap.Add((val, (byte)v, bAttr?.B1 ?? 0, bAttr?.B2 ?? 0));
                }
            }
        }

        public static MediaKey Map(this VirtualKey key) => _map.First(kvp => kvp.Value == key).Key;
        public static VirtualKey Map(this MediaKey key) => _map.First(kvp => kvp.Key == key).Value;

        public static byte B1(this MediaKey key, byte version) => _byteMap.First(kvp => kvp.Key == key && kvp.Version == version).B1;
        public static byte B2(this MediaKey key, byte version) => _byteMap.First(kvp => kvp.Key == key && kvp.Version == version).B2;
    }
}