using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Telnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TentacleSoftware.Telnet;

namespace BusinessLogicLayer.Concreate
{
    public class KeeneticModemManager : IModemService
    {
        public TelnetClient telnetClient;
        public void Reboot()
        {
            TelnetManager telnetManager = new TelnetManager();
            telnetClient = telnetManager.Login("192.168.1.1", 23);
            telnetClient.Connect();
            System.Threading.Thread.Sleep(3000);
            telnetClient.Send("admin");
            System.Threading.Thread.Sleep(3000);
            telnetClient.Send("14861486");
            System.Threading.Thread.Sleep(3000);
            telnetClient.Send("system reboot");
            System.Threading.Thread.Sleep(6000);
        }
    }
}
