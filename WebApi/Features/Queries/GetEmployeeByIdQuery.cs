using MediatR;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Features.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
        {
            private readonly IApplicationContext _context;
            public GetEmployeeByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<Employee> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                var employee = _context.Employees.Where(a => a.Id == query.Id).FirstOrDefault();
                if (employee == null)
                {
                    return null;
                }
                return employee;
            }
        }
    }
}
