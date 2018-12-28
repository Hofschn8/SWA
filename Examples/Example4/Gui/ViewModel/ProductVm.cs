using GalaSoft.MvvmLight;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui.ViewModel
{
    public class ProductVm : ViewModelBase
    {
        private Product product;


        public string Name
        {
            get
            {
                return product.Name;
            }
            set
            {
                product.Name = value;
                RaisePropertyChanged();
            }
        }

        public string ProductId
        {
            get
            {
                return product.ProductId;
            }
            set
            {
                product.ProductId = value;
                RaisePropertyChanged();
            }
        }

        public double Price
        {
            get
            {
                return product.Price;
            }
            set
            {
                product.Price = value;
                RaisePropertyChanged();
            }
        }

        public string Type
        {
            get
            {
                return product.Type;
            }
            set
            {
                product.Type = value;
                RaisePropertyChanged();
            }
        }

        public ProductVm(Product product)
        {
            this.product = product;
        }




    }
}
