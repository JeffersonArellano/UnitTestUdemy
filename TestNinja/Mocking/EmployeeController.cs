using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private readonly IEmployeeStorage _storage;
     
        public EmployeeController(IEmployeeStorage storage)
        {            
            this._storage = storage;
        }

        public ActionResult DeleteEmployee(int id)
        {
            _storage.DeleteEmployee(id);
            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }

    public interface IEmployeeContext
    {
        DbSet<Employee> Employees { get; set; }

        void SaveChanges();
    }

    public class EmployeeContext : IEmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}