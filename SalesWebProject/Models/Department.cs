﻿using System.Collections.Generic;
using System;
using System.Linq;

namespace SalesWebProject.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();
        public Department() { }

        public Department(string name)
        {            
            Name = name;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public double TotalSalles(DateTime initial, DateTime final)
        {
            return Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
