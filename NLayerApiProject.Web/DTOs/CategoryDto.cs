﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerApiProject.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        // 0 : Name
        [Required(ErrorMessage = "{0} alanı boş olamaz ")]
        public string Name { get; set; }
    }
}