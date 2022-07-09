using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using studentportal.api.DataModel;
using studentportal.api.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace studentportal.api.Controllers
{
    public class GendersController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;
        public GendersController(IStudentRepository studentRepository,IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper= mapper;
        }


        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderlist = await studentRepository.GetGenderAsync();

            if(genderlist ==null || !genderlist.Any())
            {
                return NotFound();
            }
            // return View();

            return Ok(mapper.Map<List<Gender>>(genderlist));
        }
    }
}
