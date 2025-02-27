using System.Web;
using System.Web.Mvc;

namespace Grupo_5_CE1_MN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
