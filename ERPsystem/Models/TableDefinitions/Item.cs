using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int UmId { get; set; }
        public int ItemType { get; set; }

        public Unit Unit { get; set; } = null!;
        public Type Type { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<SupplyItem> SupplyItems { get; set; } = new List<SupplyItem>();
        public ICollection<BomItem> BomItems { get; set; } = new List<BomItem>();
        public ICollection<Inventory> Inventory { get; set; } = new List<Inventory>();
    }
}
