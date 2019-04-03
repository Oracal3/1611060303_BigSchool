using Bigschool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bigschool.ViewModels
{
    public class CourseViewModel
    {
        [Required(ErrorMessage = "Not be empty")]
        public string Place { get; set; }

        [Required(ErrorMessage = "Not be empty")]
        [FutureDate]
        public string Date { get; set; }

        [ValidTime]
        [Required(ErrorMessage = "Not be empty")]
        public string Time { get; set; }

        [Required(ErrorMessage = "Not be empty")]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime GetDatetime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}