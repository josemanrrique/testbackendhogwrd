using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hogwartsApi.Controllers
{
   // [Route("api/controller")]
    [ApiController]
   // [Route("[controller]")]   
    public class StudentController : ControllerBase
    {
        [HttpGet("[controller]/loadall")]
        public List<Student> ListAll()
        {           
            return ManageData.ReadAll();
        }
        [HttpPost("[controller]/new")]
        public int New([FromBody] Student value)
        {
            return ManageData.Agregate(value);
        }
        [HttpPost("[controller]/update")]
        public int Update([FromBody] Student value)
        {
            return ManageData.Update(value);
        }
        [HttpPost("[controller]/delete")]
        public bool Delete(int id)
        {
            return ManageData.Delete(id);
        }
    }
}