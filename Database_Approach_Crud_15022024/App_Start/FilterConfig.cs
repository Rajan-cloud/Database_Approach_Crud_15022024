﻿using System.Web;
using System.Web.Mvc;

namespace Database_Approach_Crud_15022024
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
