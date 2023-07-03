using System;
namespace VacanteAPP.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader { get; set; }
        //public decimal OrderTotal { get; set; }
        public ShoppingCartVM()
        {
        }
    }
}

