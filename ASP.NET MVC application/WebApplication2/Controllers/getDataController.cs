using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class getDataController : Controller
    {
        List<SelectListItem> sl = new List<SelectListItem>();

        // GET: getData
        public ActionResult Index()
        {
            /* 
             // using hard coded values to gerenarte drop downlist
            SelectListItem slt = new SelectListItem();
            slt.Value = "Germany";
            slt.Text = "Germany";
            slt.Selected = true; //this value will be selctedby default when list populates

            SelectListItem slt1 = new SelectListItem();
            slt1.Value = "Sweden";
            slt1.Text = "Sweden";
            slt1.Selected = false; 

            
           
            sl.Add(slt);
            sl.Add(slt1);

            ViewData["item"] = sl;
            */

            //generating countries list from hard coded Model
            CountryNames cn = new CountryNames();
            foreach (var item in cn.getCountryList())
            {
                sl.Add(item);

            }
            ViewData["item"] = sl;
            ViewData["experienceInYears"] = new YearsOfExperience().GetExperience();
            return View();

        }

        public ActionResult fileUploadAction(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewData["FileUploaded"] = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewData["FileUploaded"] = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewData["FileUploaded"] = "You have not specified a file.";
            }

            return Redirect("Index");
        } 
        public ActionResult getDataCustomer(FormCollection fc)
        {


            //fc contains data posed from form when submit button is pressed
            String applicantName = fc["yourName"];
            String applicantDegree = fc["yourDegree"];

             return View();
        }
        public ActionResult finalisedNowSubmit(FormCollection fc)
        {
            try
            {
                if (fc["captcha"].ToLower() == "yes")
                {
                    ViewData["capchatValidated"] = true;
                    return View();
                }
                else
                {
                    //wrong captcha entered
                    // the following way is t take ot the view and then in vie wthere is Action link to bring him back to this action
                    return RedirectToAction("wrongCode");
                }
            }
            catch (Exception e)
            {
                //no captcha entered, fc["captcha"] is null
                // this is to redirect to this same action from where it was fired
                return Redirect("getDataCustomer");
            }
                
                
            
        }


        public ActionResult wrongCode()
        {
            return View();
        }
        

    }
 
}