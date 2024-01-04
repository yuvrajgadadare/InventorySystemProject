using System;
using System.Collections.Generic;

namespace InventorySystemProject.Models
{
    public partial class TblOrder
    {
        public TblOrder()
        {
            TblOrederProducts = new HashSet<TblOrederProduct>();
            TblReceiveOrders = new HashSet<TblReceiveOrder>();
        }

        public int OrederId { get; set; }
        public string OrderDate { get; set; } = null!;
        public int? VendorId { get; set; }
        public int Flag { get; set; }

        public virtual TblVendor? Vendor { get; set; }
        public virtual ICollection<TblOrederProduct> TblOrederProducts { get; set; }
        public virtual ICollection<TblReceiveOrder> TblReceiveOrders { get; set; }
    }
}
