using System;

namespace RSoft.MacroPad.BLL.Infrasturture.Model
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class VirtualKeyMapAttribute : Attribute
    {
        public VirtualKey Key { get; }

        public VirtualKeyMapAttribute(VirtualKey key)
        {
            Key = key;
        }
    }
}