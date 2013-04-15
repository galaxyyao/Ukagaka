using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace Common
{
    public static class ExtPing
    {
        /// <summary>
        /// enum to hold the possible connection states
        /// </summary>
        [Flags]
        enum ConnectionStatusEnum : int
        {
            INTERNET_CONNECTION_MODEM = 0x1,
            INTERNET_CONNECTION_LAN = 0x2,
            INTERNET_CONNECTION_PROXY = 0x4,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }

        [DllImport("wininet", CharSet = CharSet.Auto)]
        static extern bool InternetGetConnectedState(ref ConnectionStatusEnum flags, int dw);

        /// <summary>
        /// method to check the status of the pinging machines internet connection
        /// </summary>
        /// <returns></returns>
        private static bool HasConnection()
        {
            //instance of our ConnectionStatusEnum
            ConnectionStatusEnum state = 0;

            //call the API
            InternetGetConnectedState(ref state, 0);

            //check the status, if not offline and the returned state
            //isnt 0 then we have a connection
            if (((int)ConnectionStatusEnum.INTERNET_CONNECTION_OFFLINE & (int)state) != 0)
            {
                //return true, we have a connection
                return false;
            }
            //return false, no connection available
            return true;
        }

        /// <summary>
        /// method for retrieving the IP address from the host provided
        /// </summary>
        /// <param name="host">the host we need the address for</param>
        /// <returns></returns>
        private static IPAddress GetIpFromHost(ref string host)
        {
            //variable to hold our error message (if something fails)
            string errMessage = string.Empty;

            //IPAddress instance for holding the returned host
            IPAddress address = null;

            //wrap the attempt in a try..catch to capture
            //any exceptions that may occur
            try
            {
                //get the host IP from the name provided
                address = Dns.GetHostEntry(host).AddressList[0];
            }
            catch (SocketException ex)
            {
                //some DNS error happened, return the message
                errMessage = string.Format("DNS Error: {0}", ex.Message);
            }
            return address;
        }

        /// <summary>
        /// method to check the ping status of a provided host
        /// </summary>
        /// <param name="addr">the host we need to ping</param>
        /// <returns></returns>
        public static string PingHost(string host)
        {
            //string to hold our return messge
            string returnMessage = string.Empty;

            //IPAddress instance for holding the returned host
            IPAddress address = GetIpFromHost(ref host);

            //set the ping options, TTL 128
            PingOptions pingOptions = new PingOptions(128, true);

            //create a new ping instance
            Ping ping = new Ping();

            //32 byte buffer (create empty)
            byte[] buffer = new byte[32];

            //first make sure we actually have an internet connection
            if (HasConnection())
            {
                //here we will ping the host 4 times (standard)
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        //send the ping 4 times to the host and record the returned data.
                        //The Send() method expects 4 items:
                        //1) The IPAddress we are pinging
                        //2) The timeout value
                        //3) A buffer (our byte array)
                        //4) PingOptions
                        PingReply pingReply = ping.Send(address, 1000, buffer, pingOptions);

                        //make sure we dont have a null reply
                        if (!(pingReply == null))
                        {
                            switch (pingReply.Status)
                            {
                                case IPStatus.Success:
                                    returnMessage = string.Format("Reply from {0}: bytes={1} time={2}ms TTL={3}", pingReply.Address, pingReply.Buffer.Length, pingReply.RoundtripTime, pingReply.Options.Ttl);
                                    break;
                                case IPStatus.TimedOut:
                                    returnMessage = "Connection has timed out...";
                                    break;
                                default:
                                    returnMessage = string.Format("Ping failed: {0}", pingReply.Status.ToString());
                                    break;
                            }
                        }
                        else
                            returnMessage = "Connection failed for an unknown reason...";
                    }
                    catch (PingException ex)
                    {
                        returnMessage = string.Format("Connection Error: {0}", ex.Message);
                    }
                    catch (SocketException ex)
                    {
                        returnMessage = string.Format("Connection Error: {0}", ex.Message);
                    }
                }
            }
            else
                returnMessage = "No Internet connection found...";

            //return the message
            return returnMessage;
        }

        /// <summary>
        /// method to check the ping status of a provided host
        /// </summary>
        /// <param name="addr">the host we need to ping</param>
        /// <returns></returns>
        public static bool GetPingHostResult(string host)
        {
            //string to hold our return messge
            string returnMessage = string.Empty;

            //IPAddress instance for holding the returned host
            IPAddress address = GetIpFromHost(ref host);
            if (address == null)
                return false;

            //set the ping options, TTL 128
            PingOptions pingOptions = new PingOptions(128, true);

            //create a new ping instance
            Ping ping = new Ping();

            //32 byte buffer (create empty)
            byte[] buffer = new byte[32];

            //first make sure we actually have an internet connection
            if (HasConnection())
            {
                //here we will ping the host 4 times (standard)
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        //send the ping 4 times to the host and record the returned data.
                        //The Send() method expects 4 items:
                        //1) The IPAddress we are pinging
                        //2) The timeout value
                        //3) A buffer (our byte array)
                        //4) PingOptions
                        PingReply pingReply = ping.Send(address, 1000, buffer, pingOptions);

                        //make sure we dont have a null reply
                        if (!(pingReply == null))
                        {
                            switch (pingReply.Status)
                            {
                                case IPStatus.Success:
                                    returnMessage = string.Format("Reply from {0}: bytes={1} time={2}ms TTL={3}", pingReply.Address, pingReply.Buffer.Length, pingReply.RoundtripTime, pingReply.Options.Ttl);
                                    return true;
                                    break;
                                case IPStatus.TimedOut:
                                    returnMessage = "Connection has timed out...";
                                    break;
                                default:
                                    returnMessage = string.Format("Ping failed: {0}", pingReply.Status.ToString());
                                    break;
                            }
                        }
                        else
                            returnMessage = "Connection failed for an unknown reason...";
                    }
                    catch (PingException ex)
                    {
                        returnMessage = string.Format("Connection Error: {0}", ex.Message);
                    }
                    catch (SocketException ex)
                    {
                        returnMessage = string.Format("Connection Error: {0}", ex.Message);
                    }
                }
            }
            else
                returnMessage = "No Internet connection found...";

            //return the message
            return false;
        }
    }
}
