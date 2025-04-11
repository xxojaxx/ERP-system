using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class Inventory
    {
        public int InventoryId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }

        public Item Item { get; set; } = null!;
    }
}
