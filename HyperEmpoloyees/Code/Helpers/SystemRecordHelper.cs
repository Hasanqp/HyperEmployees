using HyperEmpoloyees.Code.Models;
using HyperEmpoloyees.Core;
using HyperEmpoloyees.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HyperEmpoloyees.Code.Helpers
{
    public static class SystemRecordHelper
    {
        public static void Add(string title, string description)
        {
            IDataHelper<SystemRecord> dataHelper = new SystemRecordRepository();
            SystemRecord systemRecords = new SystemRecord
            {
                CreatedDate = DateTime.Now,
                Description = description,
                Title = title,
                DeviceName = Environment.UserName,
                UserFullName = LocalUser.FullName,
                UsersId = LocalUser.Id,
                MachineId = GetMacnineId()
            };
            dataHelper.Add(systemRecords);
        }

        private static string GetMacnineId()
        {
            var networkinterfaces=NetworkInterface.GetAllNetworkInterfaces();
            string machineid = string.Empty;
            foreach (var networkinterface in networkinterfaces) 
            {
                if(networkinterface.OperationalStatus== OperationalStatus.Up &&
                    networkinterface.NetworkInterfaceType!=NetworkInterfaceType.Tunnel &&
                    networkinterface.NetworkInterfaceType!= NetworkInterfaceType.Loopback)
                {
                    machineid=networkinterface.GetPhysicalAddress().ToString();
                }
            }

            if(machineid == string.Empty)
            {
                machineid = "Null";
            }
            return machineid;
        }
    }
}
