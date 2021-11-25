using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlisleBrass
{
    class Basket
    {
        private List<RoadShoe> _roadshoes = null;
        private List<TrailShoe> _trailShoes = null;

        private int basket_cost = 0;
        private int free_items = 0;

        public Basket(List<RoadShoe> road, List<TrailShoe> trail)
        {
            _roadshoes = road;
            _trailShoes = trail;

            update_basket();
        }

        public void empty_basket()
        {
            _roadshoes.Clear();
            _trailShoes.Clear(); ;
            basket_cost = 0;
            free_items = 0;
        }

        public void add_road_shoes(RoadShoe r)
        {
            _roadshoes.Add(r);
            update_basket();
        }

        public void add_trail_shoes(TrailShoe t)
        {
            _trailShoes.Add(t);
            update_basket();
        }

        public void update_basket()
        {
            basket_cost = 0;
            foreach (RoadShoe r in _roadshoes)
            {
                basket_cost += r.get_cost();
            }

            foreach (TrailShoe t in _trailShoes)
            {
                basket_cost += t.get_cost();
            }

        }
        public void apply_promotion(int f_items)
        {
            free_items = f_items;
        }

        public Basket()
        {
            _roadshoes = new List<RoadShoe>();
            _trailShoes = new List<TrailShoe>();

        }

        public int get_num_roadshoes()
        {
            if(_roadshoes == null)
            {
                return 0;
            }

            return _roadshoes.Count;
        }

        public int get_num_trailshoes()
        {
            if (_trailShoes == null)
            {
                return 0;
            }

            return _trailShoes.Count;
        }

        public int get_basket_value()
        {
            return basket_cost;
        }

        public int get_free_items()
        {
            return free_items;
        }
    }
}
