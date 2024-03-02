using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Database_Approach_Crud_15022024.Models
{
    public class Validation_page
    {
        public int Std_id { get; set; }

        [Required (ErrorMessage="Name is required")]
        public string Std_name { get; set; }

        public int Std_Age { get; set; }
        public string Email { get; set; }
        public int Department { get; set; }
        public int Position { get; set; }
    }
}