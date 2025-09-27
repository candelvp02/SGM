using Microsoft.AspNetCore.Mvc;
using SGM.Api.dto;

namespace SGM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
    {
        private readonly ICitaService _citaService;
        public CitaController(ICitaService citaService)
        {
            _citaService = citaService;
        }
        [HttpPost]
        public async Task<ActionResult<CitaDto>> CrearCita(CrearCitaDto dto)
        {
            var resultado = await _citaService.CrearCitaAsync(dto);
            return resultado.IsSuccess ? CreatedAtAction(nameof(GetCita), new { id = resultado.Value.Id }, resultado.Value.ToDto()) : BadRequest(resultado.Error);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaDto>>> GetCitas()
        {
            return Ok(await _citaService.ObtenerTodasLasCitasAsync());
        }
    }
    
}
