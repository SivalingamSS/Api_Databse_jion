using Api_Databse_CRUD.DBContext;
using Api_Databse_CRUD.Model;
using Api_Databse_CRUD.viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Api_Databse_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly DBContacts _dbcontext;
        public ValuesController(DBContacts dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet("Get")]
        public object Get()
        {
            var get = (from table1 in _dbcontext.Employee
                       join table2 in _dbcontext.salary on
                       table1.empid equals table2.sno
                       select new ViewModel
                       {
                           empid = table1.empid,
                           empname = table1.empname,
                           empage = table1.empage,
                           empdept = table1.empdept,
                           empplace = table1.empplace,  
                           salary = table2.salary
                       }).ToList();
            return get;
        }

        [HttpPost("Post")]
        public object Post(ViewModel id)
        {
            var postdata = new model()
            {
                empname = id.empname,
                empage = id.empage,
                empdept = id.empdept,
                empplace = id.empplace,
            };
             _dbcontext.Employee.Add(postdata);
            _dbcontext.SaveChanges();
            var postdata2 = new model2()
            {
                salary = id.salary,
            };
            _dbcontext.salary.Add(postdata2);
            _dbcontext.SaveChanges();
            return postdata;
        }
        [HttpPut("Put")]
        public object Put(int id, ViewModel data)
        {
            var putdata = _dbcontext.Employee.Find(id);
            if (putdata != null)
            {
                putdata.empname = data.empname;
                putdata.empage = data.empage;
                putdata.empdept = data.empdept;
                putdata.empplace = data.empplace;
            }
            _dbcontext.SaveChanges();
            var put1 = _dbcontext.salary.Find(data.empid);
            if (put1 != null)
            {
                put1.salary = data.salary;
            };
            _dbcontext.SaveChanges();
            return putdata;
        }
        [HttpDelete("Delete")]
        public object Delete(int id)
        {
            var delete2 = _dbcontext.Employee.Find(id);
            if (delete2 != null)
            {
                _dbcontext.Remove(delete2);
                _dbcontext.SaveChanges();
            }
            var delete1 = _dbcontext.salary.Find(id);
            if (delete1 != null)
            {
                _dbcontext.Remove(delete1);
                _dbcontext.SaveChanges();
            }
            return id;
        }
    }
}
   