using Microsoft.AspNetCore.Mvc;
using studentportal.api.DataModel;
using studentportal.api.DomainModels;
using studentportal.api.Repositories;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;

namespace studentportal.api.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public StudentsController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            //return View();
            // return Ok(studentRepository.GetStudents());

            var students =await studentRepository.GetStudentsAsync();

            ;

            /*
            var domainmodelStudents = new List<StudentDTO>();

            foreach (var student in students) {
                domainmodelStudents.Add(new StudentDTO()
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Email = student.Email,
                    Mobile=student.Mobile,
                    ProfileImageURl=student.ProfileImageURl,
                    GenderId=student.GenderId,

                    Address = new AddressDTO()
                    {
                        Id= student.Address.Id,
                        PhysicalAddress=student.Address.PhysicalAddress,
                        PostalAddress=student.Address.PostalAddress
                    },

                    Gender = new GenderDTO()
                    {
                        Id=student.Gender.Id,
                        Description=student.Gender.Description
                    }

                });
            }
            */
            return Ok(mapper.Map<List<StudentDTO>>(students));
        }
    }
}
