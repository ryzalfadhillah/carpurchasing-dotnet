using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Models.Dto.Req
{
    public class ReqLoginDto
    {
        [Required]
        public string Username { get; set; } = null!;
    }
}
