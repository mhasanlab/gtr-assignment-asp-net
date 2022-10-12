using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTRBDAssignmentAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //Nev
        public virtual ICollection<Product> Products { get; set; }
    }
}
