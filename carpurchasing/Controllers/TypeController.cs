using carpurchasing_DAL.Models.Dto.Req;
using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace carpurchasing.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        public IActionResult Index()
        {
            var dataType = _typeService.GetType();
            return View(dataType);
        }

        [HttpGet]
        public IActionResult FormTambahType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TambahType(ReqTypeDto type)
        {

            if (ModelState.IsValid)
            {
                _typeService.AddType(type);
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        public IActionResult FormEditType(int id)
        {
            var dataType = _typeService.GetTypeById(id);
            return View(dataType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditType([FromForm] ReqTypeDto type)
        {
            try
            {
                _typeService.UpdateType(type.Id, type);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteType([FromForm] ReqTypeDto type)
        {
            try
            {
                _typeService.DeleteType(type.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
