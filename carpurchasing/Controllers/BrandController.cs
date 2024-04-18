using carpurchasing_DAL.Models.Dto.Req;
using carpurchasing_DAL.Models.Prc;
using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace carpurchasing.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _service;

        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var dataBrand = _service.GetBrands();
            return View(dataBrand);
        }


        [HttpGet]
        public ActionResult FormTambahBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExecProcedure(prc_upsert_brand brand)
        {
            if (ModelState.IsValid)
            {
                _service.ExecPrcBrand(brand.Name, brand.Country, "brand.IdUser");
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // GET: BrandController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        [HttpDelete]
        public IActionResult Delete([FromForm] ReqBrandDto brand)
        {
            try
            {
                _service.DeleteBrand(brand.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
