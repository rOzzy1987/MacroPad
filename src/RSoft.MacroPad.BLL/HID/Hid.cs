using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace HID
{
    public class Hid
    {
        public const uint GENERIC_READ = 2147483648;
        public const uint GENERIC_WRITE = 1073741824;
        public const uint FILE_SHARE_READ = 1;
        public const uint FILE_SHARE_WRITE = 2;
        public const int OPEN_EXISTING = 3;
        private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        private const int MAX_USB_DEVICES = 64;
        private bool deviceOpened;
        private FileStream hidDevice;
        private IAsyncResult readResult;
        private int outputReportLength;
        private int inputReportLength;

        public int OutputReportLength => this.outputReportLength;

        public int InputReportLength => this.inputReportLength;

        public static Hid.HID_RETURN GetDeviceSerialList(
          ushort vID,
          ushort pID,
          ref List<string> serialList)
        {
            serialList.Clear();
            List<string> deviceList = new List<string>();
            Hid.GetHidDeviceList(ref deviceList);
            if (deviceList.Count == 0)
                return Hid.HID_RETURN.NO_DEVICE_CONECTED;
            for (int index = 0; index < deviceList.Count; ++index)
            {
                IntPtr file = Hid.CreateFile(deviceList[index], 3221225472U, 0U, 0U, 3U, 1073741824U, 0U);
                if (file != Hid.INVALID_HANDLE_VALUE)
                {
                    IntPtr num = Marshal.AllocHGlobal(512);
                    HIDD_ATTRIBUTES attributes;
                    Hid.HidD_GetAttributes(file, out attributes);
                    Hid.HidD_GetSerialNumberString(file, num, 512);
                    string stringAuto = Marshal.PtrToStringAuto(num);
                    Marshal.FreeHGlobal(num);
                    if ((int)attributes.VendorID == (int)vID && (int)attributes.ProductID == (int)pID)
                        serialList.Add(stringAuto);
                    Hid.CloseHandle(file);
                }
            }
            return Hid.HID_RETURN.SUCCESS;
        }

        public IntPtr OpenDevice(ushort vID, ushort pID)
        {
            if (this.deviceOpened)
                return Hid.INVALID_HANDLE_VALUE;
            List<string> deviceList = new List<string>();
            Hid.GetHidDeviceList(ref deviceList);
            if (deviceList.Count == 0)
                return Hid.INVALID_HANDLE_VALUE;
            for (int index = 0; index < deviceList.Count; ++index)
            {
                IntPtr file = Hid.CreateFile(deviceList[index], 3221225472U, 0U, 0U, 3U, 1073741824U, 0U);
                if (file != Hid.INVALID_HANDLE_VALUE)
                {
                    IntPtr num = Marshal.AllocHGlobal(512);
                    HIDD_ATTRIBUTES attributes;
                    if (!Hid.HidD_GetAttributes(file, out attributes))
                    {
                        Hid.CloseHandle(file);
                        return Hid.INVALID_HANDLE_VALUE;
                    }
                    Hid.HidD_GetSerialNumberString(file, num, 512);
                    Marshal.PtrToStringAuto(num);
                    Marshal.FreeHGlobal(num);
                    if ((int)attributes.VendorID == (int)vID && (int)attributes.ProductID == (int)pID)
                    {
                        IntPtr PreparsedData;
                        Hid.HidD_GetPreparsedData(file, out PreparsedData);
                        HIDP_CAPS Capabilities;
                        int caps = (int)Hid.HidP_GetCaps(PreparsedData, out Capabilities);
                        Hid.HidD_FreePreparsedData(PreparsedData);
                        this.outputReportLength = (int)Capabilities.OutputReportByteLength;
                        this.inputReportLength = (int)Capabilities.InputReportByteLength;
                        this.hidDevice = new FileStream(new SafeFileHandle(file, false), FileAccess.ReadWrite, this.inputReportLength, true);
                        this.deviceOpened = true;
                        this.BeginAsyncRead();
                        return file;
                    }
                }
                Hid.CloseHandle(file);
            }
            return Hid.INVALID_HANDLE_VALUE;
        }

        public bool Opened => this.deviceOpened;

        public void CloseDevice(IntPtr device)
        {
            if (!this.deviceOpened)
                return;
            this.deviceOpened = false;
            this.hidDevice.Close();
            Hid.CloseHandle(device);
        }

        private void BeginAsyncRead()
        {
            byte[] numArray = new byte[this.InputReportLength];
            IntPtr handle = this.hidDevice.Handle;
            this.readResult = this.hidDevice.BeginRead(numArray, 0, this.InputReportLength, new AsyncCallback(this.ReadCompleted), (object)numArray);
        }

        private void ReadCompleted(IAsyncResult iResult)
        {
            byte[] asyncState = (byte[])iResult.AsyncState;
            try
            {
                if (!this.deviceOpened)
                    return;
                this.hidDevice.EndRead(iResult);
                byte[] arrayBuff = new byte[asyncState.Length - 1];
                for (int index = 1; index < asyncState.Length; ++index)
                    arrayBuff[index - 1] = asyncState[index];
                this.OnDataReceived(new report(asyncState[0], arrayBuff));
                this.BeginAsyncRead();
            }
            catch (IOException ex)
            {
                this.OnDeviceRemoved(new EventArgs());
            }
        }

        public event EventHandler<report> DataReceived;

        protected virtual void OnDataReceived(report e)
        {
            if (this.DataReceived == null)
                return;
            this.DataReceived((object)this, e);
        }

        public event EventHandler DeviceRemoved;

        protected virtual void OnDeviceRemoved(EventArgs e)
        {
            this.deviceOpened = false;
            if (this.DeviceRemoved == null)
                return;
            this.DeviceRemoved((object)this, e);
        }

        public Hid.HID_RETURN Write(report r)
        {
            if (this.deviceOpened)
            {
                try
                {
                    byte[] buffer = new byte[this.outputReportLength];
                    buffer[0] = r.reportID;
                    int num = r.reportBuff.Length >= this.outputReportLength - 1 ? this.outputReportLength - 1 : r.reportBuff.Length;
                    for (int index = 1; index <= num; ++index)
                        buffer[index] = r.reportBuff[index - 1];
                    this.hidDevice.Write(buffer, 0, 65);
                    return Hid.HID_RETURN.SUCCESS;
                }
                catch
                {
                }
            }
            return Hid.HID_RETURN.WRITE_FAILD;
        }

        public static void GetHidDeviceList(ref List<string> deviceList)
        {
            Guid empty = Guid.Empty;
            deviceList.Clear();
            Hid.HidD_GetHidGuid(ref empty);
            IntPtr classDevs = Hid.SetupDiGetClassDevs(ref empty, 0U, IntPtr.Zero, DIGCF.DIGCF_PRESENT | DIGCF.DIGCF_DEVICEINTERFACE);
            if (classDevs != IntPtr.Zero)
            {
                SP_DEVICE_INTERFACE_DATA deviceInterfaceData = new SP_DEVICE_INTERFACE_DATA();
                deviceInterfaceData.cbSize = Marshal.SizeOf((object)deviceInterfaceData);
                for (uint memberIndex = 0; memberIndex < 64U; ++memberIndex)
                {
                    if (Hid.SetupDiEnumDeviceInterfaces(classDevs, IntPtr.Zero, ref empty, memberIndex, ref deviceInterfaceData))
                    {
                        int requiredSize = 0;
                        Hid.SetupDiGetDeviceInterfaceDetail(classDevs, ref deviceInterfaceData, IntPtr.Zero, requiredSize, ref requiredSize, (SP_DEVINFO_DATA)null);
                        IntPtr num = Marshal.AllocHGlobal(requiredSize);
                        Marshal.StructureToPtr((object)new SP_DEVICE_INTERFACE_DETAIL_DATA()
                        {
                            cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DETAIL_DATA))
                        }, num, false);
                        if (Hid.SetupDiGetDeviceInterfaceDetail(classDevs, ref deviceInterfaceData, num, requiredSize, ref requiredSize, (SP_DEVINFO_DATA)null))
                            deviceList.Add(Marshal.PtrToStringAuto((IntPtr)((int)num + 4)));
                        Marshal.FreeHGlobal(num);
                    }
                }
            }
            Hid.SetupDiDestroyDeviceInfoList(classDevs);
        }

        [DllImport("hid.dll")]
        private static extern void HidD_GetHidGuid(ref Guid HidGuid);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern IntPtr SetupDiGetClassDevs(
          ref Guid ClassGuid,
          uint Enumerator,
          IntPtr HwndParent,
          DIGCF Flags);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetupDiDestroyDeviceInfoList(IntPtr deviceInfoSet);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetupDiEnumDeviceInterfaces(
          IntPtr deviceInfoSet,
          IntPtr deviceInfoData,
          ref Guid interfaceClassGuid,
          uint memberIndex,
          ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetupDiGetDeviceInterfaceDetail(
          IntPtr deviceInfoSet,
          ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
          IntPtr deviceInterfaceDetailData,
          int deviceInterfaceDetailDataSize,
          ref int requiredSize,
          SP_DEVINFO_DATA deviceInfoData);

        [DllImport("hid.dll")]
        private static extern bool HidD_GetAttributes(
          IntPtr hidDeviceObject,
          out HIDD_ATTRIBUTES attributes);

        [DllImport("hid.dll")]
        private static extern bool HidD_GetSerialNumberString(
          IntPtr hidDeviceObject,
          IntPtr buffer,
          int bufferLength);

        [DllImport("hid.dll")]
        private static extern bool HidD_GetPreparsedData(
          IntPtr hidDeviceObject,
          out IntPtr PreparsedData);

        [DllImport("hid.dll")]
        private static extern bool HidD_FreePreparsedData(IntPtr PreparsedData);

        [DllImport("hid.dll")]
        private static extern uint HidP_GetCaps(IntPtr PreparsedData, out HIDP_CAPS Capabilities);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateFile(
          string fileName,
          uint desiredAccess,
          uint shareMode,
          uint securityAttributes,
          uint creationDisposition,
          uint flagsAndAttributes,
          uint templateFile);

        [DllImport("kernel32.dll")]
        private static extern int CloseHandle(IntPtr hObject);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern bool ReadFile(
          IntPtr file,
          byte[] buffer,
          uint numberOfBytesToRead,
          out uint numberOfBytesRead,
          IntPtr lpOverlapped);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern bool WriteFile(
          IntPtr file,
          byte[] buffer,
          uint numberOfBytesToWrite,
          out uint numberOfBytesWritten,
          IntPtr lpOverlapped);

        [DllImport("User32.dll", SetLastError = true)]
        private static extern IntPtr RegisterDeviceNotification(
          IntPtr recipient,
          IntPtr notificationFilter,
          int flags);

        public static IntPtr RegisterHIDNotification(IntPtr recipient)
        {
            IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Hid.DevBroadcastDeviceInterfaceBuffer)));
            Marshal.StructureToPtr((object)new Hid.DevBroadcastDeviceInterfaceBuffer(5), num, false);
            return Hid.RegisterDeviceNotification(recipient, num, 0);
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnregisterDeviceNotification(IntPtr handle);

        public static bool UnRegisterHIDNotification(IntPtr hDEVNotify) => Hid.UnregisterDeviceNotification(hDEVNotify);

        public enum HID_RETURN
        {
            SUCCESS,
            NO_DEVICE_CONECTED,
            DEVICE_NOT_FIND,
            DEVICE_OPENED,
            WRITE_FAILD,
            READ_FAILD,
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DevBroadcastDeviceInterfaceBuffer
        {
            [FieldOffset(0)]
            public int dbch_size;
            [FieldOffset(4)]
            public int dbch_devicetype;
            [FieldOffset(8)]
            public int dbch_reserved;

            public DevBroadcastDeviceInterfaceBuffer(int deviceType)
            {
                this.dbch_size = Marshal.SizeOf(typeof(Hid.DevBroadcastDeviceInterfaceBuffer));
                this.dbch_devicetype = deviceType;
                this.dbch_reserved = 0;
            }
        }
    }
}
