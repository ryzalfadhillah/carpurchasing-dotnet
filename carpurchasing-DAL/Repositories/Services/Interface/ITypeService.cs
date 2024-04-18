using carpurchasing_DAL.Models;
using carpurchasing_DAL.Models.Dto.Req;
using carpurchasing_DAL.Models.Dto.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services.Interface
{
    public interface ITypeService
    {
        List<MstType> GetType();

        void AddType(ReqTypeDto type);

        ResTypeDto GetTypeById(int id);

        void UpdateType(int id, ReqTypeDto type);

        void DeleteType(int id);
    }
}
