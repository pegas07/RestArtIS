using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestArtIS.Shared.Models
{
    public class PriceCategoryDto
    {
        public PriceCategoryDto()
        {
            //PriceCategoryId = Guid.NewGuid();
        }
        public Guid PriceCategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
