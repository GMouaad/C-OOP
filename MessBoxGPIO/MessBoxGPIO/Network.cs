using System;
using System.IO;

namespace MessBoxGPIO
{
	public static class Network
	{
		public static void configNetwork(string SSID, string Psk)
		{
			try
			{
				FileStream theStream = new FileStream("/etc/wpa_supplicant/wpa_supplicant.conf", FileMode.Create);
				StreamWriter theWriter = new StreamWriter(theStream);
				theWriter.WriteLine();
				theWriter.WriteLine("network={\n\tssid=\"{0}\"\n\tpsk=\"{1}\" \n} ", SSID, Psk);
				theWriter.Close();
				theStream.Close();
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("\n\n ***** Error occured ! Can not open file! *****\n\n");
			}
		}
		public static void configNetwork(string SSID)
		{
			try
			{
				FileStream theStream = new FileStream("/etc/wpa_supplicant/wpa_supplicant.conf", FileMode.Create);
				StreamWriter theWriter = new StreamWriter(theStream);
				theWriter.WriteLine();
				theWriter.WriteLine("network={\n\tssid=\"{0}\"\n\tkey_mgmt=NONE \n}", SSID);
				theWriter.Close();
				theStream.Close();
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("\n\n ***** Error occured ! Can not open file! *****\n\n");
			}
		}
	}
}
