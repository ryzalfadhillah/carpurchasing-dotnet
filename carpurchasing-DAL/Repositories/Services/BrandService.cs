using carpurchasing_DAL.Models;
using carpurchasing_DAL.Models.Dto.Res;
using carpurchasing_DAL.Models.Prc;
using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services
{
    public class BrandService : IBrandService
    {
        readonly CarfurchasingfinalContext _dbContext;
        readonly IConfiguration _config;

        public BrandService(CarfurchasingfinalContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public List<ResBrandDto> GetBrands()
        {
            try
            {
                var brands = _dbContext.MstBrands
                    .Select(x => new ResBrandDto
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Country = x.Country,
                    }).ToList();
                return brands;
            }
            catch (Exception ex)
            {
                throw new Exception($"Get Brand : {ex.Message}");
            }
        }

        public void DeleteBrand(int id)
        {
            try
            {
                var dataBrand = _dbContext.MstBrands
                    .FirstOrDefault(x => x.Id == id);
                if (dataBrand == null)
                {
                    throw new Exception("Data tidak ditemukan");
                }
                _dbContext.Remove(dataBrand);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal hapus data: {ex.Message}");
            }
        }

        public async Task<prc_upsert_brand> ExecPrcBrand(string name, string country, string idUser)
        {
            try
            {
                string procedureName = "prc_upsert_brand";
                string connectionString = _config.GetConnectionString("DefaultConnection") ?? "";
                prc_upsert_brand model = new prc_upsert_brand();

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    using (NpgsqlCommand command = new NpgsqlCommand(procedureName, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        // Tambahkan parameter name
                        command.Parameters.AddWithValue("p_name", name);

                        // Tambahkan parameter country
                        command.Parameters.AddWithValue("p_country", country);

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

                        // Menerapkan output pada model
                        model.OutMess = command.Parameters["out_mess"].Value != DBNull.Value ? command.Parameters["out_mess"].Value.ToString() : "No value";

                        return model;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException($"ExecPrcBrand : {e.Message}");
            }
        }
    }
}
