using CadastroMaterial.Models.Services;
using Metadados.Models;
using Metadados.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Controllers
{
    public class Objeto_tipoController : Controller
    {
        private readonly Objeto_tipo_Services _Objeto_tipo_Services;

        public Objeto_tipoController(Objeto_tipo_Services Objeto_tipo_Services)
        {

            _Objeto_tipo_Services = Objeto_tipo_Services;
        }

        public IActionResult Index()
        {
            var list = _Objeto_tipo_Services.FindAll();

            return View(list);
        }


        //GET: Tipo_objeto/Create
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Objeto_tipo Objeto_tipo)
        {
            _Objeto_tipo_Services.Insert(Objeto_tipo);
            return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Objeto_tipo_Services.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _Objeto_tipo_Services.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Objeto_tipo_Services.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            List<Objeto_tipo> teste = _Objeto_tipo_Services.FindAll();
            //Cadastro_objetoViewModel viewModel = new Cadastro_objetoViewModel { Cadastro_atributo = obj };

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Objeto_tipo Objeto_tipo)
        {
            if (id != Objeto_tipo.sky_objeto_tipo)
            {
                return BadRequest();
            }
            try
            {
                _Objeto_tipo_Services.Update(Objeto_tipo);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }


        }

        private IActionResult BadRequest()
        {
            throw new NotImplementedException();
        }
    }
}
