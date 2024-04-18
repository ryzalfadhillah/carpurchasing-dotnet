using carpurchasing_DAL.Models.Dto.Res;
using carpurchasing_DAL.Models.Prc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services.Interface
{
    public interface IMobilService
    {
        List<ResMobilDto> GetCar();

        Task<PrcUpsertCar> ExecPrcCar(int engineSize, string fuelType, int manufactureYear, string cdChassis, string cdEngine, int brandId, int typeId, int usageId, int modelId, Guid? idUser);

        ResMobilDto GetCarById(Guid id);

        void UpdateCar(Guid id, ResMobilDto car);

        void DeleteCar(Guid id);
    }
}
