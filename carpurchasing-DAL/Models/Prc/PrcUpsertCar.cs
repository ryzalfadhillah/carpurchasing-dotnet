using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Models.Prc
{
    public class PrcUpsertCar
    {
        public Guid Id { get; set; }

        public int EngineSize { get; set; }

        public string? FuelType { get; set; }

        public int ManufactureYear { get; set; }

        public string? CdChassis { get; set; }

        public string? CdEngine { get; set; }

        public int BrandId { get; set; }

        public int TypeId { get; set; }

        public int UsageId { get; set; }

        public int ModelId { get; set; }

        public string? IdUser { get; set; }

        public string? OutMess { get; set; }
    }
}
