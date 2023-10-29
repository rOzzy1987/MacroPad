using System.Collections.Generic;
using RSoft.MacroPad.BLL.Infrasturture.Model;

namespace RSoft.MacroPad.BLL.Infrasturture.Physical
{
    public abstract class PhysicalControl
    {
        public abstract ControlType Type { get; }

        public virtual Vector Size { get; set; }

        public virtual Vector Position { get; set; }

        public string Name { get; set; }

        public IEnumerable<InputAction> Actions { get; protected set; }
    }

    public class PhysicalButton : PhysicalControl
    {
        public override ControlType Type => ControlType.Button;

        public PhysicalButton(int idx)
        {
            Size = new Vector(20, 20);
            Actions = new InputAction[] { (InputAction)idx };
        }
    }

    public class PhysicalKnob : PhysicalControl
    {
        public override ControlType Type => ControlType.Knob;

        public PhysicalKnob(int idx)
        {
            Size = new Vector(20, 20);

            var i = idx * 3 + 20;
            Actions = new[]
            {
                (InputAction)i,
                (InputAction)i+1,
                (InputAction)i+2,
            };
        }
    }
}
