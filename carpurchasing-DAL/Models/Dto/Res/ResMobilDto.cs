using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Models.Dto.Res
{
    public class ResMobilDto
    {
        public Guid Id { get; set; }

        public int? EngineSize { get; set; }

        public string? FuelType { get; set; }

        public int? ManufactureYear { get; set; }

        public string? CdChassis { get; set; }

        public string? CdEngine { get; set; }

        public int? BrandId { get; set; }

        public int? TypeId { get; set; }

        public int? UsageId { get; set; }

        public int? ModelId { get; set; }

        public DateTime? DtAdded { get; set; }

        public DateTime? DtUpdated { get; set; }

        public string? IdUserAdded { get; set; }

        public string? IdUserUpdated { get; set; }
    }
}
