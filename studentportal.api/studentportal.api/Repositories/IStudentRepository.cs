using studentportal.api.DataModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace studentportal.api.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();

        Task<Student> GetStudentAsync(Guid StudentId);

        Task<List<Gender>> GetGenderAsync();

        Task<bool> Exists(Guid studentId);

        Task<Student> UpdateStudent(Guid studentId, Student request);
    }
}
