using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryUnitOfWork.API.Services;
using RepositoryUnitOfWork.Domain.Departments;
using System.Threading.Tasks;

namespace RepositoryUnitOfWork.API.Controllers
{
    [ApiController]
    [Route("departments")]
    public class DepartmentsController : ControllerBase
    {
        private readonly DepartmentService _service;
        public DepartmentsController(DepartmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos departaments cadastrados na base.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(Department), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            await _service.AddAllEntitiesAsync();

            return Ok(_service.GetAllEntitiesAsync());
        }
    }
}
