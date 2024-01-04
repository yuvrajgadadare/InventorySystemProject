using System;
using System.Collections.Generic;

namespace InventorySystemProject.Models
{
    public partial class TblVendor
    {
        public TblVendor()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public int VendorId { get; set; }
        public string VendorName { get; set; } = null!;
        public int? SubCategoryId { get; set; }
        public double? ContactNumber { get; set; }
        public string? ContactPerson { get; set; }
        public int Flag { get; set; }

        public virtual TblSubCategory? SubCategory { get; set; }
        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
