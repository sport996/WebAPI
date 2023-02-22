using MediatR;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Features.Commands
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private readonly IApplicationContext _context;
            public UpdateEmployeeCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = _context.Employees.Where(a => a.Id == command.Id).FirstOrDefault();
                if (employee == null)
                {
                    return default;
                }
                else
                {
                    employee.Name = command.Name;
                    employee.Salary = command.Salary;
                    await _context.SaveChanges();
                    return employee.Id;
                }
            }
        }
    }
}
