using System;
using System.Collections.Generic;

namespace InventorySystemProject.Models
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblOrederProducts = new HashSet<TblOrederProduct>();
            TblReceiveOrderProducts = new HashSet<TblReceiveOrderProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int? SubCategoryId { get; set; }
        public double? Tax { get; set; }
        public int Flag { get; set; }

        public virtual TblSubCategory? SubCategory { get; set; }
        public virtual ICollection<TblOrederProduct> TblOrederProducts { get; set; }
        public virtual ICollection<TblReceiveOrderProduct> TblReceiveOrderProducts { get; set; }
    }
}
