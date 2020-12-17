using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    class SalesViewModel : Screen
    {
        private BindingList<string> _products;
        private BindingList<string> _cart;
        private string _itemQuantity;

        public BindingList<string> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public BindingList<string> Cart
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        public string ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public bool CanAddToCart
        {
            get { return false; }
        }

        public void AddToCart()
        {

        }

        public bool CanCheckout
        {
            get { return false;  }
        }

        public void Checkout()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                return false;
            }
        }

        public void RemoveFromCart()
        {

        }



        public string SubTotal
        {
            get
            {
                return "$0.00";
            }
        }
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
