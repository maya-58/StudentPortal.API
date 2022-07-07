using System;
using studentportal.api.DataModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using studentportal.api.DomainModels;
using System.Threading.Tasks;

namespace studentportal.api.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;
        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context=context;
        }

        public async Task<Student> GetStudentAsync(Guid StudentId)
        {
            //throw new NotImplementedException();
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address))
                .FirstOrDefaultAsync(x => x.Id == StudentId);
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            //throw new NotImplementedException();
            return await context.Student.Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

    }
}
