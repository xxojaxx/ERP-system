using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class BomItem
    {
        public int BomId { get; set; }
        public int ItemId { get; set; }
        public decimal Quantity { get; set; }

        public Bom Bom { get; set; } = null!;
        public Item Item { get; set; } = null!;
    }
}
