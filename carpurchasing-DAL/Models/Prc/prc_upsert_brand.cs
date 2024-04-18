using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Models.Prc
{
    public class prc_upsert_brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public Guid IdUser { get; set; }
        public string? OutMess { get; set; }
    }
}
