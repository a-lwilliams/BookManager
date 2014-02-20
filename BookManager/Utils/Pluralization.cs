using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Data.Entity.Design.PluralizationServices;

namespace BookManager.Utils
{
    public class Pluralization
    {
        public static string GetPlural(string singular, int amnt)
        {
            if (amnt != 1)
            {
                PluralizationService service = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en-us"));
                return amnt + " " + service.Pluralize(singular);
            }
            else
            {
                return amnt + " " + singular;
            }
            
        }
    }
}