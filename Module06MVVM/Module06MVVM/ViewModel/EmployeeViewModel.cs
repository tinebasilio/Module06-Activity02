using Module06MVVM.Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Module06MVVM.ViewModel
{
    public class EmployeeViewModel //File Name
    {
        /*      
        public EmployeeModel EmployeeModelSet { get; set; } //Abstract Absract Name (Contains EmployeeModel Set)
        
        public EmployeeViewModel()
        {
            EmployeeModelSet = new EmployeeModel //Object and Contents
            {
                Id = 1,
                Name = "Juan Dela Cruz",
                Email = "juandelacruz@auf.edu.ph",
                Address = "Angeles City"
            };
        }
        */

        private Services.DatabaseContext getContext() { 
            return new Services.DatabaseContext();
        }

        public int InsertEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employees.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public async Task<List<EmployeeModel>>GetAllEmployees()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Employees.ToListAsync();
            return res;
        }

        // EVENT THAT HANDLES UPDATE RECORDS
        public async Task<int> UpdateEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employees.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int DeleteEmployee(EmployeeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Employees.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}
