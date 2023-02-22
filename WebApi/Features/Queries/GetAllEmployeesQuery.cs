using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Features.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
        {
            private readonly IApplicationContext _context;
            public GetAllEmployeesQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery query, CancellationToken cancelToken)
            {
                var employeeList = await _context.Employees.ToListAsync();
                if (employeeList == null)
                {
                    return null;
                }
                return employeeList.AsReadOnly();
            }
        }
    }
}

