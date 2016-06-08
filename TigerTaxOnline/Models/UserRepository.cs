using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TigerTaxOnline.Classes;
using TigerTaxOnline.Models;
using System;
using System.Web;
using System.Data.Entity;

namespace TigerTaxOnline.Models
{
    public class UserRepository : IUserRepository
    {
        internal TigerTaxOnlineModel Dal = new TigerTaxOnlineModel();

        public void CreateNewUser(string firstName, string lastName, string username, string email, string password)
        {
            Guid userGuid = Guid.NewGuid();

            string hashedPassword = Security.HashSHA1(password + userGuid.ToString());

            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Email = email,
                UserPassword = hashedPassword,
                UserGuid = userGuid
            };

            //TODO: check if user/username already exists. Have unit test around this.

            Dal.Users.Add( user );
            Dal.SaveChanges();
        }

        public void UpdateUser()
        {
            
        }

        public IEnumerable<Employee> GetEmployees()
        {
            //TODO: may not need this at all
            return Dal.Employees.ToList();
        }

        public void CreateNewEmployee(Employee employee)
        {
            Dal.Employees.Add(employee);
            Dal.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = Dal.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
            Dal.Employees.Remove(employee);
            Dal.SaveChanges();
        }

        public void EditEmployee(Employee employee)
        {
            
            Dal.SaveChanges();
        }
    }
}
