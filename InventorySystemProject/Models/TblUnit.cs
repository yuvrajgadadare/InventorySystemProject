using System;
using System.Collections.Generic;

namespace InventorySystemProject.Models
{
    public partial class TblUnit
    {
        public TblUnit()
        {
            TblOrederProducts = new HashSet<TblOrederProduct>();
            TblReceiveOrderProducts = new HashSet<TblReceiveOrderProduct>();
        }

        public int UnitId { get; set; }
        public string? UnitName { get; set; }
        public int Flag { get; set; }

        public virtual ICollection<TblOrederProduct> TblOrederProducts { get; set; }
        public virtual ICollection<TblReceiveOrderProduct> TblReceiveOrderProducts { get; set; }
    }
}
