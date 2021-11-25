using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarlisleBrass
{
    public class ScreenDisplay
    {
        private List<string> _main_menu = null;
        private List<string> _admin_menu = null;
        private List<string> _tester_menu = null;
        private List<string> _shopper_menu = null;


        private int _min_selection;
        private int _max_selection;
        private int _exit_option = 9;       //Fixed for this...
        private int _back_option = 8;       //Fixed for this...
        private int _cur_selection = 0;

        private Menu _prev_menu = Menu.MAIN;      //Defaul to Main Menu
        private Menu _cur_menu = Menu.MAIN;      //Defaul to Main Menu

        internal int get_number(string prompt, uint min, uint max)     //uint for unsigned.
        {
            uint number = 0;

            while (number < min || number > max)           //Hard Limit for now.
            {
                Console.WriteLine(prompt + " (" + min.ToString() + " - " + max.ToString() + ")");
                number = Convert.ToUInt16(Console.ReadLine());
            }

            return (int)number;

        }

        public void show_promotion(int num, int val)
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Number of Items in Promotion\t" + num);
            Console.WriteLine("Minimum Spend for Promotion\t" + val);
            Console.WriteLine("******************************");

        }

        public void show_basket(int number_of_roadshoes, int number_of_trail_shoes, int basket_value, int free_items)
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Number of Road Shoes\t" + number_of_roadshoes);
            Console.WriteLine("Number of Trails Shoes\t" + number_of_trail_shoes);
            Console.WriteLine("Basket Value\t" + basket_value);
            Console.WriteLine("Promotion Items\t" + free_items);
            Console.WriteLine("******************************");

        }

        internal void show_text(string v)
        {
            Console.WriteLine(v);
        }

        internal void set_menu_option(int v)
        {
            _cur_selection = v;
        }

        /*  Constructor to receive the menu item list.  Idea here being that the list can be supplied as a CSV file, DB query, etc. 
         This file could be structured into main menu, sub menus, etc.
        Essentially, we could decouple the menu from the class to allow for easy maintenance, etc.
        */

        public ScreenDisplay(List<string> main_menu, List<string> admin_menu, List<string> tester_menu, List<string> shopper_menu)
        {
            _main_menu = main_menu;
            _admin_menu = admin_menu;
            _tester_menu = tester_menu;
            _shopper_menu = shopper_menu;
            

        }

        public int active_menu()
        {
            return ((int)_cur_menu);
        }

        public int cur_selection()
        {
            return ((int)_cur_selection);
        }

        public int menu(int selected_option)
        {
            /*Bit messy this, ideally there would be an entire Menu subsystem to handle this correctly....*/
            
            if(selected_option != ((int)_cur_menu))
            {
                if(selected_option == 8)
                {
                    selected_option = ((int)_prev_menu);
                }
                else
                {
                    _prev_menu = _cur_menu;
                }
            }

            _cur_selection = selected_option;

            switch (selected_option)
            {
                case 0:
                    main_menu();
                    _cur_menu = Menu.MAIN;
                    break;
                case 1:
                    tester_menu();
                    _cur_menu = Menu.TESTER;
                    break;
                case 2:
                    admin_menu();
                    _cur_menu = Menu.ADMIN;
                    break;
                case 3:
                    shopper_menu();
                    _cur_menu = Menu.SHOPPER;
                    break;
                default:
                    main_menu();
                    _cur_menu = Menu.MAIN;
                    break;

            }

            return _exit_option;           
        }

        public void main_header()
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("|               Carlisle Brass                  |");
            Console.WriteLine("=================================================");

        }

        public int get_selection()
        {
            int selected_option = 0;

            
            while ((selected_option < _min_selection || selected_option > _max_selection) && (selected_option != 9 && selected_option !=8)) 
            { 
                selected_option = Convert.ToInt16(Console.ReadLine());
                _cur_selection = selected_option;
            }

            return selected_option;
        }

        public void main_footer()
        {
            Console.WriteLine("=================================================");
            Console.Write("CB>\tEnter Selection (" + _back_option + " to Return to Previous Menu " + _exit_option.ToString() + " to Exit...)=>>>>");

        }

        private int main_menu()
        {
            foreach (string menu_option in _main_menu)
            {
                Console.WriteLine(menu_option);
            }
            _min_selection = 1;                                 //Ok, no error checking here, obviously in the real world there would be!
            _max_selection = _main_menu.Count;                     //Treat as chars, could be ints, etc

            return _max_selection;
        }

        private int admin_menu()
        {
            foreach (string menu_option in _admin_menu)
            {
                Console.WriteLine(menu_option);
            }
            _min_selection = 1;                                 //Ok, no error checking here, obviously in the real world there would be!
            _max_selection = _admin_menu.Count;                     //Treat as chars, could be ints, etc

            return _max_selection;
        }

        private int tester_menu()
        {
            foreach (string menu_option in _tester_menu)
            {
                Console.WriteLine(menu_option);
            }
            _min_selection = 1;                                 //Ok, no error checking here, obviously in the real world there would be!
            _max_selection = _tester_menu.Count;                     //Treat as chars, could be ints, etc

            return _max_selection;
        }

        private int shopper_menu()
        {
            foreach (string menu_option in _shopper_menu)
            {
                Console.WriteLine(menu_option);
            }
            _min_selection = 1;                                 //Ok, no error checking here, obviously in the real world there would be!
            _max_selection = _shopper_menu.Count;                     //Treat as chars, could be ints, etc

            return _max_selection;
        }


    }
}
