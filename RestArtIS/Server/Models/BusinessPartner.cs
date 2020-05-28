using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestArtIS.Server.Models
{
    public partial class BusinessPartner
    {
        public Guid BusinessPartnerId { get; set; }
        public string Name { get; set; }
    }
}
