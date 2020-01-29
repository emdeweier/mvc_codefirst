using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_codefirst.Base
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}