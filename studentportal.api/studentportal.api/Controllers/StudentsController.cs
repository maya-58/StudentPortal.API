using Microsoft.AspNetCore.Mvc;
using studentportal.api.DataModel;
using studentportal.api.DomainModels;
using studentportal.api.Repositories;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace studentportal.api.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        private readonly IImageRepository imagerepository;
        public StudentsController(IStudentRepository studentRepository,IMapper mapper,
            IImageRepository imagerepository)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.imagerepository = imagerepository;
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
        [HttpPost]
        [Route("[controller]/{studentid:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentid, Microsoft.AspNetCore.Http.IFormFile profileImage)
        {
            var validExtension = new List<string>
            {
                ".jpeg",
                ".png",
                ".jpg"
            };
            if(profileImage != null && profileImage.Length >0)
            {

                var extension = Path.GetExtension(profileImage.FileName);
                if (validExtension.Contains(extension))
                {
                    if (await studentRepository.Exists(studentid))
                    {
                        var FileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);
                        //upload image to local stroage
                        var fileImagePath = await imagerepository.Upload(profileImage, FileName);
                        //update the profile image path in the database
                        if (await studentRepository.UpdateProfileImage(studentid, fileImagePath))
                        {
                            return Ok(fileImagePath);
                        }
                        return StatusCode(StatusCodes.Status500InternalServerError, "Error Uploading Image");
                    }
                }
                return BadRequest("This is not a valid format");

                
            }
            //Check if user exist
            
            return NotFound();

        }
    }
}
