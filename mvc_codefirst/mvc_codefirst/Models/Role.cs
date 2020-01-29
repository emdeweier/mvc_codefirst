using mvc_codefirst.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc_codefirst.Models
{
    [Table("TB_M_Role")]
    public class Role : BaseModel
    {
        public string Name { get; set; }
    }
}