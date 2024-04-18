using carpurchasing_DAL.Repositories.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace carpurchasing.Controllers
{
    public class ModelController : Controller
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        public IActionResult Index()
        {
            var dataModels = _modelService.GetModels(); 
            return View(dataModels);
        }
    }
}
