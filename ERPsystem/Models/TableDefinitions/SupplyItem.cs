using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class SupplyItem
    {
        public int SupplyId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal ReceivedQuantity { get; set; } = 0;

        public Supply Supply { get; set; } = null!;
        public Item Item { get; set; } = null!;
    }
}
