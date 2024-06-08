using Crud_Project.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Project.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    //[ApiController]
    public class RegisterAPI : ControllerBase
    {
        String con;
        DB.DBRegister db = new DB.DBRegister();
        public RegisterAPI(IConfiguration app)
        {
            con = app["ConnectionStrings:SqlServerDb"] ?? "";
            db.connectionString(con);

        }


        [HttpPost]
        [Route("api/Register/Post")]
        public String Post(ModelRegister reg)
        {
            string res = db.Post(reg,con);
            return res;
        }

        [HttpPut]
        [Route("api/Register/Put")]
        public String Put(ModelRegister reg,int Id)
        {
            string res = db.Put(reg, con,Id);
            return res;
        }

        [HttpGet]
        [Route("api/Register/Get")]
        public IEnumerable<ModelRegister> getRegisterData()
        {
            return db.getRegisterData();
        }

        [HttpPut]
        [Route("api/Register/Delete")]
        public String Delete(int Id)
        {
            string res = db.Delete(Id);
            return res;
        }
    }
}
