using Database_Approach_Crud_15022024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;


namespace Database_Approach_Crud_15022024.Controllers
{
    public class PersonalController : Controller
    {
        Rajan_RR_DBEntities3 db = new Rajan_RR_DBEntities3();
        private string search;

        // GET: Personal
        [HttpGet]
        public ActionResult Index(int id=0)
       {
            ViewBag.dpt= db.Countries.ToList();
            ViewBag.abc = db.Student_data.ToList();
            ViewBag.btn = "Submit";
            Student_data data = new Student_data();
           
            if (id > 0)
            {
                var data1=(from a in db.Student_data where a.Std_id==id select a).ToList();
                data.Std_id = data1[0].Std_id;
                data.Std_name = data1[0].Std_name;
                data.Std_Age = data1[0].Std_Age;
                data.Email = data1[0].Email;
                data.Department = data1[0].Department;
                data.Position= data1[0].Position;
                ViewBag.btn = "Update";
            }
            ViewBag.stt = (from a in db.tbl_position where a.cid == data.Department select a).ToList();
  
            return View(data);
        }

        public ActionResult Validate()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Index(Student_data std)
        {
            if(ModelState.IsValid)
            {
                if (std.Std_id > 0)
                {
                    db.Entry(std).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                   
                    db.Student_data.Add(std);
                }
                db.SaveChanges();
                return RedirectToAction("Getdata");

            }
            else
            {
                return View();
            }
           
        }

        public ActionResult Del(int id=0)
        {
            var data= db.Student_data.Find(id);
            db.Student_data.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Getdata");
        }

        [HttpGet]
        public ActionResult Search(string search)
        {   
           
            return View(db.Student_data.Where(x=>x.Std_name.StartsWith(search) || search == null).ToList());
        }
        public JsonResult GetState(int A)
        {
            var data= (from a in db.tbl_position where a.cid==A select a).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Getdata()
        {
            var data = (from a in db.Student_data
                          join b in db.Countries on a.Department equals b.cid
                          join c in db.tbl_position on a.Position equals c.pid
                        select new Student_data1 {Std_id=a.Std_id, Std_name=a.Std_name, Email=a.Email, Department=b.cname, Position=c.pname })
                .ToList();
            return View(data);
        }


        [HttpGet]
        public ActionResult Index1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index1(personalinfo pr)
        {
           // db.personalinfoes.Add(pr);  
            db.SaveChanges();
            return View();
        }

    }
}
























































