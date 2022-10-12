using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTRBDAssignmentAPI.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        //Nev
        public virtual ICollection<Product> Products { get; set; }

    }
}
