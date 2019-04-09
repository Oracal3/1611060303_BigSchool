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
        public int Id { get; set; }

        [Display(Name ="Địa điểm")]
        [Required(ErrorMessage ="Không được để trống")]
        public string Place { get; set; }

        [Display(Name = "Ngày")]
        [Required(ErrorMessage = "Không được để trống")]
        [FutureDate(ErrorMessage = "Định dạng ngày sai (Ngày/tháng/năm)")]
        public string Date { get; set; }

        [Display(Name = "Thời gian")]
        [ValidTime(ErrorMessage = "Định dạng giờ sai (giờ:phút)")]
        [Required(ErrorMessage = "Không được để trống")]
        public string Time { get; set; }

        [Display(Name = "Nội dung khóa học")]
        [Required(ErrorMessage = "Không được để trống")]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string Heading { get; set; }
        public string Action { get { return(Id != 0)?"Update":"Create";} }
        public DateTime GetDatetime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}