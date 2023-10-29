using System;

namespace RSoft.MacroPad.BLL.Infrasturture.Model
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class MouseValuesAttribute : Attribute
    {
        public byte Buttons { get; }
        public byte Scroll { get; }

        public MouseValuesAttribute(byte buttons, byte scroll)
        {
            Buttons = buttons;
            Scroll = scroll;
        }

    }
}
