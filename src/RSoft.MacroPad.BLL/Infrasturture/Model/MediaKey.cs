namespace RSoft.MacroPad.BLL.Infrasturture.Model
{
    public enum MediaKey : ushort
    {
        [MediaValue(0, 64, 0)]
        [MediaValue(2, 0, 4)]
        [MediaValue(3, 205, 0)]
        [VirtualKeyMap(VirtualKey.MediaPlayPause)]PlayPause,

        [MediaValue(0, 0, 1)]
        [MediaValue(2, 0, 10)]
        [MediaValue(3, 181, 0)]
        [VirtualKeyMap(VirtualKey.MediaNextTrack)]NextTrack,

        [MediaValue(0, 128, 0)]
        [MediaValue(2, 0, 11)]
        [MediaValue(3, 182, 0)]
        [VirtualKeyMap(VirtualKey.MediaPreviousTrack)]PrevTrack,

        [MediaValue(0, 4, 0)]
        [MediaValue(2, 0, 1)]
        [MediaValue(3, 226, 0)]
        [VirtualKeyMap(VirtualKey.VolumeMute)]VolMute,

        [MediaValue(0, 2, 0)]
        [MediaValue(2, 64, 0)]
        [MediaValue(3, 233, 0)]
        [VirtualKeyMap(VirtualKey.VolumeUp)]VolUp,

        [MediaValue(0, 1, 0)]
        [MediaValue(2, 128, 0)]
        [MediaValue(3, 234, 0)]
        [VirtualKeyMap(VirtualKey.VolumeDown)]VolDn
    }
}
