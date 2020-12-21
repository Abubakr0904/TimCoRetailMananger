using Caliburn.Micro;
using System.ComponentModel;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Api;
using TRMDesktopUI.Library.Models;
using System.Linq;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private readonly IProductEndpoint _productEndpoint;

        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

        private BindingList<ProductModel> _products;

        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public BindingList<CartItemModel> Cart => new BindingList<CartItemModel>(CartModelDto.Products);

        private CartModel _cart = new CartModel();

        public CartModel CartModelDto
        {
            get { return _cart; }
            set
            {
                _cart = value;

                NotifyOfPropertyChange(() => CartModelDto); 
                NotifyOfPropertyChange(() => Cart);
            }
        }

        private int _itemQuantity;

        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        private ProductModel _selectedProduct;

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set 
            { 
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        private ProductModel _selectedRemoveProduct;

        public ProductModel SelectedRemoveProduct
        {
            get { return _selectedRemoveProduct; }
            set 
            { 
                _selectedRemoveProduct = value;
                NotifyOfPropertyChange(() => CanRemoveFromCart);
            }
        }


        public bool CanAddToCart => ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity;

        public void AddToCart()
        {
            var item = new CartItemModel 
            { 
                Product = SelectedProduct,
                QuantityInCart = ItemQuantity
            };
            CartModelDto.AddProduct(item);

            NotifyOfPropertyChange(() => Subtotal);
            NotifyOfPropertyChange(() => Cart);
        }

        public bool CanCheckout
        {
            get { return false; }
        }

        public void Checkout()
        {

        }

        public bool CanRemoveFromCart => SelectedRemoveProduct != null;

        public void RemoveFromCart()
        {
        }

        public string Subtotal => CartModelDto.SubTotal.ToString("C");
        
        public string Tax
        {
            get
            {
                return "$0.00";
            }
        }

        public string Total
        {
            get
            {
                return "$0.00";
            }
        }
    }
}
