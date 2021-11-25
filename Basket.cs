using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlisleBrass
{
    class Basket
    {
        private List<RoadShoe> RoadShoes = null;
        private List<TrailShoe> TrailShoes = null;

        private int basket_cost = 0;
        private int free_items = 0;

        public Basket(List<RoadShoe> road, List<TrailShoe> trail)
        {
            RoadShoes = road;
            TrailShoes = trail;

            update_basket();
        }

        public void empty_basket()
        {
            RoadShoes.Clear();
            TrailShoes.Clear(); ;
            basket_cost = 0;
            free_items = 0;
        }

        public void add_road_shoes(RoadShoe r)
        {
            RoadShoes.Add(r);
            update_basket();
        }

        public void add_trail_shoes(TrailShoe t)
        {
            TrailShoes.Add(t);
            update_basket();
        }

        public void update_basket()
        {
            basket_cost = 0;
            foreach (RoadShoe r in RoadShoes)
            {
                basket_cost += r.get_cost();
            }

            foreach (TrailShoe t in TrailShoes)
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
            RoadShoes = new List<RoadShoe>();
            TrailShoes = new List<TrailShoe>();

        }

        public int get_num_roadshoes()
        {
            if(RoadShoes == null)
            {
                return 0;
            }

            return RoadShoes.Count;
        }

        public int get_num_trailshoes()
        {
            if (TrailShoes == null)
            {
                return 0;
            }

            return TrailShoes.Count;
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
