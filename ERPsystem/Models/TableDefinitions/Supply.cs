using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPsystem.Models.TableDefinitions
{
    class Supply
    {
        public int SupplyId { get; set; }
        public int SupplierId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = string.Empty;
        public string CurrencyId { get; set; } = string.Empty;

        public Supplier Supplier { get; set; } = null!;
        public Currency Currency { get; set; } = null!;
        public ICollection<SupplyItem> SupplyItems { get; set; } = new List<SupplyItem>();
    }
}
