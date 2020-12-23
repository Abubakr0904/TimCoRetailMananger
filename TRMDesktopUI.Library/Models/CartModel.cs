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

        public decimal SubTotal => Products.Sum(p => p.QuantityInCart * p.Product.RetailPrice);

        public decimal TaxAmount => Products.Where(p => p.Product.IsTaxable).Sum(p => p.Product.RetailPrice * TaxRate);

        public decimal Total => SubTotal + TaxAmount;

        public decimal TaxRate { get; set; }

        public void AddProduct(CartItemModel cartItemModel)
        {
            var product = Products.FirstOrDefault(p => p.Product.Id == cartItemModel.Product.Id);

            if (product != null)
            {
                product.QuantityInCart += cartItemModel.QuantityInCart;
                return;
            }

            Products.Add(cartItemModel);
        }
    }
}
