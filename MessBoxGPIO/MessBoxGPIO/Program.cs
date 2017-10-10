using System;
using System.Collections.Generic;
using System.Threading;
using Nanite.IO;
using Nanite.IO.Devices;
using Nanite.Exceptions;


namespace MessBoxGPIO
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Initialisation

            int startSensor = 3;
            int stopSensor = 5;
            int sensor1 = 7;
            int sensor2 = 8;
            int sensor3 = 10;

            DateTime Date = DateTime.Now;
            TimeSpan timeSpan = 0;

            GPIO.PinMode(startSensor, GPIO.Direction.Input);
            GPIO.PinMode(stopSensor, GPIO.Direction.Input);

            while(1){
                if(startSensor = GPIO.Value.High){
                    
                }
            }
        }
    }
}
