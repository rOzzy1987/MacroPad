using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.BLL.Infrasturture.Protocol.Mappers
{
    internal static class InputActionMapper
    {
        public static byte MapToByte(this InputAction action)
        {
            switch (action)
            {
                case InputAction.Key1:
                case InputAction.Key2:
                case InputAction.Key3:
                case InputAction.Key4:
                case InputAction.Key5:
                case InputAction.Key6:
                case InputAction.Key7:
                case InputAction.Key8:
                case InputAction.Key9:
                case InputAction.Key10:
                case InputAction.Key11:
                case InputAction.Key12:
                    return (byte)action;
                case InputAction.Knob1Left:
                case InputAction.Knob1Push:
                case InputAction.Knob1Right:
                case InputAction.Knob2Left:
                case InputAction.Knob2Push:
                case InputAction.Knob2Right:
                case InputAction.Knob3Left:
                case InputAction.Knob3Push:
                case InputAction.Knob3Right:
                    return (byte)((int)action - 10);
            }

            return 0;
        }
    }
}
