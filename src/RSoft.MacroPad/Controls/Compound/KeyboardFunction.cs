using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using RSoft.MacroPad.BLL.Infrasturture.Model;
using RSoft.MacroPad.BLL.Infrasturture.Physical;
using RSoft.MacroPad.Model;

namespace RSoft.MacroPad.Controls.Compound
{
    public partial class KeyboardFunction : UserControl
    {
        private SetFunction function = SetFunction.KeySequence;
        private KeyboardLayout keyboardLayout;

        public SetFunction Function
        {
            get => function;
            set
            {
                function = value;
                UpdateTabs();
            }
        }

        public KeyboardLayout KeyboardLayout
        {
            get => keyboardLayout;
            set
            {
                keyboardLayout = value;
                UpdateLayout();
            }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        [Browsable(false)]
        public IEnumerable<KeyStroke> KeySequence
        {
            get => keyTab1.Sequence;
            set { keyTab1.Sequence = value; }
        }

        public ushort Delay
        {
            get => keyTab1.Delay;
            set { keyTab1.Delay = value; }
        }

        public Keys MediaKey
        {
            get => mediaKeyTab1.Key;
            set { mediaKeyTab1.Key = value; }
        }

        public MouseButton MouseButton
        {
            get => mouseButtonsTab1.MouseButton;
            set { mouseButtonsTab1.MouseButton = value; }
        }

        public Modifier MouseModifier
        {
            get => mouseButtonsTab1.Modifier;
            set { mouseButtonsTab1.Modifier = value; }
        }

        public LedColor LedColor
        {
            get => ledTab1.Color;
            set { ledTab1.Color = value; }
        }

        public LedMode LedMode
        {
            get => ledTab1.Mode;
            set { ledTab1.Mode = value; }
        }

        public KeyboardFunction()
        {
            InitializeComponent();

            tabControl1.SelectedIndexChanged += SelectedTabChanged;
            tabControl2.SelectedIndexChanged += SelectedTabChanged;

            UpdateTabs();
            UpdateLayout();
        }

        public void Reset()
        {
            KeySequence = null;
            Delay = 100;
            MediaKey = Keys.MediaPlayPause;
            MouseButton = MouseButton.Left;
            MouseModifier = Modifier.None;
            LedColor = LedColor.Random;
            LedMode = LedMode.Mode1;
        }

        private void SelectedTabChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabLed)
                Function = SetFunction.LED;
            else
            {
                if (tabControl2.SelectedTab == tabSequence)
                    Function = SetFunction.KeySequence;
                else if (tabControl2.SelectedTab == tabMedia)
                    Function = SetFunction.MediaKey;
                else Function = SetFunction.Mouse;
            }
            if (Function != SetFunction.KeySequence)
            {
                keyTab1.StopRecording();
            }
        }

        private void UpdateTabs()
        {
            if (function == SetFunction.LED)
            {
                tabControl1.SelectedTab = tabLed;
            }
            else
            {
                tabControl1.SelectedTab = tabFunction;
            }
            switch (function)
            {
                case SetFunction.LED: break;
                case SetFunction.KeySequence: tabControl2.SelectTab(tabSequence); break;
                case SetFunction.MediaKey: tabControl2.SelectTab(tabMedia); break;
                case SetFunction.Mouse: tabControl2.SelectTab(tabMouse); break;
            }
        }

        private void UpdateLayout()
        {
            if (keyboardLayout == null)
            {
                keyboardLayout = new KeyboardLayout
                {
                    LedModeCount = 3,
                    MaxCharacters = 5,
                    SupportsColor = false,
                    SupportsDelay = false,
                };
            }

            ledTab1.ColorsSupported = keyboardLayout.SupportsColor;
            ledTab1.ModeCount = keyboardLayout.LedModeCount;
            keyTab1.SequenceMaxLength = keyboardLayout.MaxCharacters;
            keyTab1.DelaySupported = keyboardLayout.SupportsDelay;
        }

        internal void StopRecording()
        {
            keyTab1.StopRecording();
        }
    }
}
