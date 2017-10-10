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

namespace Nanite.IO.Devices
{
    public static class PINE64
    {
        /// <summary>
        /// The physical pin to GPIO number mapping of usable pins on the Pi2 bus.
        /// </summary>
        public enum Pi
        {
            Pin3 = 227,
            Pin5 = 226,
            Pin8 = 32,
            Pin10 = 33,
            Pin11 = 71,
            Pin12 = 72,
            Pin13 = 233,
            Pin15 = 76,
            Pin16 = 77,
            Pin18 = 78,
            Pin19 = 64,
            Pin21 = 65,
            Pin22 = 79,
            Pin23 = 66,
            Pin24 = 67,
            Pin26 = 231,
            Pin27 = 361,
            Pin28 = 360,
            Pin29 = 229,
            Pin31 = 230,
            Pin32 = 68,
            Pin33 = 69,
            Pin35 = 73,
            Pin36 = 70,
            Pin37 = 80,
            Pin38 = 74,
            Pin40 = 75
        }

        /// <summary>
        /// The physical pin to GPIO number mapping of usable pins on the Euler bus.
        /// </summary>
        public enum Euler
        {
            Pin7 = 363,
            Pin10 = 232,
            Pin11 = 35,
            Pin12 = 36,
            Pin13 = 37,
            Pin15 = 38,
            Pin16 = 39,
            Pin18 = 100,
            Pin19 = 98,
            Pin21 = 99,
            Pin22 = 101,
            Pin23 = 97,
            Pin24 = 96,
            Pin26 = 102,
            Pin27 = 34,
            Pin28 = 103,
            Pin29 = 40,
            Pin30 = 41
        }

        /// <summary>
        /// The physical pin to GPIO number mapping of usable pins on the Exp bus.
        /// </summary>
        public enum Exp
        {
            Pin2 = 359,
            Pin7 = 40,
            Pin8 = 41
        }
    }
}
