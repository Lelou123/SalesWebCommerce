using SalesWebProject.Models.Enums;
using System;

namespace SalesWebProject.Models
{
    public class SalesRecord
    {
        public string ID { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord() { }

        public SalesRecord(string iD, double amount, DateTime date, SaleStatus status, Seller seller)
        {
            ID = iD;
            Amount = amount;
            Date = date;
            Status = status;
            Seller = seller;
        }
    }
}
