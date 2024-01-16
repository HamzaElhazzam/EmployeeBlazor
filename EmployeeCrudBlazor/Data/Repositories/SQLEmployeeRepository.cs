using EmployeeCrudBlazor.Context;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudBlazor.Data.Repositories
{
    public class SQLEmployeeRepository
    {
        private AppDbContext Context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            Context = context;
        }
        //Get All Employees List
        public async Task<List <Employee>> GetAllEmployees()
        {
            return await Context.Employees.ToListAsync(); 
        }

        //Add Employee
        public async Task<bool> AddEmployee(Employee employee)
        {
            await Context.Employees.AddAsync(employee);
            await Context.SaveChangesAsync();
            return true;

        }
        //Get Employee By Id
        public async Task<Employee> GetEmployeeById(int id)
        {
           
            Employee employee = await Context.Employees.SingleOrDefaultAsync(x => x.Id == id);
            return employee;
        }

        //Update Emplyee Data
        public async Task<bool> UpdateEmployeeDetails(Employee employee)
        {
            Context.Employees.Update(employee);
            await Context.SaveChangesAsync();
            return true;
        }

        //Delete Emplyee Data
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            Context.Employees.Remove(employee);
            await Context.SaveChangesAsync();
            return true;
        }


    }
}
