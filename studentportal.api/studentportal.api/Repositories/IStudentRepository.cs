using studentportal.api.DataModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace studentportal.api.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
    }
}
