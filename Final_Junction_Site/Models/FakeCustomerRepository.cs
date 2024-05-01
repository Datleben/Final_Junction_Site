using System;
using System.Collections.Generic;

namespace Final_Junction_Site.Models
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public IEnumerable<Customer> Customers => new List<Customer> {
            new Customer{ CustomerId = 0, CustomerName = "Zoe"},
            new Customer{ CustomerId = 1, CustomerName = "Alice"},
            new Customer{ CustomerId = 2, CustomerName = "Bob"},
            new Customer{ CustomerId = 3, CustomerName = "Cody"},
            new Customer{ CustomerId = 4, CustomerName = "Dave"},
            new Customer{ CustomerId = 5, CustomerName = "Elisabeth"}
        };
    }
}