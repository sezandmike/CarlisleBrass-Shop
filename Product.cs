using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlisleBrass
{
    public class Product
    {
        private int _cost;

        public Product(int cost)
        {
            _cost = cost;
        }

        public int get_cost()
        {
            return _cost;
        }

        public void set_cost(int c)
        {
            _cost = c;
        }
    }
}
