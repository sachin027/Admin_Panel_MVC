using MVCCrudDemo.Models.DBContext;
using MVCCrudDemo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrudDemo.Helper.Helper.LoginHelper
{
    public class LoginHelper
    {
        public static RegisterMaster RegisterModeltoRegister(RegisterModel registerModel )
        {
            try
            {
                RegisterMaster registerMaster = new RegisterMaster();
                if(registerModel != null)
                {
                    registerMaster.UserName = registerModel.UserName;
                    registerMaster.Email = registerModel.Email;
                    registerMaster.Password = registerModel.Password;
                };
                return registerMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
        public static RegisterModel RegistertoRegisterModel(RegisterMaster registerMaster )
        {
            try
            {
                RegisterModel registerModel = new RegisterModel();
                if(registerMaster != null)
                {
                    registerModel.UserName = registerMaster.UserName;
                    registerModel.Email = registerMaster.Email;
                    registerModel.Password = registerMaster.Password;
                };
                return registerModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
