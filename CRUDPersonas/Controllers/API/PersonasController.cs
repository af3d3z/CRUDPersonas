using BL;
using ENT;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDPersonas.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
        [HttpGet]
        public List<Persona> Get()
        {
            return Listados.GetListadoPersonasBL();
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public Persona Get(int id)
        {
            return ManejadoraPersonas.GetPersonaBL(id);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            IActionResult salida;
            if (persona != null)
            {
                try
                {
                    int affectedRows = ManejadoraPersonas.AgregarPersonaBL(persona);
                    if (affectedRows > 0)
                    {
                        salida = Ok("Se ha guardado correctamente.");
                    }
                    else
                    {
                        salida = Ok("No se ha podido guardar la persona.");
                    }
                }
                catch (Exception e) {
                    salida = BadRequest();
                }
            }
            else {
                salida = BadRequest();
            }
            return salida;
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Persona persona)
        {
            IActionResult salida;
            if (persona != null && persona.ID > 0)
            {
                try
                {
                    int affectedRows = ManejadoraPersonas.ModificarPersonaBL(persona);
                    if (affectedRows > 0)
                    {
                        salida = Ok("Se ha modificado correctamente");
                    }
                    else {
                        salida = Ok("No se ha podido modificar la persona");
                    }
                }
                catch (Exception e) {
                    salida = BadRequest();
                }
            }
            else {
                salida = BadRequest();
            }
            return salida;
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            if (id > 0)
            {
                try
                {
                    int affectedRows = ManejadoraPersonas.BorrarPersonaBL(id);
                    if (affectedRows > 0)
                    {
                        salida = Ok("Se ha borrado de forma satisfactoria.");
                    }
                    else {
                        salida = Ok("No se ha podido borrar.");
                    }
                }
                catch (Exception e) {
                    salida = BadRequest();
                }
            }else
            {
                salida = BadRequest();
            }
            return salida;
        }
    }
}
