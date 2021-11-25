using System;
using System.Collections.Generic;

namespace CarlisleBrass
{
    class Program
    {
        
        static void Main(string[] args)
        {

            int selected_option = 0;    

            List<string> main_items = new List<string> { "1) Shop Tester", "2) Shop Admin", "3) Shopper,"}; //This would normally be a structured list within a JSON, XML, CSV, Config file or similar.
            List<string> admin_items = new List<string> { "1) Change Promotion"};
            List<string> tester_items = new List<string> { "1) Generate Random Basket (Applies Promotion)"};
            List<string> shopper_items = new List<string> { "1) Empty Basket", "2) Add Road Shoes", "3) Add Trail Shoes", "4) Show Basket", "5) Checkout (Applies Promotion)"};


            ScreenDisplay _display = new ScreenDisplay(main_items, admin_items, tester_items, shopper_items);
            Shop _shop = new Shop(new Promotion(1, 256), new Basket());                   //Default Shop Promotion of 1 item, £256
            Control _control = new Control();

            _display.main_header();
            _display.menu(selected_option);
            _display.main_footer();

            while (selected_option != ((int)App.EXIT))
            {
                selected_option = _display.get_selection();

                _display.main_header();

                selected_option = _control.process_selection(_display, _shop) ;
                
                _display.menu(selected_option);
                _display.main_footer();

            }            
            
        }
    }    
}
