using MVCCrudDemo.Models;
using MVCCrudDemo.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrudDemo.Helper.Helper.StudentHelper
{
    /// <summary>
    /// form detail helper bind custom data into form data 
    /// this method will check either null or not then fetch custom model data and store in _registerStudent
    /// </summary>
    public class FormDetailHelper
    {
        public static List<RegisterUsersModel> GetStudentDetailsByHelper(List<RegisterUsers> studentList)
        {
            List<RegisterUsersModel> _RegisterStudent = new List<RegisterUsersModel>();

            try
            {
                if (studentList != null && studentList.Count > 0)
                {
                    foreach (RegisterUsers student in studentList)
                    {
                        RegisterUsersModel studentModel = new RegisterUsersModel();
                        studentModel.UsersID = student.UsersID;
                        studentModel.FirstName = student.FirstName;
                        studentModel.LastName = student.LastName;
                        studentModel.Address = student.Address;
                        studentModel.City = student.City;
                        _RegisterStudent.Add(studentModel);
                    }
                }
                return _RegisterStudent;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static RegisterUsers ConvertRegisterUsersModeltoRegisterUser(RegisterUsersModel customModel)
        {
            try
            {
                RegisterUsers form = new RegisterUsers();

                if(customModel != null)
                {
                    form.UsersID = customModel.UsersID;
                    form.FirstName = customModel.FirstName;
                    form.LastName = customModel.LastName;
                    form.Address = customModel.Address;
                    form.City = customModel.City;
                };
                return form;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static RegisterUsersModel ConvertRegisterToRegisterModel(RegisterUsers registerUser)
        {
            try
            {
                RegisterUsersModel registerUsersModel = new RegisterUsersModel();
                if(registerUser != null)
                {
                    registerUsersModel.UsersID = registerUser.UsersID;
                    registerUsersModel.FirstName = registerUser.FirstName;
                    registerUsersModel.LastName = registerUser.LastName;
                    registerUsersModel.Address = registerUser.Address;
                    registerUsersModel.City = registerUser.City;
                }
                return registerUsersModel;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
