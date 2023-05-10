using DesignPattern.ChainOfResponsibility.Constants;
using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        private Context _context;

        public AreaDirector(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            CustomerProcess customerProcess = new();

            if (request.Amount <= 400000)
            {
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.EmployeeName = Employees.AreaDirector;
                customerProcess.Description = Messages.AmountPaid;

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else
            {
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.EmployeeName = Employees.AreaDirector;
                customerProcess.Description = Messages.AreaDirectorCantPay;

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
        }
    }
}
