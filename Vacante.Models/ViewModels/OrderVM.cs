using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VacanteAPP.Models.ViewModels
{
    public class OrderVM
    {
        public OrderHeader orderHeader { get; set; }
        public IEnumerable<OrderDetails> orderDetails { get; set; }
        public List<SelectListItem> OrderStatusList { get; set; }
    }
}

