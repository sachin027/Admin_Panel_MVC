using MVCCrudDemo.Models;
using MVCCrudDemo.Models.DBContext;
using MVCCrudDemo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrudDemo.Repository.Interface
{
    public interface IStudentInterface
    {
        // this method is for get all students record and return all the data in table
        List<RegisterUsersModel> GetAllStudentData();

        //this method is for insert student data in database and show in table
        RegisterUsers InsertStudent(RegisterUsersModel user);

        //Delete specific record
        bool DeleteStudent(int id);

        //get student details by their ID
        RegisterUsersModel GetStudentByID(int? id);

        //update record
        bool UpdateStudent(RegisterUsersModel student);

    }
}
