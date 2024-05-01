using MVCCrudDemo.CustomFilter;
using MVCCrudDemo.Models;
using MVCCrudDemo.Models.DBContext;
using MVCCrudDemo.Repository;
using MVCCrudDemo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrudDemo.Controllers
{
    [CustomAuthorize]
    //[CustomAuthenticationFilter]
    public class DashBoardController : Controller
    {
         IStudentInterface _RegisterContext;
        public DashBoardController(IStudentInterface registerContext)
        {
            _RegisterContext = registerContext;
        }

        // GET: DashBoard

        /// <summary>
        /// its make service object and then call method for get all students data and pass into view 
        /// </summary>
        /// 
        [HttpGet]
        public ActionResult DashBoard()
        {
            try
            {
                StudentService registerAllStudent = new StudentService( );
                List<RegisterUsersModel> studentData = registerAllStudent.GetAllStudentData();   
                return View(studentData);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error" , "DashBoard");
            }
        }

        //insert record in table
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterUsersModel customModel)
        {
            try
            {
                if(ModelState.IsValid && customModel != null)
                {

                    _RegisterContext.InsertStudent(customModel);

                    return RedirectToAction("DashBoard");
                }
                else
                {
                    return View();
                }
          
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Delete record from table
        public ActionResult Delete(int id)
        {
            bool deleteRecord = _RegisterContext.DeleteStudent(id);
            return RedirectToAction("DashBoard");

        }

        //edit record
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            RegisterUsersModel studentObj = _RegisterContext.GetStudentByID(id);
            return View(studentObj);
        }

        [HttpPost]
        public ActionResult Edit(RegisterUsersModel student)
        {
            bool IsEdit = _RegisterContext.UpdateStudent(student);

            if(ModelState.IsValid)
            {
                return RedirectToAction("DashBoard");
            }
            return View();
        }

        //view student record by id
        public ActionResult StudentInfoById(int? id)
        {
            RegisterUsersModel student = _RegisterContext.GetStudentByID(id);

            return View(student);
        }


        //error page
        public ActionResult Error()
        {
            return View();
        }
    }
}