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

        public async Task<Student> DeleteStudent(Guid studentId)
        {
            //throw new NotImplementedException();
            var student = await GetStudentAsync(studentId);
            if(student != null)
            {
                context.Student.Remove(student);
                await context.SaveChangesAsync();
                return student;
            }

            return null;
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await context.Student.AnyAsync(x => x.Id == studentId);
            //throw new NotImplementedException();
        }

        public async Task<List<Gender>> GetGenderAsync()
        {
            //throw new NotImplementedException();
            return await context.Gender.ToListAsync();
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

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            // throw new NotImplementedException();

            var existingStudent =await  GetStudentAsync(studentId);
            if(existingStudent != null)
            {
                existingStudent.FirstName=request.FirstName;
                existingStudent.LastName = request.LastName;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Mobile=request.Mobile;
                existingStudent.Email = request.Email;
                existingStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = request.Address.PostalAddress;

                await context.SaveChangesAsync();
                return existingStudent;
            }
            
                return null;         


        }
    }
}
