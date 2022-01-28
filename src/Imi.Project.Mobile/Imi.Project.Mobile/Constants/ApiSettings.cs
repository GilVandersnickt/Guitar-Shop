using System;
using System.Net;
using System.Net.Sockets;

namespace Imi.Project.Mobile.Constants
{
    public class ApiSettings
    {
        public const string BaseUri = "http://192.168.0.109:5000/api/";
        public const string AdminUsername = "admin@guitarshop.com";
        public const string AdminPassword = "Test123?"; 
        public const string SuperAdminUsername = "superadmin@guitarshop.com";
        public const string SuperAdminPassword = "Test123?";
        public const string ImagePlaceHolder = "https://i.postimg.cc/1X9YcxyL/Placeholder.jpg";
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
