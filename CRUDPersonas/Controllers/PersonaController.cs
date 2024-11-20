using CRUDPersonas.Models.ViewModels;
using ENT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                List<Persona> personas = DAL.Listados.GetListadoPersonasDAL();
                foreach (Persona persona in personas)
                {
                    PersonaDepartamentoVM personaDpto = new PersonaDepartamentoVM(persona);
                    personasDepartamento.Add(personaDpto);
                }
            }
            catch (Exception e) 
            {
                throw e;
            }
            return View(personasDepartamento);
        }

        // GET: PersonaController/Details/5
        public ActionResult Details(int id)
        {
            PersonaDepartamentoVM persona = new PersonaDepartamentoVM();
            try
            {
                persona = new PersonaDepartamentoVM(DAL.CRUDPersona.GetPersona(id));
            }
            catch (Exception e) {
                throw e;
            }
            return View(persona);
        }

        // GET: PersonaController/Create
        public ActionResult Create()
        {
            List<Departamento> departamentos = new List<Departamento>();
            try
            {
                departamentos = DAL.Listados.GetListadoDepartamentosDAL();
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
                int res = DAL.CRUDPersona.AgregarPersona(persona);
                if (res != 1)
                {
                    //TODO: Vista de error
                }
            }
            catch (Exception e)
            {
                return View("Error", new ErrorVM(e));
            }
            finally {
                departamentos = DAL.Listados.GetListadoDepartamentosDAL();
            }
            return View(departamentos);

        }

        // GET: PersonaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persona persona)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
