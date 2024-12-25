using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TentacleSoftware.Telnet;

namespace BusinessLogicLayer.Telnet
{
    public class TelnetManager
    {
        public TelnetClient Login(string ip, int port)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            var telnetClient = new TelnetClient(ip, port, TimeSpan.FromSeconds(3), cancellationTokenSource.Token);
            return telnetClient;
        }
        public void Logout(TelnetClient telnetClient)
        {
            telnetClient.Disconnect();
            telnetClient.Dispose();
        }
    }
}
