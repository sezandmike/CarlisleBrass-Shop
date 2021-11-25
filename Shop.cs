using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlisleBrass
{
    class Shop
    {
        Promotion _promotion { get; set; }      //May have more than one Promotion in the real world, just one for this demo.
        Basket _basket = null;

        public Shop(Promotion p, Basket b)
        {
            _promotion = p;
            _basket = b;

        }

        public void set_basket(Basket b)
        {
            _basket = b;
        }

        public Basket get_basket()
        {
            return _basket;
        }

        public void update_promotion(int number_of_items, int value_of_items)
        {
            _promotion._number_of_products = number_of_items;
            _promotion._value_of_order = value_of_items;
        }

        public int get_promotion_number()
        {
            return _promotion._number_of_products;
            
        }

        public int get_promotion_value()
        {
            return _promotion._value_of_order;
        }

        public void checkout()
        {
            //Apply the Promotion
            if(_basket.get_basket_value() >= _promotion._value_of_order)
            {
                _basket.apply_promotion(_promotion._number_of_products);
            }
        }
    }
}
