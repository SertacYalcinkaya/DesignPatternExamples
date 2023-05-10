﻿using DesignPattern.ChainOfResponsibility.Constants;
using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        private Context _context;

        public Treasurer(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            CustomerProcess customerProcess = new();

            if (request.Amount <= 100000)
            {
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.EmployeeName = Employees.Treasurer;
                customerProcess.Description = Messages.AmountPaid;

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                customerProcess.Amount = request.Amount.ToString();
                customerProcess.Name = request.Name;
                customerProcess.EmployeeName = Employees.Treasurer;
                customerProcess.Description = Messages.TreasurerCantPay;

                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();

                NextApprover.ProcessRequest(request);
            }
        }
    }
}
