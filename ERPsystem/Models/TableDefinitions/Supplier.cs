using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }

        public Address Address { get; set; } = null!;
        public ICollection<Supply> Supplies { get; set; } = new List<Supply>();
    }
}
