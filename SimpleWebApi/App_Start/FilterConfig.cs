using System.Web.Mvc;

namespace SimpleWebApi
{
    /// <summary>
    /// This is the Filter Config Class
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// These are the Filters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
