using carpurchasing_DAL.Models.Dto.Req;
using carpurchasing_DAL.Models.Dto.Res;
using carpurchasing_DAL.Models.Prc;
using carpurchasing_DAL.Repositories.Services;
using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace carpurchasing.Controllers
{
    public class MobilController : Controller
    {
        private readonly IMobilService _mobilService;

        private readonly IBrandService _brandService;

        private readonly IModelService _modelService;

        private readonly ITypeService _typeService;

        private readonly IUsageService _usageService;

        private readonly ICustomerService _customerService;

        public MobilController(IMobilService mobilService, IBrandService brandService, IModelService modelService, ITypeService typeService, IUsageService usageService, ICustomerService customerService)
        {
            _mobilService = mobilService;
            _brandService = brandService;
            _modelService = modelService;
            _typeService = typeService;
            _usageService = usageService;
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var dataMobil = _mobilService.GetCar();
            return View(dataMobil);
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromForm] ReqMobilDto car)
        {
            try
            {
                _mobilService.DeleteCar(car.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult FormMobil()
        {
            ViewBag.brand = _brandService.GetBrands();
            ViewBag.model = _modelService.GetModels();
            ViewBag.type = _typeService.GetType();
            ViewBag.usage = _usageService.GetUsage();
            return View();
        }

        [HttpGet]
        public IActionResult FormEdit(Guid id)
        {
            ViewBag.brand = _brandService.GetBrands();
            ViewBag.model = _modelService.GetModels();
            ViewBag.type = _typeService.GetType();
            ViewBag.usage = _usageService.GetUsage();
            var dataCar = _mobilService.GetCarById(id);
            return View(dataCar);
        }

        //[HttpPost]
        //public IActionResult EditCar(ResMobilDto car)
        //{
        //    _mobilService.UpdateCar(car.Id, car);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult ExcecPrc(PrcUpsertCar mobil)
        {
            if (ModelState.IsValid)
            {
                _mobilService.ExecPrcCar(mobil.EngineSize, mobil.FuelType, mobil.ManufactureYear, mobil.CdChassis, mobil.CdEngine, mobil.BrandId, mobil.TypeId, mobil.UsageId, mobil.ModelId, mobil.Id);
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
