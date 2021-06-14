using System;
using System.Collections.Generic;

namespace NewLanguageFeatures
{
    public delegate bool KeyValueFilter<K, V>(K key, V value);
    public static class Extensions
    {
        public static List<K> FilterBy<K, V>(
    this Dictionary<K, V> items,
    KeyValueFilter<K, V> filter)
        {
            var result = new List<K>();

            foreach (KeyValuePair<K, V> element in items)
            {
                if (filter(element.Key, element.Value))
                    result.Add(element.Key);
            }
            return result;
        }

        public static bool Compare(Customer customer1, Customer customer2)
        {
            if (customer1.CustomerID == customer2.CustomerID &&
                customer1.Name == customer2.Name &&
                customer1.City == customer2.City)
            {
                return true;
            }

            return false;
        }

        public static List<T> Append<T>(this List<T> a, List<T> b)
        {
            var newList = new List<T>(a);
            newList.AddRange(b);
            return newList;
        }


    }

    public class Customer
    {
        public int CustomerID { get; private set; }
        public string Name { get; set; }
        public string City { get; set; }

        public Customer(int ID)
        {
            CustomerID = ID;
        }
        public override string ToString()
        {
            return Name + "\t" + City;
        }
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

        public static List<Customer> FindCustomersByCity(List<Customer> customers,string city)
        {
            //return customers.FindAll(
            //    delegate (Customer c)
            //    {
            //        return c.City == city;
            //    });

            return customers.FindAll(c => c.City == city);
        }


        static void Main(string[] args)
        {
            var customers = CreateCustomers();
            var customerDictionary = new Dictionary<Customer, string>();

            //save data in dictionary, key is Customer, value is Customer's lastName
            foreach (var c in customers)
                customerDictionary.Add(c, c.Name.Split(' ')[1]);

            var matches = customerDictionary.FilterBy(
                (customer, lastName) => lastName.StartsWith("A"));
            //The above line runs the query  
            Console.WriteLine("Number of Matches: {0}", matches.Count);



            foreach (var c in FindCustomersByCity(customers, "London"))
                Console.WriteLine(c);


            var addedCustomers = new List<Customer>
    {
        new Customer(9)  { Name = "Paolo Accorti", City = "Torino" },
        new Customer(10) { Name = "Diego Roel", City = "Madrid" }
    };

            var updatedCustomers = customers.Append(addedCustomers);


            var newCustomer = new Customer(10)
            {
                //Name = "Diego Roel",
                //City = "Madrid"
                Name = "Liz Nixon",
                City = "Portland"
            };

            foreach (var c in updatedCustomers)
            {
                if (Extensions.Compare(newCustomer, c))
                {
                    Console.WriteLine("The new customer was already in the list");
                    return;
                }
            }

            Console.WriteLine("The new customer was not in the list");


        }
    }
}
