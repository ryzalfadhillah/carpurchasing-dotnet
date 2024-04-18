using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Models.Dto.Res
{
    public class ResBrandDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Country { get; set; }

        public DateTime? DtAdded { get; set; }

        public DateTime? DtUpdated { get; set; }

        public string? IdUserAdded { get; set; }
    }
}
