using CBA;
using CBA.models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//SELECT USER SUB MENU

namespace CBA_MenuApp4273
{
    public class SelectUserSubMenu
    {
        public int ColPos2 { get; set; }
        public int RowPos2 { get; set; }
        public int SelectedItem2 { get; set; }

      



        public List<MenuItem> MenuItems2 { get; set; }//<> inside this we insert the data type we want to store


        //main menu
        public SelectUserSubMenu()
        {
            ColPos2 = 15;
            RowPos2 = 8;
            SelectedItem2 = 0;
            MenuItems2 = new List<MenuItem>
            {
                new MenuItem("Modify Student",true),
                new MenuItem("Add Modules",false),
                new MenuItem("Remove Modules",false),
                new MenuItem("Add Grade",false),
                new MenuItem("Delete Student",false),
                new MenuItem("Back",false)
            };
        }

       

        public void DisplaySUbMenu(Student get_user)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;

            Console.Clear();
            Console.CursorVisible = false;
            bool running2 = true;
            bool display2 = true;

            while (running2)//event loop to check our actions
            {
                Console.SetCursorPosition(ColPos2, RowPos2);

                for (int i = 0; i < MenuItems2.Count; i++)
                {
                    Console.SetCursorPosition(ColPos2, RowPos2 + i);
                    if (MenuItems2[i].IsSelected)
                    {

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if (display2 == true) Console.Write(MenuItems2[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Blue;
                        if (display2 == true) Console.Write(MenuItems2[i].Title);
                    }

                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems2[SelectedItem2].IsSelected = false;
                    SelectedItem2 = (SelectedItem2 + 1) % MenuItems2.Count;//this logic should be rechecked

                    MenuItems2[SelectedItem2].IsSelected = true;
                }
                if (key.Key == ConsoleKey.UpArrow)//menuitems is the array while mebuitem is the class
                {
                    MenuItems2[SelectedItem2].IsSelected = false;
                    SelectedItem2 = SelectedItem2 - 1;

                    if (SelectedItem2 < 0)
                    {
                        SelectedItem2 = MenuItems2.Count - 1;
                    }

                    MenuItems2[SelectedItem2].IsSelected = true;
                }
                if (key.Key == ConsoleKey.Enter)
                {

                    Console.SetCursorPosition(2, 0);
                    
                    
               
                    bool stop2 = false;
                    
                    while (!stop2)
                    {
                        
                        switch (MenuItems2[SelectedItem2].Title)
                        {
                            case "Modify Student":
                                Console.Clear();
                               
                                Console.CursorVisible= true;
                                
                                
                                Data_List1.Display_one_user(get_user);
                                Console.WriteLine("1.Change The First Name");
                                Console.WriteLine("2.Change The Last Name");
                                Console.WriteLine("3.Change The Date of Birth Name");
                                Console.WriteLine("4.Change The Address");
                                string m1=Console.ReadLine();
                               // int m1 = Convert.ToInt32(Console.ReadLine());
                                switch (m1)
                                {
                                    case "1":
                                        Console.WriteLine("Enter Your the First Name");
                                        get_user.FirstName = Console.ReadLine();
                                        Data_List1.Display_one_user(get_user);
                                        break;
                                    case "2":
                                        Console.WriteLine("Enter Your the Last Name");
                                        get_user.LastName = Console.ReadLine();
                                        Data_List1.Display_one_user(get_user);
                                        break;
                                    case "3":
                                        Console.WriteLine("Enter the Date of Birth Name");
                                        get_user.DateOfBirth = Console.ReadLine();
                                        Data_List1.Display_one_user(get_user);
                                        break;
                                    case "4":
                                        Console.WriteLine("Enter the Address");
                                        get_user.Address = Console.ReadLine();
                                        Data_List1.Display_one_user(get_user);
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Index I"!);
                                            break;
                                }
                                
                                
                                



                                Console.CursorVisible = false;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case "Add Modules":
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Data_List1.DisMod(get_user);
                                Console.WriteLine("You selected Add Modules");
                                Data_List1.Dis_modules();
                                Data_List1.Display_one_user(get_user);

                                Console.WriteLine($"\nEnter the modul id to Ad module to user {get_user.FirstName}");
                                int idmod = Convert.ToInt32(Console.ReadLine());
                                bool isadded = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if (mod.Id == idmod)
                                    {
                                        Console.WriteLine("Module is already Added");
                                        isadded = true;
                                        break;
                                    }


                                }
                                if (isadded == false) Data_List1.Generatemodule(get_user.ID, idmod);
                                
                                Data_List1.DisMod(get_user);
                            

                                
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case "Delete Student":
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("You Selected Delete Student");
                                Data_List1.Display_one_user(get_user);
                                Console.WriteLine("\nDo you want to delete this Student y/n");
                                string r1 = Console.ReadLine();
                                if ((r1 == "Y") || (r1 == "y"))
                                {
                                    Data_List1.DeleteUser(get_user);
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine($"Student {get_user.FirstName} is Removed Successfuly !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                            
                                running2 = false;
                                stop2 = true;
                                break;

                            case "Remove Modules":
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Data_List1.DisMod(get_user);
                                Console.WriteLine("You Selected Remove Modules");
                                Data_List1.Display_one_user(get_user);
                                Console.WriteLine($"\nEnter the modul id to delete module to user {get_user.FirstName}");
                                int idmod_r = Convert.ToInt32(Console.ReadLine());
                                bool isdeleted = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if (mod.Id == idmod_r)
                                    {
                                        get_user.Modules.Remove(mod);
                                        isdeleted = true;
                                        break;
                                    }


                                }
                                Console.Clear();

                                if (isdeleted == false) Console.WriteLine("module is already deleted or invalid module id");//DataList.Generatemodule(get_user.ID,idmod_r);
                                Data_List1.Display_one_user(get_user);
                                Data_List1.DisMod(get_user);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;

                                break;
                            case "Add Grade":
                                Console.Clear();
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Data_List1.DisMod(get_user);
                                Console.WriteLine("You Selected Remove Modules");
                                Data_List1.Display_one_user(get_user);
                                Console.WriteLine($"\nEnter the modul id to Add module grade  to Module {get_user.FirstName}");
                                int get_mod_id =Convert.ToInt32(Console.ReadLine());
                                bool is_mod_registered = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if(mod.Id == get_mod_id)
                                    {
                                        Console.WriteLine("Enter the Grade\n");
                                        Console.WriteLine("A.A\nB.B\nC.C\nE.E");
                                        string grade= Console.ReadLine().ToLower();
                                        is_mod_registered= true;
                                        switch(grade)
                                        {
                                            case "a":
                                                mod.Grade_point = 4;
                                                Console.WriteLine("Grade A added");
                                                break;
                                            case "b":
                                                mod.Grade_point = 3;
                                                Console.WriteLine("Grade B added");
                                                break;
                                            case "c":
                                                mod.Grade_point = 2.5;
                                                Console.WriteLine("Grade C added");
                                                break;
                                            case "E":
                                                mod.Grade_point = 0;
                                                Console.WriteLine("Grade E added");
                                                break;
                                            default: 
                                                Console.WriteLine("invalid Grade");
                                                break;
                                        }


                                        break;
                                    }
                                }if (is_mod_registered == false) { Console.WriteLine("Invalid Index !"); }
                                
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;

                                break;

                            case "Back":
                                Console.Clear(); 


                                running2 = false;
                                stop2 = true;
                               
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid ");
                                break;
                        }
                        if (stop2 != true)
                        {
                            Console.SetCursorPosition(2, 25);
                            Console.WriteLine("Press (B) to Back");
                           
                            string response = Console.ReadLine().ToLower();
                            Console.Clear();
                            if ((response == "B") || (response == "b"))
                            {
                                stop2 = true;

                            }
                            Console.SetCursorPosition(2, 0);
                        }
                        

                    }


                }
            }
        }

    };
}
