using CRUDPersonas.Models.ViewModels;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Globalization;

namespace CRUDPersonas.Controllers
{
    public class PersonaController : Controller
    {
        // GET: PersonaController
        public ActionResult Index()
        {
            List<PersonaDepartamentoVM> personasDepartamento = new List<PersonaDepartamentoVM>();
            try
            {
                List<Persona> personas = BL.Listados.GetListadoPersonasBL();
                foreach (Persona persona in personas)
                {
                    PersonaDepartamentoVM personaDpto = new PersonaDepartamentoVM(persona);
                    personasDepartamento.Add(personaDpto);
                }
            }
            catch (SqlException e)
            {
                return View("Error", new ErrorVM(new Exception("No se ha podido acceder a la base de datos")));
            }
            catch (Exception e) {
                return View("Error", new ErrorVM(e));
            }
            return View(personasDepartamento);
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            PersonaDepartamentoVM persona = new PersonaDepartamentoVM();
            try
            {
                persona = new PersonaDepartamentoVM(BL.ManejadoraPersonas.GetPersonaBL(id));
            }
            catch (Exception e) {
                return View("Error", new ErrorVM(e));
            }
            return View(persona);
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            List<Departamento> departamentos = new List<Departamento>();
            try
            {
                departamentos = BL.Listados.GetListadoDepartamentosBL();
            }
            catch (Exception e) {
                throw e;
            }
            return View(departamentos);
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            List<Departamento> departamentos = new List<Departamento>();

            try
            {
                int res = BL.ManejadoraPersonas.AgregarPersonaBL(persona);
                if (res != 1)
                {
                    return View("Error", new ErrorVM(new Exception("No se ha podido añadir la persona")));
                }
            }
            catch (Exception e)
            {
                return View("Error", new ErrorVM(e));
            }
            finally {
                departamentos = BL.Listados.GetListadoDepartamentosBL();
            }
            return View(departamentos);

        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            PersonaListaDepartamentos persona = new PersonaListaDepartamentos();

            try
            {
                persona = new PersonaListaDepartamentos(BL.ManejadoraPersonas.GetPersonaBL(id));
            }
            catch (Exception e) {
                return View("Error", new ErrorVM(e));
            }
            return View(persona);
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Persona persona)
        {
            try
            {
                int res = DAL.CRUDPersona.ModificarPersona(persona);
                if (res != 1) {
                    return View("Error", new ErrorVM(new Exception("No se pudo modificar la persona.")));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Error", new ErrorVM(e));
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            Persona persona;
            try
            {
                persona = BL.ManejadoraPersonas.GetPersonaBL(id);
            }
            catch (Exception e) {
                return View("Error", new ErrorVM(e));
            }
            return View(persona);
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                int res = BL.ManejadoraPersonas.BorrarPersonaBL(id);
                if (res != 1) {
                    return View("Error", new ErrorVM(new Exception("No se ha podido borrar la persona")));
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Error", new ErrorVM(e));
            }
        }
    }
}
