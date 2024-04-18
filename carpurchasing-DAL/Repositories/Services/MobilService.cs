using carpurchasing_DAL.Models;
using carpurchasing_DAL.Models.Dto.Res;
using carpurchasing_DAL.Models.Prc;
using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services
{
    public class MobilService: IMobilService
    {
        readonly CarfurchasingfinalContext _dbcontext;
        readonly IConfiguration _config;

        public MobilService(CarfurchasingfinalContext dbcontext, IConfiguration config)
        {
            _dbcontext = dbcontext;
            _config = config;
        }

        public void DeleteCar(Guid id)
        {
            try
            {
                var car = _dbcontext.MstCars
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                if (car == null)
                {
                    throw new Exception("Data not found!");
                }
                _dbcontext.Remove(car);
                _dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Delete user failed: {ex.Message}");
            }
        }

        public async Task<PrcUpsertCar> ExecPrcCar(int engineSize, string fuelType, int manufactureYear, string cdChassis, string cdEngine, int brandId, int typeId, int usageId, int modelId, Guid? idUser)
        {
            try
            {
                string procedureName = "prc_upsert_car";
                string connectionString = _config.GetConnectionString("DefaultConnection") ?? "";
                PrcUpsertCar car = new PrcUpsertCar();

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(procedureName, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Tambahkan parameter name
                        command.Parameters.AddWithValue("p_engine_size", engineSize);

                        // Tambahkan parameter brand ID
                        command.Parameters.AddWithValue("p_fuel_type", fuelType);

                        // Tambahkan parameter brand ID
                        command.Parameters.AddWithValue("p_manufacture_year", manufactureYear);

                        // Tambahkan parameter user ID
                        command.Parameters.AddWithValue("p_cd_chassis", cdChassis);

                        // Tambahkan parameter user ID
                        command.Parameters.AddWithValue("p_cd_engine", cdEngine);

                        // Tambahkan parameter user ID
                        command.Parameters.AddWithValue("p_brand_id", brandId);

                        // Tambahkan parameter user ID
                        command.Parameters.AddWithValue("p_type_id", typeId);

                        // Tambahkan parameter user ID
                        command.Parameters.AddWithValue("p_usage_id", usageId);

                        // Tambahkan parameter user ID
                        command.Parameters.AddWithValue("p_model_id", modelId);

                        // Tambahkan parameter user ID
                        command.Parameters.AddWithValue("p_id_user", idUser);

                        // Tambahkan parameter untuk OUT_MESS
                        command.Parameters.Add(new NpgsqlParameter("out_mess", NpgsqlTypes.NpgsqlDbType.Varchar, 100)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        });

                        // Buka koneksi dan jalankan perintah
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        // Menerapkan output pada car
                        car.OutMess = command.Parameters["out_mess"].Value != DBNull.Value ? command.Parameters["out_mess"].Value.ToString() : "No value";

                        return car;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException($"ExecPrcCar : {e.Message}");
            }
        }

        public List<ResMobilDto> GetCar()
        {
            try
            {
                var cars = _dbcontext.MstCars
                    .OrderBy(a => a.Id)
                    .Select(x => new ResMobilDto
                    {
                        Id = x.Id,
                        EngineSize = x.EngineSize,
                        FuelType = x.FuelType,
                        ManufactureYear = x.ManufactureYear,
                        CdChassis = x.CdChassis,
                        CdEngine = x.CdEngine,
                        BrandId = x.BrandId,
                        TypeId = x.TypeId,
                        UsageId = x.UsageId,
                        ModelId = x.ModelId
                    })
                    .ToList();
                return cars;
            }
            catch (Exception ex)
            {
                throw new Exception($"GetCar : {ex.Message}");
            }
        }

        public ResMobilDto GetCarById(Guid id)
        {
            try
            {
                var car = _dbcontext.MstCars
                    .Where(x => x.Id == id)
                    .Select(x => new ResMobilDto
                    {
                        Id = x.Id,
                        EngineSize = x.EngineSize,
                        FuelType = x.FuelType,
                        ManufactureYear = x.ManufactureYear,
                        CdChassis = x.CdChassis,
                        CdEngine = x.CdEngine,
                        BrandId = x.BrandId,
                        TypeId = x.TypeId,
                        UsageId = x.UsageId,
                        ModelId = x.ModelId
                    })
                    .FirstOrDefault();
                if (car == null)
                {
                    throw new Exception("Data tidak ditemukan");
                }
                return car;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tidak dapat memuat data : {ex.Message}");
            }
        }

        public void UpdateCar(Guid id, ResMobilDto car)
        {
            try
            {
                _dbcontext.MstCars
                    .Where(u => u.Id == id)
                    .ExecuteUpdate(setter => setter
                        .SetProperty(u => u.EngineSize, car.EngineSize)
                        .SetProperty(u => u.FuelType, car.FuelType)
                        .SetProperty(u => u.ManufactureYear, car.ManufactureYear)
                        .SetProperty(u => u.CdChassis, car.CdChassis)
                        .SetProperty(u => u.CdEngine, car.CdEngine)
                        .SetProperty(u => u.BrandId, car.BrandId)
                        .SetProperty(u => u.TypeId, car.TypeId)
                        .SetProperty(u => u.UsageId, car.UsageId)
                        .SetProperty(u => u.ModelId, car.ModelId)
                        .SetProperty(u => u.DtUpdated, DateTime.Now)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception($"Tidak dapat mengubah data : {ex.Message}");
            }
        }
    }
}
