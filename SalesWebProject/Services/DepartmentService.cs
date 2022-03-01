using SalesWebProject.Data;
using System.Linq;
using System.Collections.Generic;
using SalesWebProject.Models;

namespace SalesWebProject.Services
{
    public class DepartmentService
    {
        private readonly SalesWebProjectContext _context;

        public DepartmentService(SalesWebProjectContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
