using MediatR;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Features.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateEmployeeCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = new Employee();
                employee.Name = command.Name;
                employee.Salary = command.Salary;
                _context.Employees.Add(employee);
                await _context.SaveChanges();
                return employee.Id;
            }
        }
    }
}
