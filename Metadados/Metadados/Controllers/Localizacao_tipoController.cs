using CadastroMaterial.Models.Services;
using Metadados.Models;
using Metadados.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Metadados.Controllers
{
    public class Localizacao_tipoController : Controller
    {

        private readonly Localizacao_tipo_Services _Localizacao_tipo_Services;
       


        public Localizacao_tipoController(Localizacao_tipo_Services Localizacao_tipo_Services)
        {
            _Localizacao_tipo_Services = Localizacao_tipo_Services;
          
        }

        public IActionResult Index()
        {
            var list = _Localizacao_tipo_Services.FindAll();

            return View(list);
        }


        //GET: Tipo_objeto/Create
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Localizacao_tipo Localizacao_tipo)
        {
            if (ModelState.IsValid)
            {
                _Localizacao_tipo_Services.Insert(Localizacao_tipo);
                return RedirectToAction("Index");

            }
            return View(Localizacao_tipo);


        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Localizacao_tipo_Services.FindById(id.Value);
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
            _Localizacao_tipo_Services.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var obj = _Localizacao_tipo_Services.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            //List<Objeto_configuracao> Objeto_configuracao = _Objeto_configuracao_Service.FindAll();
            //Cadastro_objetoViewModel viewModel = new Cadastro_objetoViewModel { Cadastro_atributo = obj };

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Localizacao_tipo Localizacao_tipo)
        {
            if (id != Localizacao_tipo.sky_localizacao_tipo)
            {
                return BadRequest();
            }
            try
            {
                _Localizacao_tipo_Services.Update(Localizacao_tipo);
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
