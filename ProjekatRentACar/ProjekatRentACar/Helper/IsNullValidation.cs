using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Helper
{
    public class IsNullValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if ((value as Lokacija).Naziv == null) return false;
            return true;
        }
    }
}
