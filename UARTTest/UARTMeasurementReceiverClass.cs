using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace UARTTest
{
    class UARTMeasurementReceiverClass
    {
        int dataLen = 0;
        List<byte> fragmentedData = new List<byte>();
        int state = 0;
        public byte[] bData = null;

        public bool CollectData(byte[] data)
        {

            switch (state)
            {
                case 0:
                    // First time
                    fragmentedData.AddRange(data);
                    if (fragmentedData.Count > 2)
                    {
                        // We can extract data length
                        //dataLen = CustomConvertorClass.ConvertRawStringToInt(fragmentedData.Substring(0, 2)); // OLD WAY
                        dataLen = CustomConvertorClass.Decode2BytesToInt(data, 0);
                        // Check if we received all data at once
                        if (dataLen + 2 <= fragmentedData.Count)
                        {
                            // Everything arrived at once
                            state = 0; //DEBUG
                            //bData = ConvertStringToByte(fragmentedData); // OLD WAY
                            bData = fragmentedData.ToArray();
                            //Console.WriteLine("case 0 uart: Received " + bData.Length);
                            return true;
                        }

                        state = 2;
                    }
                    else
                    {
                        // We received just first char, we need one more to form dataLen
                        state = 1;
                    }
                    break;
                case 1:
                    fragmentedData.AddRange(data);
                    //dataLen = CustomConvertorClass.ConvertRawStringToInt(fragmentedData.Substring(0, 2)); // OLD WAY
                    dataLen = CustomConvertorClass.Decode2BytesToInt(fragmentedData.ToArray(), 0);
                    // Check if we received all data at once
                    if (dataLen + 2 <= fragmentedData.Count)
                    {
                        // Everything arrived at once
                        state = 0; //DEBUG
                        //bData = ConvertStringToByte(fragmentedData); // OLD WAY
                        bData = fragmentedData.ToArray();
                        //Console.WriteLine("case 1 uart: Received " + bData.Length);
                        foreach (var item in bData)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        return true;
                    }
                    state = 2;
                    break;
                case 2:
                    fragmentedData.AddRange(data);
                    if (dataLen + 2 <= fragmentedData.Count)
                    {
                        // Everything arrived at once
                        state = 0; //DEBUG
                        bData = fragmentedData.ToArray();
                        //Console.WriteLine("case 2 uart: Received " + bData.Length);
                        if (bData.Length > 200)
                        {
                            Console.WriteLine("");
                        }
                        return true;
                    }
                    break;
                default:
                    break;
            }
            return false;

            //if (totalDataReceived == 0)
            //{
            //    fragmentedData = data;
            //}
        }


        public void Reset()
        {
            dataLen = 0;
            fragmentedData = new List<byte>();
            state = 0;
            bData = null;
        }

        static byte[] ConvertStringToByte(string s)
        {
            List<byte> lb = new List<byte>();
            foreach (var item in s)
            {
                lb.Add((byte)item);
            }

            return lb.ToArray();
        }


    }
}
