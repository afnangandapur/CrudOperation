using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManegementSystem.Models;

namespace UserManegementSystem.Controllers
{
    public class UserController : Controller
    {
        List<PersonModel> people = new List<PersonModel>()
        {
               new PersonModel { First = "Afnan", Last = "Khan", Name = "Afnankhan", About = "Student", Id = 1 },
               new PersonModel { First = "Zaid", Last = "Imtiaz", Name = "ZaidImtiaz", About = "Employee",  Id = 2},

        };

    
        // GET: Person
        public ActionResult Index()
        {
            if (Session["people"] != null)
            {
                var result = (List<PersonModel>)Session["people"];

                return View(result);
            }
            else
            {
                return View(people);
            }
          
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonModel per)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", per);

                }
                people.Add(per);
             
                Session["people"] = people;
                return RedirectToAction("Index");
           
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            PersonModel per = people.Find(emp => emp.Id == id);
            return View(per);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
         var per = people.Find(emp => emp.Id == id);
            return View(per);
        }
        [HttpPost]
        public ActionResult Edit(PersonModel per)
        {
            var result = people.Where(emp => emp.Id == per.Id).FirstOrDefault();
            result.First = per.First;
            result.Last = per.Last;
            result.Name = per.Name;
            result.About = per.About;
            Session["people"] = people;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            try
            {
                Session["people"] = people;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
