using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class OrderItem
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal DispatchedQuantity { get; set; } = 0;

        public Order Order { get; set; } = null!;
        public Item Item { get; set; } = null!;
    }
}
