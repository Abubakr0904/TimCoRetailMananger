using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Models
{
    public class CartModel
    {
        public IList<CartItemModel> Products { get; set; } = new List<CartItemModel>();

        public decimal SubTotal => Products.Select(p => p.QuantityInCart * p.Product.RetailPrice).Sum();

        public void AddProduct(CartItemModel cartItemModel)
        {
            var product = Products.Where(p => p.Product.Id == cartItemModel.Product.Id).FirstOrDefault();

            if (product != null)
            {
                product.QuantityInCart += cartItemModel.QuantityInCart;
                return;
            }

            Products.Add(cartItemModel);
        }
    }
}
