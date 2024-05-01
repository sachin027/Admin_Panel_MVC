using MVCCrudDemo.Repository.Interface;
using System;
using MVCCrudDemo.Models.DBContext;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCCrudDemo.Models;
using MVCCrudDemo.Helper.Helper.StudentHelper;
using MVCCrudDemo.Models.ViewModel;
using MVCCrudDemo.Helper.Helper.LoginHelper;

namespace MVCCrudDemo.Repository
{
    public class StudentService : IStudentInterface
    {
         private readonly shyamEntities _DBContext = new shyamEntities();

        //for get all student
        public List<RegisterUsersModel> GetAllStudentData()
        {
            try
            {
                List<RegisterUsersModel> _studentList = new List<RegisterUsersModel>();
                List<RegisterUsers> studentList = _DBContext.RegisterUsers.ToList();
                _studentList = FormDetailHelper.GetStudentDetailsByHelper(studentList);
                return _studentList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //for insert record 
        public RegisterUsers InsertStudent(RegisterUsersModel CustomStudent)
        {
            try
            {
                RegisterUsers main = new RegisterUsers();
                main = FormDetailHelper.ConvertRegisterUsersModeltoRegisterUser(CustomStudent);
                _DBContext.RegisterUsers.Add(main);
                _DBContext.SaveChanges();
                return main;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //for delete record 
        public bool DeleteStudent(int id)
        {
            try
            {
                int temp = 0;
                RegisterUsers _student = _DBContext.RegisterUsers.Find(id);
                if(_student != null)
                {
                    _DBContext.Entry(_student).State = System.Data.Entity.EntityState.Deleted;
                    temp = _DBContext.SaveChanges();
                }

                if( temp > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //get student details by specific ID
        public RegisterUsersModel GetStudentByID(int? id)
        {
            try
            {
                RegisterUsers user = _DBContext.RegisterUsers.Find(id);
                RegisterUsersModel studentInfo = FormDetailHelper.ConvertRegisterToRegisterModel(user);
                return studentInfo;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //update the existing record
        public bool UpdateStudent(RegisterUsersModel student)
        {
            try
            {
                RegisterUsers saveInfo = new RegisterUsers();
                saveInfo = FormDetailHelper.ConvertRegisterUsersModeltoRegisterUser(student);

                if(saveInfo != null)
                {
                    _DBContext.Entry(saveInfo).State = System.Data.Entity.EntityState.Modified;
                    _DBContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
