using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlisleBrass
{
    class Shoe : Product
    {
        private int _stack_height;
        private string _model_name;
        private string _cushioning;
        private bool waterproof;

        public Shoe(int cost) : base(cost)
        {

        }
    }
}
