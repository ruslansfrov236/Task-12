using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12.Customer.BaseEntity
{
    public class Human
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string Surname { get; set; }

        public byte Age { get; set; }   
    }
}
