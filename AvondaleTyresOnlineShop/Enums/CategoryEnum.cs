using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvondaleTyresOnlineShop.Enums
{
    public enum CategoryEnum
    {
        [Display(Name = "Brakes")]
        Brakes = 1,
        [Display(Name = "Tyres")]
        Tyres = 2,
        [Display(Name = "Accessories")]
        Accessories = 3,
        [Display(Name = "Engine")]
        Engine = 4,
        [Display(Name = "Lights")]
        Lights =  5
    }
}
