﻿using SalesWebProject.Data;
using SalesWebProject.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebProject.Services.Exceptions;

namespace SalesWebProject.Services
{
    public class SellerService
    {
        private readonly SalesWebProjectContext _context;

        public SellerService(SalesWebProjectContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        public void Insert(Seller obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id); // eaeger load (carrgar outros obj associados)
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x=> x.Id == obj.Id))
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException db)
            {
                throw new DbConcurrencyException(db.Message);
            }
            
            
            
        }


    }
}
