using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.models
{
    public class Module
    {
       

        public int Id { get; set; }
        public string Name { get; set; }

        public string Grade { get; set; }
        public double Grade_point { get; set; }
        public double Credit_point { get; set; }
        public Module(int id, string name, double credit_point)
        {
            Id = id;
            Name = name;
            Credit_point = credit_point;
            Grade_point = 0;
        }
        
    }

}
