using Microsoft.AspNetCore.Mvc;
using MovieService.Core.Business;
using MovieService.DataAccess.Models;
using MovieService.WebAPI.Utilities;

namespace MovieService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region CTOR
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }
        #endregion

        [CustomAuthorization("Write")]
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] Category entity) => new JsonResult(_categoryService.Add(entity));


        [CustomAuthorization]
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int Id) => new JsonResult(_categoryService.GetById(Id));


        [CustomAuthorization]
        [HttpGet]
        [Route("List")]
        public IActionResult List() => new JsonResult(_categoryService.List());


        [CustomAuthorization("Write")]
        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody] Category entity) => new JsonResult(_categoryService.Update(entity));


        [CustomAuthorization("Write")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] Category entity) => new JsonResult(_categoryService.Delete(entity));
    }
}


