using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
   
    public class CountryNames
    {
        public List<SelectListItem> countries; 

            public CountryNames(){
                countries = new List<SelectListItem>();
            }
        public List<SelectListItem> getCountryList()
        {
          countries.Add(new SelectListItem { Text = "Germany", Value ="Germany", Selected = false });
          countries.Add(new SelectListItem { Text = "Sweden", Value ="Sweden", Selected = false });
          countries.Add(new SelectListItem { Text = "Norwary", Value ="Norway", Selected = true });

          return countries;
        }
    
    }


  
}