using Microsoft.AspNetCore.Mvc;
using studentportal.api.DataModel;
using studentportal.api.DomainModels;
using studentportal.api.Repositories;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using System;

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

        [HttpGet]
        [Route("[controller]/{studentid:guid}"),ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentid)
        {
            //Fetch student details
            var Student = await studentRepository.GetStudentAsync(studentid);


            //return student
            if(Student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(Student));
            

        }

        [HttpPut]
        [Route("[controller]/{studentid:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentid, [FromBody] UpdateStudentRequest request)
        {
 //var studentDataModel=
            if(await studentRepository.Exists(studentid))
            {
              var updatedStudent=  await studentRepository.UpdateStudent(studentid,mapper.Map<DataModel.Student>(request));
                if(updatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(updatedStudent));
                }
            }
            
                return NotFound();
            
        }

        [HttpDelete]
        [Route("[controller]/{studentid:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentid)
        {
            if(await studentRepository.Exists(studentid))
            {
                var student=await studentRepository.DeleteStudent(studentid);

                return Ok(mapper.Map<StudentDTO> (student));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
            var student = await studentRepository.AddStudent(mapper.Map<DataModel.Student>(request));

            return CreatedAtAction(nameof(GetStudentAsync),new {studentId = student.Id},
                mapper.Map<StudentDTO>(student));
        }
    }
}
