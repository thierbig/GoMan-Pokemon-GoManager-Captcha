using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic;

namespace GoMan.Helpers
{
    public class Hwid
    {
        public static string FingerPrint => ComputerFingerPrint.Value();
        public static string MacId => ComputerFingerPrint.ValueMacId();
        private static class ComputerFingerPrint
        {
            private static string _fingerPrint = string.Empty;
            public static string Value()
            {
                if (string.IsNullOrEmpty(_fingerPrint))
                {
                    _fingerPrint = GetHash("CPU >> " + CpuId() + Constants.vbLf + "BIOS >> " + BiosId() + Constants.vbLf + "BASE >> " + BaseId() + Constants.vbLf + "DISK >> " + DiskId() + Constants.vbLf + "VIDEO >> " + VideoId());
                }
                return _fingerPrint;
            }

            public static string ValueRaw()
            {
                if (string.IsNullOrEmpty(_fingerPrint))
                {
                    _fingerPrint = "CPU >> " + CpuId() + Constants.vbLf + "BIOS >> " + BiosId() + Constants.vbLf + "BASE >> " + BaseId() + Constants.vbLf + "DISK >> " + DiskId() + Constants.vbLf + "VIDEO >> " + VideoId();
                }
                return _fingerPrint;
            }

            public static string ValueMacId()
            {
                return MacId();
            }
            private static string GetHash(string s)
            {
                MD5 sec = new MD5CryptoServiceProvider();
                ASCIIEncoding enc = new ASCIIEncoding();
                byte[] bt = enc.GetBytes(s);
                return GetHexString(sec.ComputeHash(bt));
            }
            private static string GetHexString(byte[] bt)
            {
                string s = string.Empty;
                for (int i = 0; i <= bt.Length - 1; i++)
                {
                    byte b = bt[i];
                    int n = 0;
                    int n1 = 0;
                    int n2 = 0;
                    n = Convert.ToInt32(b);
                    n1 = n & 15;
                    n2 = (n >> 4) & 15;
                    if (n2 > 9)
                    {
                        s += (Strings.ChrW(n2 - 10 + Strings.AscW('A'))).ToString();
                    }
                    else {
                        s += n2.ToString();
                    }
                    if (n1 > 9)
                    {
                        s += (Strings.ChrW(n1 - 10 + Strings.AscW('A'))).ToString();
                    }
                    else {
                        s += n1.ToString();
                    }
                    if ((i + 1) != bt.Length && (i + 1) % 2 == 0)
                    {
                        s += "-";
                    }
                }
                return s;
            }
            #region "Original Device ID Getting Code"
            //Return a hardware identifier
            private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
            {
                string result = "";
                ManagementClass mc = new ManagementClass(wmiClass);
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (var o in moc)
                {
                    var mo = (ManagementObject) o;
                    if (mo[wmiMustBeTrue].ToString() == "True")
                    {
                        //Only get the first one
                        if (string.IsNullOrEmpty(result))
                        {
                            try
                            {
                                result = mo[wmiProperty].ToString();
                                break; // TODO: might not be correct. Was : Exit Try
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                return result;
            }

            private static string identifierQuick(string wmiClass, string wmiProperty)
            {
                dynamic mbs = new ManagementObjectSearcher("Select " + wmiProperty + " From " + wmiClass);
                ManagementObjectCollection mbsList = mbs.Get();
                string id = "";
                foreach (var o in mbsList)
                {
                    var mo = (ManagementObject) o;
                    try
                    {
                        id = mo[wmiProperty].ToString();
                        return id;
                    }
                    catch (Exception)
                    {
                        //ignored
                    }
                }

                return id;
            }

            //Return a hardware identifier
            private static string identifier(string wmiClass, string wmiProperty)
            {
                string result = "";
                System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
                System.Management.ManagementObjectCollection moc = mc.GetInstances();
                foreach (var o in moc)
                {
                    var mo = (ManagementObject) o;
                    //Only get the first one
                    if (string.IsNullOrEmpty(result))
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break; // TODO: might not be correct. Was : Exit Try
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                }
                return result;
            }
            private static string CpuId()
            {
                //Uses first CPU identifier available in order of preference
                //Don't get all identifiers, as it is very time consuming
                string retVal = identifierQuick("Win32_Processor", "UniqueId");
                if (string.IsNullOrEmpty(retVal))
                {
                    //If no UniqueID, use ProcessorID
                    retVal = identifierQuick("Win32_Processor", "ProcessorId");
                    if (string.IsNullOrEmpty(retVal))
                    {
                        //If no ProcessorId, use Name
                        retVal = identifier("Win32_Processor", "Name");
                        if (string.IsNullOrEmpty(retVal))
                        {
                            //If no Name, use Manufacturer
                            retVal = identifier("Win32_Processor", "Manufacturer");
                        }
                        //Add clock speed for extra security
                        retVal += identifier("Win32_Processor", "MaxClockSpeed");
                    }
                }
                return retVal;
            }
            //BIOS Identifier
            private static string BiosId()
            {
                return identifier("Win32_BIOS", "Manufacturer") + identifier("Win32_BIOS", "SMBIOSBIOSVersion") + identifier("Win32_BIOS", "IdentificationCode") + identifier("Win32_BIOS", "SerialNumber") + identifier("Win32_BIOS", "ReleaseDate") + identifier("Win32_BIOS", "Version");
            }
            //Main physical hard drive ID
            private static string DiskId()
            {
                return identifier("Win32_DiskDrive", "Model") + identifier("Win32_DiskDrive", "Manufacturer") + identifier("Win32_DiskDrive", "Signature") + identifier("Win32_DiskDrive", "TotalHeads");
            }
            //Motherboard ID
            private static string BaseId()
            {
                return identifier("Win32_BaseBoard", "Model") + identifier("Win32_BaseBoard", "Manufacturer") + identifier("Win32_BaseBoard", "Name") + identifier("Win32_BaseBoard", "SerialNumber");
            }
            //Primary video controller ID
            private static string VideoId()
            {
                return identifier("Win32_VideoController", "DriverVersion") + identifier("Win32_VideoController", "Name");
            }
            //First enabled network card ID
            private static string MacId()
            {
                return identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
            }
            #endregion
        }
    }
}
