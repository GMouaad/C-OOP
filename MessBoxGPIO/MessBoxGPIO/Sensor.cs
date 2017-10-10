using System;
using Nanite.IO;

namespace MessBoxGPIO
{
    public class Sensor
    {
        private int SensorPin;
        private string SensorValue;
        private DateTime date;
        private TimeSpan timeDiff;

        public Sensor(int Sensorpin)
        {
            this.SensorPin = Sensorpin;
            GPIO.PinMode(Sensorpin, GPIO.Direction.Input);
        }
        public GPIO.Value getSensorValue(){
            
        }
        public int getSensorPin() { return SensorPin; }
        public DateTime getDate() { return date; }
        public int getTimeDiff(Sensor S) {
            timeDiff = S.date - this.date;
            return (int)timeDiff.TotalMilliseconds; 
        }
    }
}
