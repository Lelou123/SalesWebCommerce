using SalesWebProject.Data;
using SalesWebProject.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebProject.Services.Exceptions;
using System.Threading.Tasks;
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

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }   
        public async Task InsertAsync(Seller obj)
        {
            
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id); // eaeger load (carrgar outros obj associados)
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e )
            {
                throw new IntegrityException(e.Message);
            }
            
        }

        public async Task UpdateAsync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(obj);
               await _context.SaveChangesAsync();
            }
            catch(DbConcurrencyException db)
            {
                throw new DbConcurrencyException(db.Message);
            }
            
            
            
        }


    }
}
