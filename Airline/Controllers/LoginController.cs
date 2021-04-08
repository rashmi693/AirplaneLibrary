using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airline.Models;
using AirplaneLib;
namespace Airline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUser(Passenger p)
        {
            LoginDal logindal = new LoginDal();
            if (logindal.VerifyData(p) == 0)
            {
                ViewBag.errormsg = "No such User Exists!!";
            }
            else if (logindal.VerifyData(p) == -1)
            {
                ViewBag.errormsg = "Userid / Password is incorrect";
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Register(LoginModel ld)
        {
            LoginDal logindal = new LoginDal();
            if (logindal.EmailExist(ld.Email))
            {
                ViewBag.erroremail = "Email Already Registered";
                return View();
            }

            Passenger p = new Passenger();
            p.Email = ld.Email;
            p.FName = ld.FName;
            p.LName = ld.LName;
            p.Age = ld.Age;
            p.PhoneNo = Convert.ToInt64(ld.PhoneNo);
            p.Pwd = ld.Pwd;
            logindal.InsetData(p);
            return View();
        }
        public ActionResult ForgetPass()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ForgetPass(LoginModel m)
        {
            LoginDal logindal = new LoginDal();
            if (!logindal.EmailExist(m.Email))
            {
                ViewBag.femail = "Email Id not Registered";
                return View();
            }
            Passenger p = new Passenger();
            p.Email = m.Email;
            p.Pwd = m.Pwd;
            logindal.ChangePassword(p);
            ViewBag.msg = "Password Changed Successfully!!";
            return View();
           
        }
        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
