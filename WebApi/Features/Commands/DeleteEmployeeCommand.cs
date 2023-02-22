using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;

namespace WebApi.Features.Commands
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
        {
            private readonly IApplicationContext _context;
            public DeleteEmployeeCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteEmployeeCommand command, CancellationToken cancelationToken)
            {
                var employee = await _context.Employees.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (employee == null)
                {
                    return default;
                }
                _context.Employees.Remove(employee);
                await _context.SaveChanges();
                return employee.Id;
            }
        }
    }
}
