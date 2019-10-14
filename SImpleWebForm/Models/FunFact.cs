using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SimpleWebForm.Models
{
    public class FunFact
    {

        [Required(ErrorMessage = "You need to provide your Name.")]
        [Display(Name = "User Name")]
        public string FormUserName { get; set; }

        [Required(ErrorMessage = "You need to provide a Fun Fact.")]
        [Display(Name = "Fun Fact")]
        [DataType(DataType.MultilineText)]
        public string FormFunFact { get; set; }
    }
}