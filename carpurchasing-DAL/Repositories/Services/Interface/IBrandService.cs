using carpurchasing_DAL.Models.Dto.Res;
using carpurchasing_DAL.Models.Prc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services.Interface
{
    public interface IBrandService
    {
        List<ResBrandDto> GetBrands();

        Task<prc_upsert_brand> ExecPrcBrand(string name, string country, string idUser);

        void DeleteBrand(int id);
    }
}
