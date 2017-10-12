/*   Software developped to control Input pins on Raspberry Pi 
 * 	=> get the PinValue and send Email in case of emergency
 * 
 * This Software uses the Nanite Library for using the GPIO of the Raspberry Pi
 * 
 * Created : 09 October 2017
 * Autor : Mouaad Gssair  Mgsair@gmail.com
 * 
 */

using System;
using Nanite.IO;
using Nanite.Exceptions;
using Nanite.IO.Devices;

namespace RPi_EmailSender
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//initialise Pins
			const int E_STOP = (int)PINE64.Pi.Pin3; ;
			const int SCHALTER = (int)PINE64.Pi.Pin5;;

            //Set Pins as Input        
				GPIO.PinMode(E_STOP, GPIO.Direction.Input);
				GPIO.PinMode(SCHALTER, GPIO.Direction.Input);


			// Loop
            while(true)
			{
				GPIO.Value E_PinValue = (GPIO.Value) GPIO.Read(E_STOP);
				GPIO.Value S_PinValue = (GPIO.Value) GPIO.Read(SCHALTER);
				if(E_PinValue == 0)
				{
					Console.WriteLine("\n\n Error occurred! user stopped the machine. \n\n");

					// SMTP should be configured in the devices
					// See :https://www.raspberrypi.org/forums/viewtopic.php?t=32077
					// Email will be sent to : Mgsair@gmail.com, with the Subject : Emergency
					Terminal.ExecuteCommand("echo \"Error occurred! user stopped the machine.\" | mail -s Emergency Mgsair@gmail.com");

				}
				else if(S_PinValue == 0)
				{
					Console.WriteLine("\n\n Error occurred! Machine touched the Limit switches. \n\n");
					Terminal.ExecuteCommand("echo \"Error occurred! user stopped the machine.\" | mail -s LimitSwitch Mgsair@gmail.com");

				}
			}

		}

	}
}
