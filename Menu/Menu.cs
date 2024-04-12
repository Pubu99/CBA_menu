using CBA;
using CBA.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace CBA_MenuApp4273
{
    public class Menu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public int SelectedItem{get; set;}

        //DataList datalist =new DataList();

        SelectUserSubMenu submenu = new SelectUserSubMenu();
        


        public List<MenuItem> MenuItems { get; set; }//<> inside this we insert the data type we want to store
       

        //main menu
        public Menu()
        {
            ColPos = 20;
            RowPos = 10;
            SelectedItem = 0;
            MenuItems = new List<MenuItem>
            {
                new MenuItem("Add Student",true),
                new MenuItem("Select Student",false),
                new MenuItem("Delete Student",false),
                new MenuItem("Display All Users",false),
                new MenuItem("Quit",false)
            };
        }
     
      


        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.Clear();
            bool running = true;
            bool display=true;

            while (running)//event loop to check our actions
            {
                Console.SetCursorPosition(ColPos, RowPos);

                for(int i = 0; i<MenuItems.Count; i++)
                {
                    Console.SetCursorPosition(ColPos, RowPos + i);
                    if (MenuItems[i].IsSelected)
                    {

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if(display==true) Console.Write(MenuItems[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        if (display == true) Console.Write(MenuItems[i].Title);
                    }
                    
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow) 
                { 
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem+1)%MenuItems.Count;//this logic should be rechecked
                    
                    MenuItems[SelectedItem].IsSelected = true;
                }
                if(key.Key == ConsoleKey.UpArrow)// here, menuitems is the array while mebuitem is the class
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = SelectedItem - 1;

                    if(SelectedItem < 0)
                    {
                        SelectedItem = MenuItems.Count - 1;
                    }

                    MenuItems[SelectedItem].IsSelected = true;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    
                    Console.SetCursorPosition(2, 0);
                

              
                    bool stop = false;
                   
                    while (!stop)
                    {
                       



                        switch (MenuItems[SelectedItem].Title)
                        {
                            case "Add Student":
                                Console.Clear();
                                Data_List1.print_short();
                                Console.WriteLine("You selected Add Student.");
                                Data_List1.Adduser();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(5, 25);
                                Console.WriteLine("Press any key to Add another user");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);

                                break;
                            case "Select Student":
                                
                                Console.Clear();
                                
                                Data_List1.print_short();
                                
                                Console.WriteLine("You selected Select Student");
                                
                                Console.WriteLine("Enter the Student Id");

                                int user_id=Convert.ToInt32(Console.ReadLine());
                                bool is_user_valid_s = false;
                                foreach(var user in Data_List1.users)
                                {
                                    if(user.ID == user_id)
                                    {
                                        is_user_valid_s=true;
                                        
                                        submenu.DisplaySUbMenu(user);
                                        break;
                                    }
                                }
                                if(is_user_valid_s==false) { Console.WriteLine("invalid user ID"); }


                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(5, 25);
                                Console.WriteLine("Press any key to select user again");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);

                                break;

                            case "Delete Student":
                                Console.Clear();
                                Data_List1.print_short();
                                Console.WriteLine("You Selected Delete Student");
                                Console.WriteLine("Enter the user Id ");
                                int d_id=Convert.ToInt32(Console.ReadLine());
                                bool is_user_valid_d=false;
                                foreach (var user in Data_List1.users)
                                {
                                    if (user.ID == d_id)
                                    {
                                        Data_List1.Display_one_user(user);
                                        Console.WriteLine("\nDo you want to delete this Student y/n");
                                        string r1 = Console.ReadLine();
                                        if ((r1 == "Y") || (r1 == "y"))
                                        {
                                            Data_List1.DeleteUser(user);
                                            is_user_valid_d=true;
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine($"Student {user.ID} is Removed Successfuly !");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }

                                        break;
                                    }
                                }
                                if (is_user_valid_d == false) { Console.WriteLine("invalid user ID or Student was already Deleted \a"); }



                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(5, 25);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);
                                break;

                            case "Display All Users":
                                Console.Clear();
                                Console.WriteLine("You Selected Display All Users");
                                Data_List1.print();

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(5, 25);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);


                                break;

                            case "Quit":
                                Console.Clear();
                                Console.SetCursorPosition(50, 15);
                              
                                Console.WriteLine("You Selected Quit" +
                                    "  Exiting.....\a");
                                running = false;
                                stop = true;
                               
                                break; 
                               
                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid ");
                                break;
                        }
                        if (stop!= true) {
                            Console.SetCursorPosition(5, 26);

                            Console.WriteLine("Press (B) to Back Main Menu");
                            string response = Console.ReadLine().ToLower();
                            Console.Clear();
                            if ((response == "B")||(response=="b"))
                            {
                                stop = true;
                            }
                            Console.SetCursorPosition(2, 0);
                        }
                        
                    }


                }
            }
        }

    };
}
