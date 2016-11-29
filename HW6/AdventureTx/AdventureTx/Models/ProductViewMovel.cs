using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
namespace AdventureTx.Models
{
    public class ProductViewMovel
    {
    
        public string photoString{ get; set; }
        public int productId{ get; set; }
        public ProductDescription productDescription { get; set; }
    }
}