﻿using System.Web;
using System.Web.Mvc;

namespace VidlyTwo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new RequireHttpsAttribute());//just for http attribute
        }
    }
}
