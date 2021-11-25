using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlisleBrass
{
    /*Class to essentially control the main processing of the demo*/

    class Control
    {
        private int active_menu;
        private int sub_menu;
        private int number_of_items;
        private int value_of_items;

        public int process_selection(ScreenDisplay display, Shop shop)
        {
            int next_selection = display.cur_selection();
            Random rnd = new Random();
            int road_shoes_number = rnd.Next(1,5);
            int trail_shoes_number = rnd.Next(1, 5);


            //Determine whether we need to instantiate anything within the Shop or redisplay a main menu
            active_menu = display.active_menu() ;
            sub_menu = display.cur_selection();

            if(active_menu == ((int)Menu.ADMIN))
            {
                if(sub_menu == 1)
                {

                    display.show_promotion(shop.get_promotion_number(), shop.get_promotion_value());
                    number_of_items = display.get_number("Enter Number of Items",1,10);
                    value_of_items = display.get_number("Enter Value of Items",10,1000);
                    shop.update_promotion(number_of_items, value_of_items);
                    display.show_promotion(shop.get_promotion_number(), shop.get_promotion_value());
                    next_selection = (8);
                }

            }
            else if (active_menu == ((int)Menu.TESTER))
            {
                if (sub_menu == 1)
                {
                    display.show_basket(shop.get_basket().get_num_roadshoes(), shop.get_basket().get_num_trailshoes(), shop.get_basket().get_basket_value(), shop.get_basket().get_free_items());
                    display.show_text("Generating Random Basket Contents...");
                    shop.get_basket().empty_basket();
                    for(int a=0;a<road_shoes_number;a++)
                    {
                        shop.get_basket().add_road_shoes(new RoadShoe(50));
                    }

                    for (int a = 0; a < trail_shoes_number; a++)
                    {
                        shop.get_basket().add_trail_shoes(new TrailShoe(40));
                    }
                    shop.checkout();
                    display.show_basket(shop.get_basket().get_num_roadshoes(), shop.get_basket().get_num_trailshoes(), shop.get_basket().get_basket_value(), shop.get_basket().get_free_items());

                    next_selection = (8);
                }

            }
            else if ((active_menu == ((int)Menu.SHOPPER)))
            {                

                if (sub_menu == 1)
                {
                    shop.get_basket().empty_basket();
                    display.show_basket(shop.get_basket().get_num_roadshoes(), shop.get_basket().get_num_trailshoes(), shop.get_basket().get_basket_value(), shop.get_basket().get_free_items());
                    next_selection = active_menu;
                }
                else if (sub_menu == 2)
                {
                    shop.get_basket().add_road_shoes(new RoadShoe(50));
                    shop.checkout();
                    display.show_basket(shop.get_basket().get_num_roadshoes(), shop.get_basket().get_num_trailshoes(), shop.get_basket().get_basket_value(), shop.get_basket().get_free_items());
                    next_selection = active_menu;
                }
                else if (sub_menu == 3)
                {
                    shop.get_basket().add_trail_shoes(new TrailShoe(40));
                    shop.checkout();
                    display.show_basket(shop.get_basket().get_num_roadshoes(), shop.get_basket().get_num_trailshoes(), shop.get_basket().get_basket_value(), shop.get_basket().get_free_items());
                    next_selection = active_menu;
                }
                else if (sub_menu == 4)
                {
                    display.show_basket(shop.get_basket().get_num_roadshoes(), shop.get_basket().get_num_trailshoes(), shop.get_basket().get_basket_value(), shop.get_basket().get_free_items());
                    next_selection = active_menu;
                }
                else if (sub_menu == 5)
                {
                    shop.checkout();
                    display.show_basket(shop.get_basket().get_num_roadshoes(), shop.get_basket().get_num_trailshoes(), shop.get_basket().get_basket_value(), shop.get_basket().get_free_items());
                    display.show_text("Checked Out, thankyou for your custom.");
                    next_selection = 8;
                }

            }

            return next_selection;



        }
    }
}
