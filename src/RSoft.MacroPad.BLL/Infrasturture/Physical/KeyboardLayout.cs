using System.Collections.Generic;
using System.Linq;

namespace RSoft.MacroPad.BLL.Infrasturture.Physical
{
    public class KeyboardLayout
    {
        public string Name { get; set; }

        public IEnumerable<(ushort VendorId, ushort ProductId)> Products { get; set; }

        public byte LayerCount { get; set; }
        public byte MaxCharacters { get; set; }
        public bool SupportsDelay { get; set; }
        public bool SupportsColor { get; set; }
        public byte LedModeCount { get; set; }

        public IEnumerable<PhysicalControl> Controls { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Controls.Count(c => c is PhysicalButton)} button(s), {Controls.Count(c =>c is PhysicalKnob)} knob(s), {LayerCount} layer(s))";
        }
    }

}
