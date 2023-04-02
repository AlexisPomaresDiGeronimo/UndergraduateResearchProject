using System.Web;
using System.Web.Mvc;

namespace Undergraduate_Aliveri_Web_App_Project
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
