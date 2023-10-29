using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using System;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers
{
    public static class KeyCodeMapper
    {
        static readonly List<(KeyCode Key, VirtualKey Value)> _map = new List<(KeyCode, VirtualKey)>();
        static KeyCodeMapper()
        {
            var members = typeof(KeyCode).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var member in members)
            {
                var attr = member.GetCustomAttribute<VirtualKeyMapAttribute>();
                _map.Add(((KeyCode)member.GetValue(null), attr.Key));
            }
            foreach (var sc in Enum.GetValues(typeof(VirtualKey)).Cast<VirtualKey>())
            {
                if (!_map.Any(kvp => kvp.Value == sc))
                {
                    _map.Add((KeyCode.None, sc));
                }
            }
        }
        public static KeyCode Map(this VirtualKey key) => _map.FirstOrDefault(kvp => kvp.Value == key).Key;
        public static VirtualKey Map(this KeyCode key) => _map.First(kvp => kvp.Key == key).Value;
    }
}