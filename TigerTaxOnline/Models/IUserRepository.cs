using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TigerTaxOnline.Classes;

namespace TigerTaxOnline.Models
{
    public interface IUserRepository
    {
        void CreateNewUser(string firstName, string lastName, string username, string email, string password);
        void UpdateUser(); //update password? other password things?
        //int SaveChanges();

        IEnumerable<Employee> GetEmployees();
        void CreateNewEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        void EditEmployee(Employee employee);
    }
}
