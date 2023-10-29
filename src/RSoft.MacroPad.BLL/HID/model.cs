using System;
using System.Runtime.InteropServices;

namespace HID
{
    public enum DIGCF
    {
        DIGCF_DEFAULT = 1,
        DIGCF_PRESENT = 2,
        DIGCF_ALLCLASSES = 4,
        DIGCF_PROFILE = 8,
        DIGCF_DEVICEINTERFACE = 16, // 0x00000010
    }

    public struct HIDD_ATTRIBUTES
    {
        public int Size;
        public ushort VendorID;
        public ushort ProductID;
        public ushort VersionNumber;
    }


    public struct HIDP_CAPS
    {
        public ushort Usage;
        public ushort UsagePage;
        public ushort InputReportByteLength;
        public ushort OutputReportByteLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public ushort[] Reserved;
        public ushort NumberLinkCollectionNodes;
        public ushort NumberInputButtonCaps;
        public ushort NumberInputValueCaps;
        public ushort NumberInputDataIndices;
        public ushort NumberOutputButtonCaps;
        public ushort NumberOutputValueCaps;
        public ushort NumberOutputDataIndices;
        public ushort NumberFeatureButtonCaps;
        public ushort NumberFeatureValueCaps;
        public ushort NumberFeatureDataIndices;
    }

    public class report : EventArgs
    {
        public readonly byte reportID;
        public readonly byte[] reportBuff;

        public report(byte id, byte[] arrayBuff)
        {
            this.reportID = id;
            this.reportBuff = arrayBuff;
        }
    }


    public struct SP_DEVICE_INTERFACE_DATA
    {
        public int cbSize;
        public Guid interfaceClassGuid;
        public int flags;
        public int reserved;
    }


    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
        internal int cbSize;
        internal short devicePath;
    }


    [StructLayout(LayoutKind.Sequential)]
    public class SP_DEVINFO_DATA
    {
        public int cbSize = Marshal.SizeOf(typeof(SP_DEVINFO_DATA));
        public Guid classGuid = Guid.Empty;
        public int devInst;
        public int reserved;
    }
}
