using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlisleBrass
{
    class Promotion
    {
        public  int _number_of_products { get; set; }
        public int _value_of_order { get; set; }

        public Promotion(int number, int value)
        {
            _number_of_products = number;
            _value_of_order = value;
        }
    }
}
