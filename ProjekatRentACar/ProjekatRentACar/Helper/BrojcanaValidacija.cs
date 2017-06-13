using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjekatRentACar.Helper
{
    class BrojcanaValidacija : ValidationAttribute
    {
            public override bool IsValid(object value)
            {
                if (value == null) return true;
                if (!Regex.IsMatch(value.ToString(), @"^\d+$") || value.ToString() == "0") return false;
                return true;
            }
      }
}

