using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;

namespace ERPsystem.Models.TableDefinitions
{
    class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }

        public Address Address { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
