using Education.Application.Cursos;
using Education.Application.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private IMediator _mediator;

        public CursoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoDTO>>> Get()
        {
            return await _mediator.Send(new GetCursoQuery.GetCursoQueryRequest());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateCursoCommand.CreateCursoCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
