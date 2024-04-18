using carpurchasing_DAL.Models;
using carpurchasing_DAL.Models.Dto.Req;
using carpurchasing_DAL.Models.Dto.Res;
using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carpurchasing_DAL.Repositories.Services
{
    public class TypeService : ITypeService
    {
        readonly CarfurchasingfinalContext _context;

        public TypeService(CarfurchasingfinalContext context)
        {
            _context = context;
        }

        public void AddType(ReqTypeDto type)
        {
            try
            {
                bool isDuplicate = _context.MstTypes.Any(x => x.Name == type.Name);
                if (!isDuplicate)
                {
                    var dataBaru = new MstType();
                    dataBaru.Name = type.Name;
                    dataBaru.DtAdded = DateTime.Now;
                    dataBaru.DtUpdated = DateTime.Now;

                    _context.Add(dataBaru);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Data duplication happen");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi eror, ${ex.Message}");
            }
        }

        public void DeleteType(int id)
        {
            try
            {
                var dataType = _context.MstTypes
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (dataType == null)
                {
                    throw new Exception("Data tidak ditemukan");
                }
                _context.Remove(dataType);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal hapus data: {ex.Message}");
            }
        }

        public ResTypeDto GetTypeById(int id)
        {
            try
            {
                var type = _context.MstTypes
                .Where(x => x.Id == id)
                .Select(x => new ResTypeDto
                {
                    Id = x.Id,
                    Name = x.Name,

                })
                .FirstOrDefault();
                if (type == null)
                {
                    throw new Exception("Data tidak ditemukan");
                }
                return type;
            }
            catch (Exception ex)
            {
                throw new Exception($"Tidak dapat memuat Type: {ex.Message}");
            }
        }

        public void UpdateType(int id, ReqTypeDto type)
        {
            try
            {
                _context.MstTypes
                    .Where(u => u.Id == id)
                    .ExecuteUpdate(setter => setter
                    .SetProperty(u => u.Name, type.Name)
                    .SetProperty(u => u.DtUpdated, DateTime.Now)
                    );
            }
            catch (Exception ex)
            {
                throw new Exception($"Tidak dapat mengubah data type : {ex.Message}");
            }
        }

        List<MstType> ITypeService.GetType()
        {
            return _context.MstTypes.ToList();
        }
    }
}
