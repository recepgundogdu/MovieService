using Microsoft.AspNetCore.Mvc;
using MovieService.Core.Business;
using MovieService.DataAccess.Models;
using MovieService.WebAPI.Utilities;

namespace MovieService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        #region CTOR
        private readonly IFilmService _filmService;
        public MovieController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        #endregion

        [CustomAuthorization("Write")]
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] Movie entity) => new JsonResult(_filmService.Add(entity));


        [CustomAuthorization]
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int Id) => new JsonResult(_filmService.GetById(Id));


        [CustomAuthorization]
        [HttpGet]
        [Route("GetByCategoryId")]
        public IActionResult GetByCategoryId(int Id) => new JsonResult(_filmService.GetByCategoryId(Id));


        [CustomAuthorization]
        [HttpGet]
        [Route("List")]
        public IActionResult List() => new JsonResult(_filmService.List());


        [CustomAuthorization("Write")]
        [HttpPost]
        [Route("Update")]
        public IActionResult Update([FromBody] Movie entity) => new JsonResult(_filmService.Update(entity));


        [CustomAuthorization("Write")]
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] Movie entity) => new JsonResult(_filmService.Delete(entity));

    }
}