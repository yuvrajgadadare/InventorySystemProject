using System;
using System.Collections.Generic;

namespace InventorySystemProject.Models
{
    public partial class TblReceiveOrderProduct
    {
        public int ReceiveOrderProductId { get; set; }
        public int? ReceiveOrderId { get; set; }
        public int? ProductId { get; set; }
        public int? UnitId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Quanity { get; set; }
        public double PurchaseRate { get; set; }
        public int Flag { get; set; }

        public virtual TblProduct? Product { get; set; }
        public virtual TblReceiveOrder? ReceiveOrder { get; set; }
        public virtual TblUnit? Unit { get; set; }
    }
}
