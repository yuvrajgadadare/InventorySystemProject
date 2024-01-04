using System;
using System.Collections.Generic;

namespace InventorySystemProject.Models
{
    public partial class TblSubCategory
    {
        public TblSubCategory()
        {
            TblProducts = new HashSet<TblProduct>();
            TblVendors = new HashSet<TblVendor>();
        }

        public int SubCategoryId { get; set; }
        public string SubcategoryName { get; set; } = null!;
        public int? CategoryId { get; set; }
        public int Flag { get; set; }

        public virtual ICollection<TblProduct> TblProducts { get; set; }
        public virtual ICollection<TblVendor> TblVendors { get; set; }
    }
}
