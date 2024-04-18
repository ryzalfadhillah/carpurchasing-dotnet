using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Models.Dto.Req
{
    public class ReqTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
