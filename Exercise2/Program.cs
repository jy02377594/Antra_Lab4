using System;
using System.Collections.Generic;

namespace Exercise2
{
    public class Customer
    {
        public string CustomerID { get; private set; }
        public string Name { get; set; }
        public string City { get; set; }

        public Customer(int ID)
        {
            this.CustomerID = ID.ToString();
        }

        public override string ToString()
        {
            return Name + "\t" + City + "\t" + CustomerID;
        }
    }
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    class Program
    {
        static List<Customer> CreateCustomers()
        {
            return new List<Customer>
    {
        new Customer(1) { Name = "Maria Anders",     City = "Berlin"    },
        new Customer(2) { Name = "Laurence Lebihan", City = "Marseille" },
        new Customer(3) { Name = "Elizabeth Brown",  City = "London"    },
        new Customer(4) { Name = "Ann Devon",        City = "London"    },
        new Customer(5) { Name = "Paolo Accorti",    City = "Torino"    },
        new Customer(6) { Name = "Fran Wilson",      City = "Portland"  },
        new Customer(7) { Name = "Simon Crowther",   City = "London"    },
        new Customer(8) { Name = "Liz Nixon",        City = "Portland"  }
    };
        }

        static void Main(string[] args)
        {
            List<Customer> customers = CreateCustomers();
            foreach (Customer c in customers)
            {
                Console.WriteLine(c);
            }
            Console.ReadKey();
        }
    }
}