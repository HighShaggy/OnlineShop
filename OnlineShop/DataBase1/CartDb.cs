using OnlineShop.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineShop.Db
{
    public class CartDb
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        public int Quantity { get; set; }

        public int UserId { get; set; }
    }
}
