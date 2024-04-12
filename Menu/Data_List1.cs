using CBA.models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CBA
{
    public static class Data_List1
    {
        public static List<Student> users = new List<Student>();
         public static int studentID = 1006;


        //adding users to list
        public static void Adduser()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"New Student ID: {studentID} ");

            Console.CursorVisible = true;
            Console.Write("Enter Your First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Your Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Date of Birth DD/MM/YEAR: ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Enter Your Address: ");
            string address = Console.ReadLine();

            Student user = new Student(studentID, firstName, lastName, dateOfBirth, address);
            users.Add(user);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            studentID++;
        }

        
        //display modules
        public static void Dis_modules()
        {
            Console.WriteLine("Available Modules are");
            Console.WriteLine("--> 3305 Signal and Systems");
            Console.WriteLine("--> 3301 Analog Electronics");
            Console.WriteLine("--> 3203 Electronic Measurement");
            Console.WriteLine("--> 3302 Data Structures and Algorithems");
            Console.WriteLine("--> 3251 GUI Prgramming");
            Console.WriteLine("--> 3250 Programming  Project");
            Console.WriteLine("--> 3306 Digital Electronics");
            Console.WriteLine("--> 3307 Complex Analysis");
            Console.WriteLine("--> 3308 Basic Economics");
            Console.WriteLine(" ");


        }
       
        //to add moduler for user
        public static void Generatemodule(int uID,int modId)
        {
        
            foreach (var user in users)
            {
               
                if(user.ID == uID){ 
                   
                    switch (modId)
                    {
                        case 3305:
                            Module SAS = new Module(3305, "Signal and Systems", 3);
                            user.Modules.Add(SAS);
                            Console.WriteLine($"user {modId} is registed to {SAS.Name}");
                            break;
                        case 3301:
                            Module AE = new Module(3301, "Analog Electronics", 3);
                            Console.WriteLine($"user {modId} is registed to {AE.Name}");
                            user.Modules.Add(AE);
                            
                            break;
                        case 3302:
                            Module DaA = new Module(3302, "Data Structures and Algorithems", 3);
                            user.Modules.Add(DaA);
                            Console.WriteLine($"user {modId} is registed to {DaA.Name}");
                            break;
                        case 3203:
                            Module EM = new Module(3203, "Measurement", 2);
                            user.Modules.Add(EM);
                            Console.WriteLine($"user {modId} is registed to {EM.Name}");
                            break;
                        case 3251:
                            Module GUI = new Module(3251, "GUI Prgramming", 2);
                            user.Modules.Add(GUI);
                            Console.WriteLine($"user {modId} is registed to {GUI.Name}");
                            break;
                        case 3250:
                            Module PP = new Module(3250, "Programming  Project", 3);
                            user.Modules.Add(PP);
                            Console.WriteLine($"user {modId} is registed to {PP.Name}");
                            break;
                        case 3306:
                            Module DE = new Module(3306, "Digital Electronics", 3);
                            user.Modules.Add(DE);
                            Console.WriteLine($"user {modId} is registed to {DE.Name}");
                            break;
                        case 3307:
                            Module CA = new Module(3307, "Complex Analysis", 3);
                            user.Modules.Add(CA);
                            Console.WriteLine($"user {modId} is registed to {CA.Name}");
                            break;
                        case 3308:
                            Module BE = new Module(3308, "Basic Economics", 3);
                            user.Modules.Add(BE);
                            Console.WriteLine($"user {modId} is registed to {BE.Name}");
                            break;


                        default:
                            Console.WriteLine("Invalid Module Id");

                            break;


                    }
                    break;
                }
            }
            
        }

        //display all module in user
        public static void DisMod(Student user_mod)
        {
            Console.SetCursorPosition(80, 0);
            int i = 1;
           
            Console.WriteLine("| ..:: Registed Modules of the Student ::..");
            foreach (var mod in user_mod.Modules)
            {
                Console.SetCursorPosition(80, i);
                Console.WriteLine($"| * {mod.Id} {mod.Name}");
                i=i+1;
            }
            Console.SetCursorPosition(2, 0);
           

        }

        public static void print()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(55, 0);
            int i = 1;
            Console.WriteLine("ID\tFirst Name\t\tLast Name\tDOB\t\tAddress                GPA");
            foreach (var user in users)
            {
                Console.SetCursorPosition(55, i);
                i = i + 1;
                Console.WriteLine($"{user.ID}\t{user.FirstName,-15}\t{user.LastName,-15}\t{user.DateOfBirth,-15}\t{user.Address,-50}       {user.Cal_Gpa(user),-5}");
            }
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void print_short()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(75, 0);
            int i = 1;
            Console.WriteLine("ID\t\tFirst Name\t\tLast Name");
            foreach (var user in users)
            {
                Console.SetCursorPosition(75, i);
                i = i + 1;
                Console.WriteLine($"{user.ID}\t\t{user.FirstName,-15}\t\t{user.LastName,-15}");
            }
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //delete user
        public static void DeleteUser(Student user_del)
        {
            users.Remove(user_del);
           
        }
        
        //display only one user

        public static void Display_one_user(Student u)
        {
           
            Console.WriteLine("ID\tFirst Name\tLast Name\tDOB\t\tAddress");
            Console.WriteLine($"{u.ID}\t{u.FirstName}\t\t{u.LastName}\t\t{u.DateOfBirth}\t\t{u.Address}");

        }

    }
}
