using System;
using System.Collections.Generic;

namespace InventorySystemProject.Models
{
    public partial class TblOrederProduct
    {
        public int OrderProductId { get; set; }
        public int? OrederId { get; set; }
        public int? ProductId { get; set; }
        public int? UnitId { get; set; }
        public int? Quantity { get; set; }
        public int Flag { get; set; }

        public virtual TblOrder? Oreder { get; set; }
        public virtual TblProduct? Product { get; set; }
        public virtual TblUnit? Unit { get; set; }
    }
}
