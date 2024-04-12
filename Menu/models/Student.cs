using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;   
using System.Text;
using System.Threading.Tasks;

namespace CBA.models
{
    public  class Student
    {
       

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }

        public string Address { get; set; }
        public List<Module> Modules = new List<Module>();
        public Student(int iD, string firstName, string lastName, string dateOfBirth, string address)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;

        }public double Cal_Gpa(Student user)
        {
            double Point=0;
            double Sum_of_Credit=0.0000000001;//for ignore the 0/0
            
            foreach (var mode in user.Modules) {
                Point =Point +(mode.Grade_point) * (mode.Credit_point);
                Sum_of_Credit=Sum_of_Credit + mode.Credit_point;
            }
            double gpa=Point/Sum_of_Credit;

            return gpa;

        }
        
        
       
        
           
        

    }
}
