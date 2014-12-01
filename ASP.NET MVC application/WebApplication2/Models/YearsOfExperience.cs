using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class YearsOfExperience
    {
        public int ExperienceId { get; set; }
        public string ExperienceYears { get; set; }

        public List<YearsOfExperience> GetExperience()
        {
            return new List<YearsOfExperience> { 
        new YearsOfExperience () {  ExperienceId = 1, ExperienceYears = "No Experiece"}, 
        new YearsOfExperience () {  ExperienceId = 2, ExperienceYears = "Between 1 - 3 Years"},
        new YearsOfExperience () {  ExperienceId = 3, ExperienceYears = "Between 3 - 5 Years" },
        new YearsOfExperience () {  ExperienceId = 4, ExperienceYears = "More than 5  Years" }
        };
        }   
    }

}