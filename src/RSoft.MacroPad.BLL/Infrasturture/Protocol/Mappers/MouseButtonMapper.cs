using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers
{
    public static class MouseButtonMapper
    {
        static readonly List<(MouseButton Key, VirtualKey Value)> _map = new List<(MouseButton, VirtualKey)>();
        static readonly List<(MouseButton Key, byte Button, byte Scroll)> _byteMap = new List<(MouseButton, byte, byte)>();
        static MouseButtonMapper()
        {
            var members = typeof(MouseButton).GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var member in members)
            {
                var val = (MouseButton)member.GetValue(null);

                var attr = member.GetCustomAttribute<VirtualKeyMapAttribute>();
                _map.Add((val, attr.Key));

                var mAttr = member.GetCustomAttribute<MouseValuesAttribute>();
                _byteMap.Add((val, mAttr.Buttons, mAttr.Scroll));
                
            }
        }

        public static byte Button(this MouseButton key) => _byteMap.First(kvp => kvp.Key == key).Button;
        public static byte Scroll(this MouseButton key) => _byteMap.First(kvp => kvp.Key == key).Scroll;
    }
}