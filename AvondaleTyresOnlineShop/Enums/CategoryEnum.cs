using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Enums
{
    public enum CategoryEnum
    {
        [Display(Name = "Hindi language")]
        Brakes = 10,
        [Display(Name = "English language")]
        Tyres = 11,
        [Display(Name = "German language")]
        Accessories = 12,
        [Display(Name = "Chinese language")]
        Engine = 13,
        [Display(Name = "Urdu language")]
        Lights =  14
    }
}
