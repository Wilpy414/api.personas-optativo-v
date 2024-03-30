using Microsoft.AspNetCore.Mvc;
using Repository.Data;

namespace api.personas.Controllers
{
    public class PersonaControlador : Controller
    {
        private IConfiguration configuration;
        private PersonaRepository personaRepository;

        /*public CuentaController()*/
        public PersonaControlador(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.personaRepository = new PersonaRepository(configuration.GetConnectionString("postgresDB"));
        }
        // Generate crud controller
        [HttpPost]
        [Route("add")]
        public IActionResult add(PersonaModel persona)
        {
            try
            {
                if (personaRepository.add(persona))
                    return Ok("Persona agregada correctamente");
                else
                    return BadRequest("Error al agregar persona");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public IActionResult update(PersonaModel persona)
        {
            try
            {
                if (personaRepository.update(persona))
                    return Ok("Persona actualizada correctamente");
                else
                    return BadRequest("Error al actualizar persona");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("remove")]
        public IActionResult remove(string cedula)
        {
            try
            {
                if (personaRepository.remove(cedula))
                    return Ok("Persona eliminada correctamente");
                else
                    return BadRequest("Error al eliminar persona");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get/{cedula}")]
        public IActionResult get(string cedula)
        {
            try
            {
                var persona = personaRepository.get(cedula);
                if (persona != null)
                    return Ok(persona);
                else
                    return BadRequest("Persona no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("list")]
        public IActionResult list()
        {
            try
            {
                var personas = personaRepository.list();
                if (personas != null)
                    return Ok(personas);
                else
                    return BadRequest("No hay personas registradas");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
