/*
 * Copyright (c) 2016 Akinwale Ariwodola <akinwale@gmail.com>
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy,
 * modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
 * WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
using System;
using System.Runtime.InteropServices;
using Nanite.Exceptions;

namespace Nanite.IO
{
    /// <summary>
    /// 
    /// </summary>
    public class I2CExtendedIO : IDisposable
    {
        public enum Commands
        {
            DigitalWrite = 1,
            DigitalRead = 2,
            AnalogWrite = 3
        }

        private const string DefaultI2CFilename = "/dev/i2c-1";

        private Object lockObject = new Object();

        private int fileDescriptor;

        private string i2cFilename;

        public I2CExtendedIO(string i2cFilename)
        {
            this.i2cFilename = i2cFilename;
        }

        public I2CExtendedIO()
            : this(DefaultI2CFilename)
        {

        }

        public void Open(int slaveAddress)
        {
            fileDescriptor = OpenI2C(i2cFilename, slaveAddress);
            if (fileDescriptor <= 0)
            {
                throw new ExtendedIOException(string.Format("Unable to open the I2C connection to slave address: {0}", slaveAddress));
            }
        }

        public void DigitalWrite(int pin, GPIO.Value value)
        {
            CheckFileDescriptor();

            // Build the command to send
            byte[] bytes = new byte[4];
            bytes[0] = (byte) bytes.Length;
            bytes[1] = (byte) Commands.DigitalWrite;
            bytes[2] = (byte) pin;
            bytes[3] = (byte) value;

            int numBytes = I2CSendBytes(fileDescriptor, bytes);
            if (numBytes != bytes.Length)
            {
                throw new ExtendedIOException(string.Format("Could not send {0} bytes over the I2C connection.", bytes.Length));
            }
        }

        /// <summary>
        /// Reads the pin value
        /// 
        /// Expected byte data always has a length of 3
        ///     bytesReceived[0] - the number of bytes
        ///     bytesReceived[1] - the pin number
        ///     bytesReceived[2] - the pin value
        /// </summary>
        /// <returns>GPIO.Value.High if the specified pin is HIGH, or GPIO.Value.Low if the specified pin is LOW.</returns>
        /// <param name="pin">Pin.</param>
        public GPIO.Value DigitalRead(int pin)
        {
            CheckFileDescriptor();

            // Build the command to send
            byte[] bytes = new byte[3];
            bytes[0] = (byte) bytes.Length;
            bytes[1] = (byte) Commands.DigitalRead;
            bytes[2] = (byte) pin;

            // The array to store received byte data
            byte[] bytesRecvd = new byte[MaxByteCount()];

            // Obtain lock for send/receive
            lock (lockObject)
            {
                // Send the DigitalRead command
                int numBytes = I2CSendBytes(fileDescriptor, bytes);
                if (numBytes != bytes.Length)
                {
                    throw new ExtendedIOException(string.Format("Could not send {0} bytes over the I2C connection.", bytes.Length));
                }

                // Read the response immediately after the command
                I2CReadBytes(fileDescriptor, bytesRecvd);
            }

            ValidateDigitalReadData(pin, bytesRecvd);

            return (GPIO.Value) bytesRecvd[2];
        }

        public void AnalogWrite(int pin, int value)
        {
            CheckFileDescriptor();

            // Build the command to send
            byte[] bytes = new byte[7];
            bytes[0] = (byte) bytes.Length;
            bytes[1] = (byte) Commands.AnalogWrite;
            bytes[2] = (byte) pin;
            bytes[3] = (byte) (value >> 24);
            bytes[4] = (byte) (value >> 16);
            bytes[5] = (byte) (value >> 8);
            bytes[6] = (byte) value;

            int numBytes = I2CSendBytes(fileDescriptor, bytes);
            if (numBytes != bytes.Length)
            {
                throw new ExtendedIOException(string.Format("Could not send {0} bytes over the I2C connection.", bytes.Length));
            }
        }

        private void ValidateDigitalReadData(int pin, byte[] bytesReceived)
        {
            if (bytesReceived[0] < 3)
            {
                throw new ExtendedIOException("Invalid response data received over the I2C connection.");
            }

            if (bytesReceived[1] != pin)
            {
                throw new ExtendedIOException(string.Format("Pin mismatch for the DigitalRead command. Expected {0} but got {1}.", pin, bytesReceived[1]));
            }

            if (!IsGPIOValueValid(bytesReceived[2]))
            {
                throw new ExtendedIOException("The returned pin value is not valid.");
            }
        }


        private static bool IsGPIOValueValid(int value)
        {
            return ( (value == (int) GPIO.Value.Low) || (value == (int) GPIO.Value.High) );
        }

        private void CheckFileDescriptor()
        {
            if (fileDescriptor <= 0)
            {
                throw new ExtendedIOException("I2C connection is not open.");
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~I2CExtendedIO()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Close the file descriptor if it's open
            if (fileDescriptor > 0)
            {
                CloseI2C(fileDescriptor);
                fileDescriptor = -1;
            }
        }

        [DllImport("libnanitei2c.so", EntryPoint="nanite_i2c_open")]
        internal static extern int OpenI2C(string filename, int slaveAddress);

        [DllImport("libnanitei2c.so", EntryPoint = "nanite_i2c_close")]
        internal static extern int CloseI2C(int fileDescriptor);

        [DllImport("libnanitei2c.so", EntryPoint = "nanite_i2c_send")]
        internal static extern int I2CSendBytes(int fileDescriptor, byte[] bytes);

        [DllImport("libnanitei2c.so", EntryPoint = "nanite_i2c_read")]
        internal static extern int I2CReadBytes(int fileDescriptor, byte[] bytesRead);

        [DllImport("libnanitei2c.so", EntryPoint = "nanite_i2c_max_bytes")]
        internal static extern int MaxByteCount();
    }
}