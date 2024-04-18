using carpurchasing_DAL.Models;
using carpurchasing_DAL.Repositories.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services
{
    public class ModelService: IModelService
    {
        readonly CarfurchasingfinalContext _dbcontext;

        public ModelService(CarfurchasingfinalContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<VwMstModel> GetModels()
        {
            return _dbcontext.VwMstModels.ToList();
        }
    }
}
