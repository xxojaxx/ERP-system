using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class Address
    {
        public int AddressId { get; set; }
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;

        public ICollection<Client> Clients { get; set; } = new List<Client>();
        public ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
