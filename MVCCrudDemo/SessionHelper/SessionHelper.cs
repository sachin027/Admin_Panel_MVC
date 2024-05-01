using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCCrudDemo.SessionHelper
{
    public class SessionCustomHelper
    {

        public static string UserEmail
        {
            get
            {
                return HttpContext.Current.Session["UserEmail"] == null ? "" : (string)HttpContext.Current.Session["UserEmail"];
            }
            set
            {
                HttpContext.Current.Session["UserEmail"] = value;
            }
        }        
       
    }
}
