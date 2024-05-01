using MVCCrudDemo.Helper.Helper.LoginHelper;
using MVCCrudDemo.Models.DBContext;
using MVCCrudDemo.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrudDemo.Repository.Interface.LoginInterface
{
    public class LoginService : IRegisterInterface
    {
        private readonly shyamEntities _DBContext = new shyamEntities();

        /// <summary>
        /// Login method it will check email and password
        /// </summary>
        public bool LoginUser(RegisterModel login)
        {
            try
            {
                RegisterMaster registerMaster = new RegisterMaster();
                registerMaster = LoginHelper.RegisterModeltoRegister(login);
                registerMaster = _DBContext.RegisterMaster.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
                
                if(registerMaster != null )
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        ///summary
        ///register new user 

        public RegisterMaster RegisterStudent(RegisterModel newUser)
        {

            try
            {
                RegisterMaster register = new RegisterMaster();
                register = LoginHelper.RegisterModeltoRegister(newUser);

                // if will check email exist or not
                var isEmailExist = _DBContext.RegisterMaster.Any(x => x.Email == newUser.Email);

                //if not exist then it will save into database else return null
                if (!isEmailExist)
                {
                    _DBContext.RegisterMaster.Add(register);
                    _DBContext.SaveChanges();
                    return register;
                }
                else
                {
                   return null; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
