using System;

namespace RSoft.MacroPad.BLL.Infrasturture.Model
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class MediaValueAttribute : Attribute
    {
        public byte B1 { get; }
        public byte B2 { get; }
        public byte Version { get; }

        public MediaValueAttribute(byte version, byte b1, byte b2)
        {
            Version = version;
            B1 = b1;
            B2 = b2;
        }

    }
}
