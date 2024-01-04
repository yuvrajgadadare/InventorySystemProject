using System;
using System.Collections.Generic;

namespace InventorySystemProject.Models
{
    public partial class TblReceiveOrder
    {
        public TblReceiveOrder()
        {
            TblReceiveOrderProducts = new HashSet<TblReceiveOrderProduct>();
        }

        public int ReceiveOrderId { get; set; }
        public int? OrederId { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public int Flag { get; set; }

        public virtual TblOrder? Oreder { get; set; }
        public virtual ICollection<TblReceiveOrderProduct> TblReceiveOrderProducts { get; set; }
    }
}
