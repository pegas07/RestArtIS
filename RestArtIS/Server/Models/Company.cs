﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace RestArtIS.Server.Models
{
    public partial class Company
    {
        public Company()
        {
            Parlor = new HashSet<Parlor>();
        }

        public Guid CompanyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Parlor> Parlor { get; set; }
    }
}