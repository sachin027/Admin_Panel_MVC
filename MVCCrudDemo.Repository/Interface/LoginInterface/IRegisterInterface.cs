using MVCCrudDemo.Models.DBContext;
using MVCCrudDemo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrudDemo.Repository.Interface.LoginInterface
{
    public interface IRegisterInterface
    {
        //Regiser new record
        RegisterMaster RegisterStudent(RegisterModel newUser);

        //Login method on custom model
        bool LoginUser(RegisterModel login);
    }
}
