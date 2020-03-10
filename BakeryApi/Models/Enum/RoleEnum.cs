using System.ComponentModel.DataAnnotations;

namespace BakeryApi.Models.Enum
{
    public enum RoleEnum
    {
        [Display(Name = "کاربر")] 
        User = 1,

        [Display(Name = "مدیر")] 
        Admin = 2,

        [Display(Name = "نانوا")] 
        Baker = 3,

        [Display(Name = "پیک")] 
        Delivery = 4,

        [Display(Name = "اپراتور")] 
        Operator = 5
    }
}